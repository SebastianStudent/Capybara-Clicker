using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.IO;
using System.Windows;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Media;
using System.Windows.Controls;

namespace CapybaraClicker
{
    public class SoundBoard
    {
        public static MediaPlayer player;
        private static MediaPlayer soundCash;
        private static MediaPlayer soundClick;
        private static string _menuSoundPath;
        private static string _clickSoundPath;
        private static string _cashSoundPath;
        private static Properties.Settings settings = Properties.Settings.Default;
        public static double volumeSound = settings.SoundEffects;

        public static void MenuSound()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _menuSoundPath = SoundsPath("The Capybara Song Official Music Video.wav");
                //MessageBox.Show(_menuSoundPath);
                if (!File.Exists(Path.GetFullPath(_menuSoundPath)))
                {
                    MessageBox.Show("Music doesn't exist.\n" +
                        "Restart application if you want have to music.", "Music Error!");
                    return;
                }
                try
                {
                    player = new MediaPlayer();
                    settings = Properties.Settings.Default;
                    player.Volume = settings.MenuSound;
                    player.Open(new Uri(_menuSoundPath));
                    player.MediaEnded += new EventHandler(Player_Ended);
                    player.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Threre is problem with music.\n" +
                        "Restart application if you want have to music.\n" + ex, "Music Error!");
                }
            });
        }

        public static void Player_Ended(object sender, EventArgs e)
        {
            player.Volume = settings.MenuSound;
            player.Open(new Uri(_menuSoundPath));
            player.Play();
        }

        public static void ClickSound()
        {
            _clickSoundPath = SoundsPath("Bonk.wav");
            if (!File.Exists(Path.GetFullPath(_clickSoundPath)))
            {
                MessageBox.Show("Music doesn't exist.\n" +
                    "Restart application if you want have to music.", "Music Error!");
                return;
            }
            try
            {
                soundClick = new MediaPlayer();
                settings = Properties.Settings.Default;
                soundClick.Volume = volumeSound;
                soundClick.Open(new Uri(_clickSoundPath));
                soundClick.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Threre is problem with music.\n" +
                    "Restart application if you want have to music.\n" + ex, "Music Error!");
            }
        }

        public static void CashSound()
        {
            _cashSoundPath = SoundsPath("Cash money.wav");
            if (!File.Exists(Path.GetFullPath(_cashSoundPath)))
            {
                MessageBox.Show("Music doesn't exist.\n" +
                    "Restart application if you want have to music.", "Music Error!");
                return;
            }
            try
            {
                soundCash = new MediaPlayer();
                settings = Properties.Settings.Default;
                soundCash.Volume = volumeSound;
                soundCash.Open(new Uri(_cashSoundPath));
                soundCash.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Threre is problem with music.\n" +
                    "Restart application if you want have to music.\n" + ex, "Music Error!");
            }
        }

        private static string SoundsPath(string filename/*[CallerFilePath] string SoundBoardPath = ""*/)
        {
            //StringBuilder searchPath = new StringBuilder(SoundBoardPath);
            //string fileName = Path.GetFileName(searchPath.ToString());
            //searchPath.Remove(searchPath.Length - fileName.Length - 1,
            //    fileName.Length + 1);
            //searchPath.Remove(Path.GetDirectoryName(searchPath.ToString()).Length,
            //    searchPath.Length - Path.GetDirectoryName(searchPath.ToString()).Length);

            //string fileNameToSearch = "Cash money.wav";
            //string[] allDrives = Directory.GetLogicalDrives();
            //foreach (string drive in allDrives)
            //{
            //    try
            //    {
            //        string[] files = Directory.GetFiles(drive, fileNameToSearch, SearchOption.AllDirectories);

            //        if (files.Length > 0)
            //        {
            //            string filePath = files[0];
            //            MessageBox.Show("Znaleziono plik: " + filePath);
            //            break;
            //        }
            //    }
            //    catch (UnauthorizedAccessException)
            //    {
            //        continue;
            //    }
            //}
            string targetFileName = filename;
            string[] drives = Environment.GetLogicalDrives();
            string filepath = "";

            foreach (string drive in drives)
            {
                try
                {
                    string rootPath = Path.GetPathRoot(drive);
                    string[] files = Directory.GetFiles(rootPath, targetFileName, SearchOption.AllDirectories);

                    foreach (string file in files)
                    {
                        MessageBox.Show("Znaleziono plik: " + file);
                        filepath = file;
                    }
                }
                catch (UnauthorizedAccessException)
                {

                }
            }
            return filepath;
        }

        private static string MenuSoundPath()
        {
            //string menuSoundPath = "\\Sounds\\The Capybara Song Official Music Video.wav";
            //StringBuilder searchPath = SoundsPath();
            //searchPath.Append(menuSoundPath);
            //return searchPath.ToString();
            string targetFileName = "The Capybara Song Official Music Video.wav";
            string[] drives = Environment.GetLogicalDrives();
            string filepath = "";

            foreach (string drive in drives)
            {
                try
                {
                    string rootPath = Path.GetPathRoot(drive);
                    string[] files = Directory.GetFiles(rootPath, targetFileName, SearchOption.AllDirectories);

                    foreach (string file in files)
                    {
                        MessageBox.Show("Znaleziono plik: " + file);
                        filepath = file;
                    }
                }
                catch (UnauthorizedAccessException)
                {

                }
            }
            return filepath;
        }

        private static string EffectSound_Cash_Path()
        {
            //string menuSoundPath = "\\Sounds\\Cash money.wav";
            //StringBuilder searchPath = SoundsPath();
            //searchPath.Append(menuSoundPath);
            //return searchPath.ToString();

            string targetFileName = "Cash money.wav";
            string[] drives = Environment.GetLogicalDrives();
            string filepath = "";

            foreach (string drive in drives)
            {
                try
                {
                    string rootPath = Path.GetPathRoot(drive);
                    string[] files = Directory.GetFiles(rootPath, targetFileName, SearchOption.AllDirectories);

                    foreach (string file in files)
                    {
                        MessageBox.Show("Znaleziono plik: " + file);
                        filepath = file;
                    }
                }
                catch (UnauthorizedAccessException)
                {

                }
            }
            return filepath;
        }

        private static string EffectSound_Bonk_Path()
        {
            //string menuSoundPath = "\\Sounds\\Bonk.wav";
            //StringBuilder searchPath = SoundsPath();
            //searchPath.Append(menuSoundPath);
            //return searchPath.ToString();
            string targetFileName = "Bonk.wav";
            string[] drives = Environment.GetLogicalDrives();
            string filepath = "";

            foreach (string drive in drives)
            {
                try
                {
                    string rootPath = Path.GetPathRoot(drive);
                    string[] files = Directory.GetFiles(rootPath, targetFileName, SearchOption.AllDirectories);

                    foreach (string file in files)
                    {
                        MessageBox.Show("Znaleziono plik: " + file);
                        filepath = file;
                    }
                }
                catch (UnauthorizedAccessException)
                {

                }
            }
            return filepath;
        }
    }
}
