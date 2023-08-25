using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CapybaraClicker
{
    public class Upgrade
    {
        static MainWindow window;
        public static event Action<BigInteger> CoinsUpdated;
        private static object MyLock = new object();

        public Upgrade(MainWindow mainwindow)
        {
            window = mainwindow;
        }
        public static void CapybaraClick()
        {
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    BigInteger currentCoins = BigInteger.Parse(window.CoinValue);
                    currentCoins = currentCoins + BigInteger.Parse(window.ClickValue);
                    window.CoinValue = currentCoins.ToString();
                });
            }
            catch
            {
                return;
            }
        }
        public static void CoinsIncrement()
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    lock (MyLock)
                    {
                        try
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                try
                                {
                                    BigInteger currentCoins = BigInteger.Parse(window.CoinValue);
                                    currentCoins = currentCoins + BigInteger.Parse(window.AutoClickValue);
                                    window.CoinValue = currentCoins.ToString();
                                }
                                catch (NullReferenceException)
                                {
                                    return;
                                }
                            });
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
            });
        }
        public static void ClickUpgrade(TextBlock textBlockClickValue, TextBlock textBlockCostValue, TextBlock textBlockUpgrade)
        {
            try
            {

                Application.Current.Dispatcher.Invoke(() =>
                {
                    BigInteger currentCoins = BigInteger.Parse(window.CoinValue);
                    BigInteger cost = BigInteger.Parse(textBlockCostValue.Text);
                    if (cost > currentCoins)
                    {
                        return;
                    }
                    textBlockUpgrade.Text = (Int32.Parse(textBlockUpgrade.Text) + 1).ToString();
                    currentCoins -= cost;
                    window.CoinValue = currentCoins.ToString();
                    BigInteger currentClickValue = BigInteger.Parse(window.ClickValue);
                    BigInteger clickvalue = BigInteger.Parse(textBlockClickValue.Text);
                    currentClickValue += clickvalue;
                    window.ClickValue = currentClickValue.ToString();
                    SoundBoard.CashSound();
                });
            }
            catch
            {
                return;
            }
        }
        public static void AutoClickUpgrade(TextBlock textBlockAutoClickValue, TextBlock textBlockCostValue, TextBlock textBlockUpgrade)
        {
            try
            {

                Application.Current.Dispatcher.Invoke(() =>
                {
                    BigInteger currentCoins = BigInteger.Parse(window.CoinValue);
                    BigInteger cost = BigInteger.Parse(textBlockCostValue.Text);
                    if (cost > currentCoins)
                    {
                        return;
                    }
                    textBlockUpgrade.Text = (Int32.Parse(textBlockUpgrade.Text) + 1).ToString();
                    currentCoins -= cost;
                    window.CoinValue = currentCoins.ToString();
                    BigInteger currentAutoClickValue = BigInteger.Parse(window.AutoClickValue);
                    BigInteger autoClickvalue = BigInteger.Parse(textBlockAutoClickValue.Text);
                    currentAutoClickValue += autoClickvalue;
                    window.AutoClickValue = currentAutoClickValue.ToString();
                    SoundBoard.CashSound();
                });
            }
            catch
            {
                return;
            }
        }
    }
}
