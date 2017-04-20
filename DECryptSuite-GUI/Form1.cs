using System;
using System.IO;
using System.Net;
using MaterialSkin;
using System.Diagnostics;
using System.Windows.Forms;
using MaterialSkin.Controls;


namespace DECryptSuite_GUI
{
    public partial class Form1 : MaterialForm
    {
        /* Skin Manager */
        private readonly MaterialSkinManager materialSkinManager;
        /* Variable Stuff */
        bool DefaultWhite = Properties.Settings.Default.DefaultWhite;

        public Form1()
        {
            Console.Title = "DECryptSuite GUI Debug Console";
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            if (DefaultWhite == true)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("DECryptSuite.exe"))
            {
                DialogResult answer = MessageBox.Show("We couldn't find DECryptSuite.exe, Do you want to download it?\n", "Couldn't Find DECryptSuite.exe!", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    try
                    {
                        WebClient client = new WebClient();
                        client.DownloadFile(new Uri("https://github.com/Kleberstoff/DECryptSuite/releases/download/1.0/DECryptSuite.exe"), "DECryptSuite.exe");
                        client.Dispose();
                        Console.WriteLine("Running DECryptSuite for first Startup.");
                        Process.Start("DECryptSuite.exe");
                        MessageBox.Show("Download Complete - Program now ready for use.", "Download Complete!", MessageBoxButtons.OK);
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine($"{Ex.Message} - {Ex.Source}");
                    }
                }
                else
                {
                    Console.WriteLine("Bye!");
                    Environment.Exit(420);
                }
            }
        }

        private void ChangeTheme(object sender, EventArgs e)
        {
            if (materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                Properties.Settings.Default.DefaultWhite = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                if (materialSkinManager.Theme == MaterialSkinManager.Themes.DARK)
                {
                    materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                    Properties.Settings.Default.DefaultWhite = true;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void OutputFolderSelect_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    OutputField.Text = fbd.SelectedPath;
                }
            }
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(HeaderField.Text))
            {
                OpenFileDialog file = new OpenFileDialog();
                DialogResult result = file.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filePath = file.FileName;
                    if (!string.IsNullOrWhiteSpace(filePath))
                    {
                        filePath = '"' + filePath + '"';
                        if (string.IsNullOrWhiteSpace(PasswordField.Text) && string.IsNullOrWhiteSpace(OutputField.Text) && string.IsNullOrWhiteSpace(FileExtensionField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-f {filePath} -he {HeaderField.Text}",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(PasswordField.Text) && string.IsNullOrWhiteSpace(OutputField.Text) && string.IsNullOrWhiteSpace(FileExtensionField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-f {filePath} -he {HeaderField.Text} -p {PasswordField.Text}",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (string.IsNullOrWhiteSpace(PasswordField.Text) && !string.IsNullOrWhiteSpace(OutputField.Text) && string.IsNullOrWhiteSpace(FileExtensionField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-f {filePath} -he {HeaderField.Text} -o {OutputField.Text}\\output",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (string.IsNullOrWhiteSpace(PasswordField.Text) && string.IsNullOrWhiteSpace(OutputField.Text) && !string.IsNullOrWhiteSpace(FileExtensionField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-f {filePath} -he {HeaderField.Text} -ex {FileExtensionField.Text}",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(PasswordField.Text) && !string.IsNullOrWhiteSpace(OutputField.Text) && string.IsNullOrWhiteSpace(FileExtensionField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-f {filePath} -he {HeaderField.Text} -p {PasswordField.Text} -o {OutputField.Text}\\output",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (string.IsNullOrWhiteSpace(PasswordField.Text) && !string.IsNullOrWhiteSpace(OutputField.Text) && !string.IsNullOrWhiteSpace(FileExtensionField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-f {filePath} -he {HeaderField.Text} -o {OutputField.Text}\\output -ex {FileExtensionField.Text}",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(PasswordField.Text) && string.IsNullOrWhiteSpace(OutputField.Text) && !string.IsNullOrWhiteSpace(FileExtensionField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-f {filePath} -he {HeaderField.Text} -p {PasswordField.Text} -ex {FileExtensionField.Text}",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(PasswordField.Text) && !string.IsNullOrWhiteSpace(OutputField.Text) && !string.IsNullOrWhiteSpace(FileExtensionField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-f {filePath} -he {HeaderField.Text} -p {PasswordField.Text} -o {OutputField.Text}\\output -ex {FileExtensionField.Text}",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No HeaderData found, aborting.");
            }
        }

        private void EncryptFolderButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(HeaderField.Text))
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string folderPath = '"' + fbd.SelectedPath + '"';
                        if (string.IsNullOrWhiteSpace(PasswordField.Text) && string.IsNullOrWhiteSpace(OutputField.Text) && string.IsNullOrWhiteSpace(FileExtensionField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-dir {folderPath} -he {HeaderField.Text}",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(PasswordField.Text) && string.IsNullOrWhiteSpace(OutputField.Text) && string.IsNullOrWhiteSpace(FileExtensionField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-dir {folderPath} -he {HeaderField.Text} -p {PasswordField.Text}",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (string.IsNullOrWhiteSpace(PasswordField.Text) && !string.IsNullOrWhiteSpace(OutputField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-dir {folderPath} -he {HeaderField.Text} -o {OutputField.Text}\\output -ex .zip",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (string.IsNullOrWhiteSpace(PasswordField.Text) && string.IsNullOrWhiteSpace(OutputField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-dir {folderPath} -he {HeaderField.Text} -ex .zip",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(PasswordField.Text) && !string.IsNullOrWhiteSpace(OutputField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-dir {folderPath} -he {HeaderField.Text} -p {PasswordField.Text} -o {OutputField.Text}\\output -ex .zip",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (string.IsNullOrWhiteSpace(PasswordField.Text) && !string.IsNullOrWhiteSpace(OutputField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-dir {folderPath} -he {HeaderField.Text} -o {OutputField.Text}\\output -ex .zip",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(PasswordField.Text) && string.IsNullOrWhiteSpace(OutputField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-dir {folderPath} -he {HeaderField.Text} -p {PasswordField.Text} -ex .zip",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(PasswordField.Text) && !string.IsNullOrWhiteSpace(OutputField.Text))
                        {
                            var proc = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "DECryptSuite.exe",
                                    Arguments = $"-dir {folderPath} -he {HeaderField.Text} -p {PasswordField.Text} -o {OutputField.Text}\\output -ex .zip",
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true
                                }
                            };
                            proc.Start();
                            while (!proc.StandardOutput.EndOfStream)
                            {
                                Console.WriteLine(proc.StandardOutput.ReadLine());
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No HeaderData found, aborting.");
            }
        }

        private void HeadersOnlyButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            DialogResult result = file.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = file.FileName;
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    var proc = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "DECryptSuite.exe",
                            Arguments = $"-f {filePath} --headeronly",
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        }
                    };
                    proc.Start();
                    while (!proc.StandardOutput.EndOfStream)
                    {
                        Console.WriteLine(proc.StandardOutput.ReadLine());
                    }
                }
            }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            DialogResult result = file.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = file.FileName;
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    filePath = '"' + filePath + '"';
                    if (string.IsNullOrWhiteSpace(PasswordField.Text) && string.IsNullOrWhiteSpace(OutputField.Text))
                    {
                        var proc = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = "DECryptSuite.exe",
                                Arguments = $"-d -f {filePath}",
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                CreateNoWindow = true
                            }
                        };
                        proc.Start();
                        while (!proc.StandardOutput.EndOfStream)
                        {
                            Console.WriteLine(proc.StandardOutput.ReadLine());
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(PasswordField.Text) && string.IsNullOrWhiteSpace(OutputField.Text))
                    {
                        var proc = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = "DECryptSuite.exe",
                                Arguments = $"-d -f {filePath} -p {PasswordField.Text}",
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                CreateNoWindow = true
                            }
                        };
                        proc.Start();
                        while (!proc.StandardOutput.EndOfStream)
                        {
                            Console.WriteLine(proc.StandardOutput.ReadLine());
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(PasswordField.Text) && !string.IsNullOrWhiteSpace(OutputField.Text))
                    {
                        var proc = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = "DECryptSuite.exe",
                                Arguments = $"-d -f {filePath} -o {OutputField.Text}\\output",
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                CreateNoWindow = true
                            }
                        };
                        proc.Start();
                        while (!proc.StandardOutput.EndOfStream)
                        {
                            Console.WriteLine(proc.StandardOutput.ReadLine());
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(PasswordField.Text) && !string.IsNullOrWhiteSpace(OutputField.Text))
                    {
                        var proc = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = "DECryptSuite.exe",
                                Arguments = $"-d -f {filePath} -p {PasswordField.Text} -o {OutputField.Text}\\output",
                                UseShellExecute = false,
                                RedirectStandardOutput = true,
                                CreateNoWindow = true
                            }
                        };
                        proc.Start();
                        while (!proc.StandardOutput.EndOfStream)
                        {
                            Console.WriteLine(proc.StandardOutput.ReadLine());
                        }
                    }
                }
            }
        }
    }
}
