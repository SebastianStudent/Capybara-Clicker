using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CapybaraClicker
{
    public class MySettings
    {
        public static double[] ReadWindowProperties()
        {
            Properties.Settings settings = Properties.Settings.Default;
            double[] properties = new double[4];
            properties[0] = settings.Height;
            properties[1] = settings.Width;
            properties[2] = settings.Left;
            properties[3] = settings.Top;
            return properties;
        }

        public static double[] ReadMusicProperties()
        {
            Properties.Settings settings = Properties.Settings.Default;
            double[] properties = new double[2];
            properties[0] = settings.MenuSound;
            properties[1] = settings.SoundEffects;
            return properties;
        }

        public static string[] ReadValuesProperties()
        {
            Properties.Settings settings = Properties.Settings.Default;
            string[] properties = new string[3];
            properties[0] = settings.Coins;
            properties[1] = settings.ClickValue;
            properties[2] = settings.AutoClickValue;
            return properties;
        }

        public static string[] ReadWrapPanelProperties()
        {
            Properties.Settings settings = Properties.Settings.Default;
            string[] properties = new string[18];
            properties[0] = settings.Click1;
            properties[1] = settings.Auto1;
            properties[2] = settings.Click2;
            properties[3] = settings.Auto2;
            properties[4] = settings.Click3;
            properties[5] = settings.Auto3;
            properties[6] = settings.Click4;
            properties[7] = settings.Auto4;
            properties[8] = settings.Click5;
            properties[9] = settings.Auto5;
            properties[10] = settings.Click6;
            properties[11] = settings.Auto6;
            properties[12] = settings.Click7;
            properties[13] = settings.Auto7;
            properties[14] = settings.Click8;
            properties[15] = settings.Auto8;
            properties[16] = settings.Auto9;
            properties[17] = settings.Auto10;
            return properties;
        }

        public static DateTime ReadDateTimeProperties()
        {
            Properties.Settings settings = Properties.Settings.Default;
            DateTime offline = settings.OfflineDate;
            return offline;
        }

        public static void WriteWindowProperties(double[] arraySettings)
        {
            Properties.Settings settings = Properties.Settings.Default;
            settings.Height = arraySettings[0];
            settings.Width = arraySettings[1];
            settings.Left = arraySettings[2];
            settings.Top = arraySettings[3];
            settings.Save();
        }

        public static void WriteMusicProperties(double[] arraySettings)
        {
            Properties.Settings settings = Properties.Settings.Default;
            settings.MenuSound = arraySettings[0];
            settings.SoundEffects = arraySettings[1];
            settings.Save();
        }

        public static void WriteValuesProperties(string[] arraySettings)
        {
            Properties.Settings settings = Properties.Settings.Default;
            settings.Coins = arraySettings[0];
            settings.ClickValue = arraySettings[1];
            settings.AutoClickValue = arraySettings[2];
            settings.Save();
        }

        public static void WriteWrapPanelProperties(string[] arraySettings)
        {
            Properties.Settings settings = Properties.Settings.Default;
            settings.Click1 = arraySettings[0];
            settings.Auto1 = arraySettings[1];
            settings.Click2 = arraySettings[2];
            settings.Auto2 = arraySettings[3];
            settings.Click3 = arraySettings[4];
            settings.Auto3 = arraySettings[5];
            settings.Click4 = arraySettings[6];
            settings.Auto4 = arraySettings[7];
            settings.Click5 = arraySettings[8];
            settings.Auto5 = arraySettings[9];
            settings.Click6 = arraySettings[10];
            settings.Auto6 = arraySettings[11];
            settings.Click7 = arraySettings[12];
            settings.Auto7 = arraySettings[13];
            settings.Click8 = arraySettings[14];
            settings.Auto8 = arraySettings[15];
            settings.Auto9 = arraySettings[16];
            settings.Auto10 = arraySettings[17];
            settings.Save();
        }

        public static void WriteDateTimeProperties(DateTime offline)
        {
            Properties.Settings settings = Properties.Settings.Default;
            settings.OfflineDate = offline;
            settings.Save();
        }
    }
}
