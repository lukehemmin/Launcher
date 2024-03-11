using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Launcher.MainScreen;

namespace Launcher.Codes_Folder
{
    internal class Game_Download
    {
        public event Action<int, int> DownloadProgressChanged;

        private string Game1_Link = "https://cdn.lukehemmin.com/game/Game1.zip";
        private string Game2_Link = "https://cdn.lukehemmin.com/game/Game2.zip";
        private Boolean GameDownloading = false;

        public void Button_Click(string Gamename)
        {
            int Game_num = 0;
            string Game_Link = "";
            int Game_Size = 0;
            int Game1_Size = 74;
            int Game2_Size = 20;

            if (Gamename == "Game1")
            {
                Game_Size = Game1_Size;
                Game_num = 1;
                Game_Link = Game1_Link;
            }
            else if (Gamename == "Game2")
            {
                Game_Size = Game2_Size;
                Game_num = 2;
                Game_Link = Game2_Link;
            }

            DialogResult dialogResult = MessageBox.Show("To install the game, you need " + Game_Size + "GB of storage space. Do you want to continue?", "Insufficient storage space.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string downloadPath = Main.FolderDialog();

                int FreeSpaceGB = diskfreespace(downloadPath);

                if (FreeSpaceGB > Game_Size)
                {
                    if (!string.IsNullOrEmpty(downloadPath))
                    {
                        if (GameDownloading == false)
                        {
                            Console.WriteLine("Game Downloading...");

                            GameDownloading = true;

                            Download_Start(Game_num, Game_Link, downloadPath);
                        }
                    }
                }
                else
                {
                    DialogResult dialogResult2 = MessageBox.Show("Not enough storage space. Unable to download. \nPlease free up space and try again.\nThe required storage space: " + Game_Size + "GB", "Insufficient storage space.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        Console.WriteLine("Not enough storage space.");
                    }
                }
            }
        }

        public void Download_Start(int Game_num, string Game_Link, string downloadPath)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += (s, e) =>
                {
                    // Trigger the event instead of accessing the ProgressBar directly
                    DownloadProgressChanged?.Invoke(Game_num, e.ProgressPercentage);
                };

                client.DownloadFileCompleted += (s, e) =>
                {
                    GameDownloading = false;
                    Console.WriteLine("Download Complete!");
                };

                Uri uri = new Uri(Game_Link);
                client.DownloadFileAsync(uri, downloadPath);
            }
        }

        private int diskfreespace(string downloadPath)
        {
            string driveLetter = Path.GetPathRoot(downloadPath).Substring(0, 1);
            DriveInfo driveInfo = new DriveInfo(driveLetter);
            long freeSpaceBytes = driveInfo.AvailableFreeSpace;
            double freeSpaceGB = freeSpaceBytes / 1024.0 / 1024.0 / 1024.0;
            int freeSpaceGB_int = (int)freeSpaceGB;

            return freeSpaceGB_int;
        }

        public void test()
        {
            string downloadPath = Main.FolderDialog();

            if (!string.IsNullOrEmpty(downloadPath))
            {
                Console.WriteLine(downloadPath);
                int FreeSpaceGB = diskfreespace(downloadPath);
                Console.WriteLine(FreeSpaceGB + "GB");
            }
        }
    }
}
