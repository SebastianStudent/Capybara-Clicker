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
                _menuSoundPath = MenuSoundPath();
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
            _clickSoundPath = EffectSound_Bonk_Path();
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
            _cashSoundPath = EffectSound_Cash_Path();
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

        private static StringBuilder SoundsPath([CallerFilePath] string SoundBoardPath = "")
        {
            StringBuilder searchPath = new StringBuilder(SoundBoardPath);
            string fileName = Path.GetFileName(searchPath.ToString());
            searchPath.Remove(searchPath.Length - fileName.Length - 1,
                fileName.Length + 1);
            searchPath.Remove(Path.GetDirectoryName(searchPath.ToString()).Length,
                searchPath.Length - Path.GetDirectoryName(searchPath.ToString()).Length);
            return searchPath;
        }

        private static string MenuSoundPath()
        {
            string menuSoundPath = "\\Sounds\\The Capybara Song Official Music Video.wav";
            StringBuilder searchPath = SoundsPath();
            searchPath.Append(menuSoundPath);
            return searchPath.ToString();
        }

        private static string EffectSound_Cash_Path()
        {
            string menuSoundPath = "\\Sounds\\Cash money.wav";
            StringBuilder searchPath = SoundsPath();
            searchPath.Append(menuSoundPath);
            return searchPath.ToString();
        }

        private static string EffectSound_Bonk_Path()
        {
            string menuSoundPath = "\\Sounds\\Bonk.wav";
            StringBuilder searchPath = SoundsPath();
            searchPath.Append(menuSoundPath);
            return searchPath.ToString();
        }
    }
}
