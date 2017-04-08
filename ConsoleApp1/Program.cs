using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;
using System.IO.Compression;
using System.Reflection;

/*
 * auto create 
 * 
 * 
 * 
 * 
 */

namespace DECrypt_Suite
{
    class Program
    {
        private static bool file = false;
        private static bool folder = false;
        private static bool header = false;
        private static bool headeronly = false;
        private static bool decrypting = false;

        private static string password = "";
        private static string filePath = "";
        private static string folderPath = "";
        private static string extenstion = "";
        private static string headerData = "";
        private static string output = "";

        private static string signing = DecryptMix(Properties.Settings.Default.U2lnbgqq); //those "random" stuff is just base64 encoding so nothing hard see encryptionmix and decryptiosmix
        /*
         * 
         * Got those from Matt's(HackNet's Main Dev Source Code)
         * Sorry Matt <3
         * 
         */
        private static string[] HeaderSplitDelimiters = new string[] { "::" };
        private static ushort GetPassCodeFromString(string code) => ((ushort)code.GetHashCode());
        public static string truebase64 = EncryptMix("true");
        public static string falsebase64 = EncryptMix("false");
        /*
        public static string FirstRunbase64 = EncryptMix("FirstRun").Replace('=', 'E');
        public static string Signbase64 = EncryptMix("Sign").Replace('=', 'q');
        */
        public static string[] robustNewlineDelim = new string[] { "\r\n", "\n" };
        public static char[] spaceDelim = new char[] { ' ' };
        public static string ApplicationName = "DECrypt Suite v1.337";

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Title = ApplicationName;

            var dir = AppDomain.CurrentDomain.BaseDirectory;
            if(!Directory.Exists(dir + "/files"))
            {
                Directory.CreateDirectory(dir + "/files");
            }

            /* Testing stuff

            string en = BitConverter.ToString(GetBinaryFile("files/input.zip"));
            en = EncryptString(en, signing, "Test .ZIP", "", ".gif");
            File.WriteAllText("files/output.dec", en);

            string raw = File.ReadAllText("files/output.dec");
            string[] de = DecryptString(raw, "");
            byte[] data = de[2].Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();

            Console.WriteLine($"Header: {de[0]}");
            Console.WriteLine($"Signed by: {de[1]}");
            File.WriteAllBytes("files/output.zip", data);
            Console.WriteLine($"File Extension: {de[3]}");
            Console.WriteLine($"Password Valid: {de[4]}");

            Console.WriteLine("Press enter to Exit.");
            Console.ReadLine();


            string FolderPath = "C:\\Users\\justa\\Desktop\\Confuser";

            ZipFile.CreateFromDirectory(FolderPath, "C:\\Users\\justa\\Desktop\\test.zip");

            Exit();
            */

            // First start up shit ---------------------------------------------------------------------- \\

            if (DecryptMix(Properties.Settings.Default.Rmlyc3RSdW4E) == "true")
            {
                Console.WriteLine("First run deteced... Running startup frequency");
                Console.WriteLine("Welcome to the " + ApplicationName + "Encryption and Decryption Tool.");
                Console.WriteLine("We gonna ask you a few Question now, press enter when ready.");
                Console.ReadLine();
                Console.WriteLine("What should your Signing be? Each File will be Signed using that.");
                Console.WriteLine("Note: Try avoiding Special Chars and try to use a Acronym linked to you which is somewhat known.");
                string sign = Console.ReadLine();
                Console.WriteLine($"Signing is set too '{sign}'. Is that correct? (y/n)");
                string answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    Properties.Settings.Default.Rmlyc3RSdW4E = EncryptMix("false");
                    Properties.Settings.Default.U2lnbgqq = EncryptMix(sign);
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                    Console.WriteLine("Restarting in 3..");
                    Thread.Sleep(1000);
                    Console.WriteLine("2...");
                    Thread.Sleep(1000);
                    Console.WriteLine("1...");
                    Thread.Sleep(1000);
                    Console.WriteLine("69.. hehexd");

                    Exit();
                }
                else if (answer == "n")
                {
                    Console.Write("Exiting now...");
                    for (int i = 0; i < 1500; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(1);
                    }
                    Exit();
                }
            }
            // ---------------------------------------------------------------------------------------- \\

            if (args.Length == 0)
            {
                Console.WriteLine("No Arguments.");
                Exit();
            }

            for (int i = 0; i < args.Count(); i++)
            {
                switch (args[i].ToLower())
                {
                    case "-h":
                        Console.WriteLine("Help for the DECryptSuite:\n");
                        Console.WriteLine("Default Mode is Encryption to Decrypt use -d or --decrypt");
                        Console.WriteLine("For more information use --help <command>(c/f etc)");
                        Console.WriteLine("Most commands can be execute with -c and their longer version --credits for example.");
                        Console.WriteLine("-f(--file)/-dir(--folder),-he(--header) are required arguments.");
                        Console.WriteLine("\nList all Commands:");
                        Console.WriteLine("-c/--credits: shows the Credits.");
                        Console.WriteLine("-f/--file: Selects a Files from a Path");
                        Console.WriteLine("-dir/--directory: Selects a Files from a Path");
                        Console.WriteLine("-p/--password: Sets a Password for en/decrypting the files.");
                        Console.WriteLine("-ex/--extension: Sets the File Extenstion.");
                        Console.WriteLine("-he/--header: Sets the Header");
                        Console.WriteLine("-o/--output: Set's the output directory.");
                        Console.WriteLine("--contact: Shows my contact information.");
                        Console.WriteLine("--headeronly so it only shows the unecrypted header of the files.");
                        Exit();
                        break;
                    case "--help":
                        Console.WriteLine("Help for the DECryptSuite:\n");
                        Console.WriteLine("Default Mode is Encryption to Decrypt use -d or --decrypt");
                        Console.WriteLine("For more information use --help <command>(c/f etc)");
                        Console.WriteLine("Most commands can be execute with -c and their longer version --credits for example.");
                        Console.WriteLine("-f(--file)/-dir(--folder),-he(--header) are required arguments.");
                        Console.WriteLine("\nList all Commands:");
                        Console.WriteLine("-c/--credits: shows the Credits.");
                        Console.WriteLine("-f/--file: Selects a Files from a Path");
                        Console.WriteLine("-dir/--directory: Selects a Files from a Path");
                        Console.WriteLine("-p/--password: Sets a Password for en/decrypting the files.");
                        Console.WriteLine("-ex/--extension: Sets the File Extenstion.");
                        Console.WriteLine("-he/--header: Sets the Header");
                        Console.WriteLine("-o/--output: Set's the output directory.");
                        Console.WriteLine("--contact: Shows my contact information.");
                        Console.WriteLine("--headeronly so it only shows the unecrypted header of the files.");
                        Exit();
                        break;
                    case "-c":
                        Console.WriteLine("Made by @Kleberstoff with some \"borrowed\" Sourcecode from Matt (HackNet's Main Developer)");
                        Console.WriteLine("This is baised on the .DEC encryption from HackNet and it NOT really secure or effective.");
                        Console.WriteLine("It's been made only for Fun and should be NEVER used for important files.");
                        Console.WriteLine("Thanks to trollbreeder#0369 for the wonderful name and A Casual Guy#0070 for testing, ya both are awesome.");
                        Console.WriteLine("\nBuy HackNet on Steam: http://store.steampowered.com/app/365450/");
                        Exit();
                        break;
                    case "--credits":
                        Console.WriteLine("Made by @Kleberstoff with some \"borrowed\" Sourcecode from Matt (HackNet's Main Developer)");
                        Console.WriteLine("This is baised on the .DEC encryption from HackNet and it NOT really secure or effective.");
                        Console.WriteLine("It's been made only for Fun and should be NEVER used for important files.");
                        Console.WriteLine("Thanks to trollbreeder#0369 for the wonderful name and A Casual Guy#0070 for testing, ya both are awesome.");
                        Console.WriteLine("\nBuy HackNet on Steam: http://store.steampowered.com/app/365450/");
                        Exit();
                        break;
                    case "--contact":
                        Console.WriteLine("You can contact me via Discord Kleberstoff#5914, or at admin@kleberstof.xyz.");
                        break;
                    case "1337":
                        Console.WriteLine("Shotout to all HackNet Veterans. Ya'll are awesome.");
                        break;
                    case "-v":
                        Console.WriteLine("Current Version: 1.337.");
                        Exit();
                        break;
                    case "--version":
                        Console.WriteLine("Current Version: 1.337.");
                        Exit();
                        break;
                    case "-f":
                        file = true;
                        filePath = args[i + 1];
                        break;
                    case "--file":
                        file = true;
                        filePath = args[i + 1];
                        break;
                    case "-dir":
                        folder = true;
                        folderPath = args[i + 1] + "\\";
                        break;
                    case "--directory":
                        folder = true;
                        folderPath = args[i + 1] + "\\";
                        break;
                    case "-p":
                        password = args[i + 1];
                        break;
                    case "--password":
                        password = args[i + 1];
                        break;
                    case "-e":
                        extenstion = args[i + 1];
                        break;
                    case "-o":
                        output = args[i + 1];
                        break;
                    case "--output":
                        output = args[i + 1];
                        break;
                    case "-ex":
                        extenstion = args[i + 1];
                        break;
                    case "--extension":
                        extenstion = args[i + 1];
                        break;
                    case "-d":
                        decrypting = true;
                        break;
                    case "--decrypt":
                        decrypting = true;
                        break;
                    case "-he":
                        header = true;
                        headerData = args[i + 1];
                        break;
                    case "--header":
                        header = true;
                        headerData = args[i + 1];
                        break;
                    case "--headeronly":
                        headeronly = true;
                        break;
                    default:
                        break;
                }
            }

            if (folder == true && decrypting == true)
            {
                Console.WriteLine("Folder Method is only for ENCRYPTING. Exiting.");
                Exit();
            }

            if (file == true || folder == true)
            {
                if (file == true && folder == true)
                {
                    Console.WriteLine("Don't use Directory and File in the same Execution. Refer to --help dir. ");
                    Exit();
                }
    
                if (folder == true)
                {
                    if (folderPath != null && folderPath != "")
                    {
                        extenstion = ".zip";
                        if (output != "" && output != null)
                        {
                            ZipFile.CreateFromDirectory(folderPath, output + "temp.zip");
                            string Encryption = BitConverter.ToString(GetBinaryFile(output + "temp.zip"));
                            Encryption = EncryptString(Encryption, signing, headerData, password, extenstion);
                            File.WriteAllText(output + ".dec", Encryption);
                            Console.WriteLine($"Encryption of {folderPath} completed.");
                            Console.WriteLine("Deleting created temp.zip");
                            File.Delete(output + "temp.zip");
                            Exit();
                        }
                        else
                        {
                            ZipFile.CreateFromDirectory(folderPath, "files/temp.zip");
                            string Encryption = BitConverter.ToString(GetBinaryFile("files/temp.zip"));
                            Encryption = EncryptString(Encryption, signing, headerData, password, extenstion);
                            File.WriteAllText("files/output.dec", Encryption);
                            Console.WriteLine($"Encryption of {folderPath} completed.");
                            Console.WriteLine("Deleting created temp.zip");
                            File.Delete("files/temp.zip");
                            Exit();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Folder Path");
                        Exit();
                    }
                }
                if (file == true)
                {
                    if (filePath != null && filePath != "")
                    {
                        if (headeronly == true)
                        {
                            string raw = File.ReadAllText(filePath);
                            string[] headerInfo = DecryptHeaders(raw);

                            Console.WriteLine("Information from the Header:\n");
                            Console.WriteLine($"Header: {headerInfo[0]}");
                            Console.WriteLine($"Signed by: {headerInfo[1]}");
                            Console.WriteLine($"File Extension: {headerInfo[2]}");
                            Exit();
                        }

                        if (output != null && output != "")
                        {
                            if (decrypting == true)
                            {
                                string raw = File.ReadAllText(filePath);
                                string[] de = DecryptString(raw, password);
                                byte[] data = de[2].Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();

                                Console.WriteLine($"Header: {de[0]}");
                                Console.WriteLine($"Signed by: {de[1]}");
                                File.WriteAllBytes("files/output" + de[3], data);
                                Console.WriteLine($"File Extension: {de[3]}");
                                Console.WriteLine($"Password Valid: {de[4]}");
                                Exit();
                            }
                            else
                            {
                                if (headerData != "" && headerData != null)
                                {
                                    string Encryption = BitConverter.ToString(GetBinaryFile(filePath));
                                    Encryption = EncryptString(Encryption, signing, headerData, password, extenstion);
                                    File.WriteAllText(output + ".dec", Encryption);
                                    Console.WriteLine($"Encryption of {filePath} completed.");
                                    Exit();
                                }
                                else
                                {
                                    Console.WriteLine("No Headerdata found, aborting.");
                                    Exit();
                                }
                            }
                        }
                        else
                        {
                            if (decrypting == true)
                            {
                                string raw = File.ReadAllText(filePath);
                                string[] de = DecryptString(raw, password);
                                byte[] data = de[2].Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();

                                Console.WriteLine($"Header: {de[0]}");
                                Console.WriteLine($"Signed by: {de[1]}");
                                File.WriteAllBytes("files/output" + de[3], data);
                                Console.WriteLine($"File Extension: {de[3]}");
                                Console.WriteLine($"Password Valid: {de[4]}");
                                Exit();
                            }
                            else
                            {
                                if (headerData != "" && headerData != null)
                                {
                                    string Encryption = BitConverter.ToString(GetBinaryFile(filePath));
                                    Encryption = EncryptString(Encryption, signing, headerData, password, extenstion);
                                    File.WriteAllText("files/output.dec", Encryption);
                                    Console.WriteLine($"Encryption of {folderPath} completed.");
                                    Exit();
                                }
                                else
                                {
                                    Console.WriteLine("No Headerdata found, aborting.");
                                    Exit();
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid File Path.");
                        Exit();
                    }
                }
            }
            else
            {
                Console.WriteLine("Didn't specify Folderpath or Filepath.");
                Exit();
            }

            Exit(null, null);
        }

        ///summary
        ///
        /// Returns an array containing
        /// [0] Header Message
        /// [1] Signing
        /// [2] Message Data
        /// [3] File extension if provided, else null
        /// [4] "1" is password is valid, "0" if not
        /// 
        ///summary

        private static string[] DecryptString(string data, string pass = "")
        {
            string[] ret = new string[5];
            ushort passcode = GetPassCodeFromString(pass);
            ushort emptypasscode = GetPassCodeFromString("");

            string[] split = data.Split(robustNewlineDelim, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length < 2) throw new FormatException("Tried to decrypt an invalid valid DEC ENC file");
            string[] headersSplit = split[0].Split(HeaderSplitDelimiters, StringSplitOptions.None);
            if (headersSplit.Length < 4) throw new FormatException("Tried to decrypt an invalid valid DEC ENC file");

            string headerMsg = Decrypt(headersSplit[1], emptypasscode);
            string sign = Decrypt(headersSplit[2], emptypasscode);
            string check = Decrypt(headersSplit[3], passcode);
            string fileExtension = null;
            if (headersSplit.Length > 4) fileExtension = Decrypt(headersSplit[4], emptypasscode);
            string message;
            string passValid = "true";

            if (check == "ENCODED")
            {
                message = Decrypt(split[1], passcode);
            }
            else
            {
                headerMsg = null;
                sign = null;
                message = null;
                passValid = "false";
            }

            ret[0] = headerMsg;
            ret[1] = sign;
            ret[2] = message;
            ret[3] = fileExtension;
            ret[4] = passValid;
            return ret;
        }

        public static string[] DecryptHeaders(string data, string pass = "")
        {
            string[] strArray = new string[3];
            ushort passCodeFromString = GetPassCodeFromString(pass);
            string[] strArray2 = data.Split(robustNewlineDelim, StringSplitOptions.RemoveEmptyEntries);
            if (strArray2.Length < 2)
            {
                throw new FormatException("Tried to decrypt an invalid valid DEC ENC file");
            }
            string[] strArray3 = strArray2[0].Split(HeaderSplitDelimiters, StringSplitOptions.None);
            if (strArray3.Length < 4)
            {
                throw new FormatException("Tried to decrypt an invalid valid DEC ENC file");
            }
            string str = Decrypt(strArray3[1], passCodeFromString);
            string str2 = Decrypt(strArray3[2], passCodeFromString);
            string str3 = null;
            if (strArray3.Length > 4)
            {
                str3 = Decrypt(strArray3[4], passCodeFromString);
            }
            strArray[0] = str;
            strArray[1] = str2;
            strArray[2] = str3;
            return strArray;
        }

        private static string Decrypt(string data, ushort passcode)
        {
            StringBuilder builder = new StringBuilder();
            string[] strArray = data.Split(spaceDelim, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strArray.Length; i++)
            {
                int num2 = Convert.ToInt32(strArray[i]);
                int num3 = 0x7fff;
                int num4 = (num2 - num3) - passcode;
                num4 /= 0x71e;
                builder.Append((char)num4);
            }
            return builder.ToString().Trim();
        }

        //↑↑ DECRYPY ↑↑\\
        //=============\\
        //↓↓ Encrypt ↓↓\\

        public static string EncryptString(string data, string Sign, string header = null,  string pass = "", string fileExtension = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("REMEMBER THIS IS NOT A REAL SAFE ENCRYPTION!");
            Console.WriteLine("USE AT YOU'R OWN RISK! YOU HAVE BEEN WARNED.\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Note: This may take a long time.");

            ushort passCodeFromString = GetPassCodeFromString(pass);
            ushort passcode = GetPassCodeFromString("");
            StringBuilder builder = new StringBuilder();

            string str = "#DEC_ENC::" + Encrypt(header, passcode) + "::" + Encrypt(Sign, passcode) + "::" + Encrypt("ENCODED", passCodeFromString);
            if (fileExtension != null)
            {
                str = str + "::" + Encrypt(fileExtension, passcode);
            }
            builder.Append(str);
            builder.Append("\r\n");
            builder.Append(Encrypt(data, passCodeFromString));
            return builder.ToString();
        }

        private static string Encrypt(string data, ushort passcode)
        {
            StringBuilder ret = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                int newVal = ((ushort)data[i] * 1822) + ushort.MaxValue / 2 + passcode;
                ret.Append(newVal + " ");
            }
            return ret.ToString().Trim();
        }

        // MY RANDOM STUFF \\

        private static byte[] GetBinaryFile(string Path)
        {
            byte[] bytes;
            using (FileStream file = new FileStream(Path, FileMode.Open, FileAccess.Read))
            {
                bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
            }
            return bytes;
        }

        private static string EncryptMix(string String)
        {
            if(String == null)
            {
                throw new ArgumentNullException();
            }

            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(String);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static string DecryptMix(string String)
        {
            if (String == null)
            {
                throw new ArgumentNullException();
            }

            byte[] base64EncodedBytes = System.Convert.FromBase64String(String);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        static void Exit(object sender = null, EventArgs e = null)
        {
            Console.ResetColor();
            Environment.Exit(0);
        }
    }
}
