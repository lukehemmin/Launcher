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

            DialogResult dialogResult = MessageBox.Show("To install the game, you need 74GB of storage space. Do you want to continue?", "Insufficient storage space.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string downloadPath = Main.FolderDialog();

                if (!string.IsNullOrEmpty(downloadPath))
                {
                    if (GameDownloading == false)
                    {
                        Console.WriteLine("Game Downloading...");

                        if (Gamename == "Game1")
                        {
                            Game_num = 1;
                            Game_Link = Game1_Link;
                        }
                        else if (Gamename == "Game2")
                        {
                            Game_num = 2;
                            Game_Link = Game2_Link;
                        }

                        GameDownloading = true;

                        Download_Start(Game_num, Game_Link);
                    }
                }
            }
        }

        public void Download_Start(int Game_num, string Game_Link)
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
                client.DownloadFileAsync(uri, @"C:\path\to\save\file");
            }
        }

        public void test()
        {
            string downloadPath = Main.FolderDialog();

            if (!string.IsNullOrEmpty(downloadPath))
            {
                Console.WriteLine(downloadPath);
                int FreeSpaceGB = diskfreespace();
                Console.WriteLine(FreeSpaceGB + "GB");
            }
        }

        private int diskfreespace()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string driveLetter = Path.GetPathRoot(currentDirectory).Substring(0, 1);
            DriveInfo driveInfo = new DriveInfo(driveLetter);
            long freeSpaceBytes = driveInfo.AvailableFreeSpace;
            double freeSpaceGB = freeSpaceBytes / 1024.0 / 1024.0 / 1024.0;
            int freeSpaceGB_int = (int)freeSpaceGB;

            return freeSpaceGB_int;
        }
    }
}
