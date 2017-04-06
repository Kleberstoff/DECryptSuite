using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;
using System.Reflection;

namespace DECrypt_Suite
{
    class Program
    {
        private static bool file = false;
        private static bool folder = false;
        private static bool error = false;
        private static string password = "";
        private static string filePath = "";
        private static string folderPath = "";

        private static byte[] data;

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
        public static string ApplicationName = "DECrypt Suite v0.0";

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Title = ApplicationName;

            if (args.Length == 0)
            {
                //error = true;
            }

            for (int i = 0; i < args.Count(); i++)
            {
                switch(args[i].ToLower())
                {
                    case "-h":

                        Exit(null, null);
                        break;
                    case "--help":

                        Exit(null, null);
                        break;
                    case "-c":
                        Console.WriteLine("Made by @Kleberstoff with some \"borrowed\" Source from Matt (HackNet's Main Developer)"); //Sorry Matt love you <3
                        Console.WriteLine("This is baised on the .DEC encryption from HackNet and it NOT really secure.");
                        Console.WriteLine("It's been made only for Fun and should be used for important files.\n");
                        Console.WriteLine("Buy HackNet on Steam: http://store.steampowered.com/app/365450/ <3");
                        Exit(null, null);
                        break;

                    case "--credits":
                        Console.WriteLine("Made by @Kleberstoff with some \"borrowed\" Sourcecode from Matt (HackNet's Main Developer)");
                        Console.WriteLine("This is baised on the .DEC encryption from HackNet and it NOT really secure or effective.");
                        Console.WriteLine("It's been made only for Fun and should be used for important files.");
                        Console.WriteLine("\nBuy HackNet on Steam: http://store.steampowered.com/app/365450/ <3");
                        Exit(null, null);
                        break;

                    case "-f":
                        file = true;
                        filePath = args[i + 1];
                        break;

                    case "--file":
                        file = true;
                        filePath = args[i + 1];
                        break;

                    case "-":

                        break;

                    case "--":

                        break;

                    
                    default:
                        break;
                }
            }

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

                    var fileName = Assembly.GetExecutingAssembly().Location;
                    System.Diagnostics.Process.Start(fileName);
                    Exit(null, null);
                }
                else if(answer == "n")
                {
                    Console.WriteLine("Exiting now.");
                    Thread.Sleep(1500);
                    Exit(null, null);
                }
            }

            if(error == true)
            {
                Console.WriteLine("Unknown or invalid Argument.");
                Exit(null, null);
            }


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

        // ^^ DECRYPY ^^ \\
        //==============\\
        //Down Encrypt Down\\

        public static string EncryptString(string data, string Sign, string header = null,  string pass = "", string fileExtension = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("REMEMBER THIS IS NOT A REAL SAFE ENCRYPTION!");
            Console.WriteLine("USE AT YOU'R OWN RISK! YOU HAVE BEEN WARNED.\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;

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

        static void Exit(object sender, EventArgs e)
        {
            Console.ResetColor();
            Environment.Exit(0);
        }
    }
}
