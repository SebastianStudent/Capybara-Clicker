using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Numerics;
using System.Diagnostics;

namespace CapybaraClicker
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double[] _windowSettings = new double[6];
        private string[] _valuesSettings = new string[3];
        private string[] _wrapPanelSettings = new string[18];
        public Upgrade upgrade;
        public static string CurrentAutoClickValue;
        public static string CurrentClickValue;
        public static string CurrentCoinValue;

        public string CoinValue
        {
            set { CoinsValue.Text = value; }
            get { return CoinsValue.Text; }
        }

        public string ClickValue
        {
            set { ClicksValue.Text = value; }
            get { return ClicksValue.Text; }
        }

        public string AutoClickValue
        {
            set { AutoClicksValue.Text = value; }
            get { return AutoClicksValue.Text; }
        }

        public MainWindow()
        {
            InitializeComponent();
            upgrade = new Upgrade(this);
            WindowSetting();
            ValuesSetting();
            WrapPanelSetting();
            DateTime dateTime = DateTime.Now;
            OfflineCalculate(dateTime);
        }

        private void WindowSetting()
        {
            _windowSettings = MySettings.ReadWindowProperties();
            Height = _windowSettings[0];
            Width = _windowSettings[1];
            Left = _windowSettings[2];
            Top = _windowSettings[3];
        }

        private void ValuesSetting()
        {
            _valuesSettings = MySettings.ReadValuesProperties();
            CoinsValue.Text = _valuesSettings[0];
            ClicksValue.Text = _valuesSettings[1];
            AutoClicksValue.Text = _valuesSettings[2];
        }

        private void WrapPanelSetting()
        {
            _wrapPanelSettings = MySettings.ReadWrapPanelProperties();
            if (BorderContainer is StackPanel stackPanel)
            {
                int i = 0;
                foreach (var item in BorderContainer.Children)
                {
                    if (item is Border border
                        && border.Child is WrapPanel wrapPanel
                        && wrapPanel.Children[0] is Grid grid)
                    {
                        if (grid.Children[2] is TextBlock textBlock)
                        {
                            textBlock.Text = _wrapPanelSettings[i];
                            i++;
                        }
                    }
                }
            }
        }

        private void OfflineCalculate(DateTime nowDate)
        {
            DateTime lastdate = MySettings.ReadDateTimeProperties();
            TimeSpan timeDifference = nowDate - lastdate;
            BigInteger secondsDifference = (BigInteger)timeDifference.TotalSeconds;
            try
            {
                BigInteger currentCoins = BigInteger.Parse(CoinValue);
                BigInteger offlineCoins  = secondsDifference * BigInteger.Parse(AutoClickValue);
                MessageBox.Show("Offline earn\n" + offlineCoins);
                CoinValue = (currentCoins + offlineCoins).ToString();
            }
            catch
            {
                MessageBox.Show("Maximum value of Coins");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SoundBoard.MenuSound();
            Thread thread_upgrade = new Thread(Upgrade.CoinsIncrement);
            thread_upgrade.Start();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _windowSettings[0] = Height;
            _windowSettings[1] = Width;
            _windowSettings[2] = Left;
            _windowSettings[3] = Top;
            MySettings.WriteWindowProperties(_windowSettings);
            _valuesSettings[0] = CoinValue;
            _valuesSettings[1] = ClickValue;
            _valuesSettings[2] = AutoClickValue;
            MySettings.WriteValuesProperties(_valuesSettings);
            int i = 0;
            foreach (var item in BorderContainer.Children)
            {
                if (item is Border border
                    && border.Child is WrapPanel wrapPanel
                    && wrapPanel.Children[0] is Grid grid)
                {
                    if (grid.Children[2] is TextBlock textBlock)
                    {
                        _wrapPanelSettings[i] = textBlock.Text;
                        i++;
                    }
                }
            }
            MySettings.WriteWrapPanelProperties(_wrapPanelSettings);
            MySettings.WriteDateTimeProperties(DateTime.Now);
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                Cursor customCursor = new Cursor(CursorImagePointPath());
                Cursor = customCursor;
                Thickness newMargin = ImageClicker.Margin;
                newMargin.Top -= 10;
                newMargin.Bottom -= 10;
                newMargin.Left -= 10;
                newMargin.Right -= 10;
                ImageClicker.Margin = newMargin;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cursor: " + ex.Message);
            }
        }

        private void CapybaraWindow_MouseEnter(object sender, MouseEventArgs e)
        {
            try
            {
                Cursor customCursor = new Cursor(CursorImageNormalPath());
                Cursor = customCursor;
                Thickness newMargin = ImageClicker.Margin;
                newMargin.Top = 0;
                newMargin.Bottom = 0;
                newMargin.Left = 0;
                newMargin.Right = 0;
                ImageClicker.Margin = newMargin;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cursor: " + ex.Message);
            }
        }

        private static StringBuilder CursorImagePath([CallerFilePath] string CursorPath = "")
        {
            StringBuilder searchPath = new StringBuilder(CursorPath);
            string fileName = Path.GetFileName(searchPath.ToString());
            searchPath.Remove(searchPath.Length - fileName.Length - 1,
                fileName.Length + 1);
            searchPath.Remove(Path.GetDirectoryName(searchPath.ToString()).Length,
                searchPath.Length - Path.GetDirectoryName(searchPath.ToString()).Length);
            return searchPath;
        }

        private static string CursorImagePointPath()
        {
            StringBuilder searchPath = CursorImagePath();
            string CursorPath = "\\Images\\cute-capybara-pointer.cur";
            searchPath.Append(CursorPath);
            return searchPath.ToString();
        }

        private static string CursorImageNormalPath()
        {
            StringBuilder searchPath = CursorImagePath();
            string CursorPath = "\\Images\\cute-capybara-cursor.cur";
            searchPath.Append(CursorPath);
            return searchPath.ToString();
        }

        private void ImageClicker_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Thread thread_click = new Thread(Upgrade.CapybaraClick);
            thread_click.Start();
            SoundBoard.ClickSound();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SoundPanel soundPanel = new SoundPanel(this);
            soundPanel.ShowDialog();
        }

        private void WrapPanelClick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is WrapPanel wrappanel)
            {
                if (wrappanel.Children[0] is Grid grid && grid.Children.Count > 1)
                {
                    if (grid.Children[1] is StackPanel stackpanel && grid.Children[2] is TextBlock textBlockUpgrade)
                    {
                        if (stackpanel.Children[1] is TextBlock textBlockClickValue && stackpanel.Children[2] is TextBlock textBlockCostValue)
                        {
                            Upgrade.ClickUpgrade(textBlockClickValue, textBlockCostValue, textBlockUpgrade);
                        }
                    }
                }
            }
        }
        private void WrapPanelAutoClick_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is WrapPanel wrappanel)
            {
                if (wrappanel.Children[0] is Grid grid && grid.Children.Count > 1)
                {
                    if (grid.Children[1] is StackPanel stackpanel && grid.Children[2] is TextBlock textBlockUpgrade)
                    {
                        if (stackpanel.Children[1] is TextBlock textBlockAutoClickValue && stackpanel.Children[2] is TextBlock textBlockCostValue)
                        {
                            Upgrade.AutoClickUpgrade(textBlockAutoClickValue, textBlockCostValue, textBlockUpgrade);
                        }
                    }
                }
            }
        }
    }
}
