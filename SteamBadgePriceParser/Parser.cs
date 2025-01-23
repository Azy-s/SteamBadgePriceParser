using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamBadgePriceParser
{
    public class Parser
    {
        private ChromeOptions options = new ChromeOptions();
        public ChromeDriver driver;
        public string User { get; set; }
        public string ChromeDir { get; set; }
        public bool GUIMode { get; set; }
        public bool SandboxMode { get; set; }
        public int Delay {  get; set; }

        public Parser() 
        {
            User = "Default";
            ChromeDir = $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\Google\\Chrome\\User Data";
            SandboxMode = false;
            GUIMode = false;
            SetOpitons();
        }

        public Parser(SettingsObject settings)
        {
            this.User = settings.UserName;
            this.ChromeDir = settings.UserDataDir;
            this.GUIMode = settings.GUIMode;
            this.SandboxMode = settings.SandboxMode;
            this.Delay = settings.Delay;
            SetOpitons();
        }

        public void UpdateSettings(SettingsObject settings)
        {
            this.User = settings.UserName;
            this.ChromeDir = settings.UserDataDir;
            this.GUIMode = settings.GUIMode;
            this.SandboxMode = settings.SandboxMode;
            this.Delay = settings.Delay;
            options = new ChromeOptions();
            SetOpitons();
        }
        public bool StartDriver()
        {
            try
            {
                driver = new ChromeDriver(options);
                return true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Close Chrome Browser\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool ReloadDriver()
        {
            Dispose();
            Thread.Sleep(100);
            try
            {
                driver = new ChromeDriver(options);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Close Chrome Browser\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void SetOpitons()
        {
            options.AddArgument(@$"user-data-dir={ChromeDir}");
            options.AddArgument($"--profile-directory={User}");
            if (!SandboxMode)
                options.AddArgument("--no-sandbox");
            if (!GUIMode)
            {
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");
            }
            options.AddArgument("--log-level=3");
        }

        public void Dispose()
        {
            try
            {
                driver.Close();
            }
            catch { }
            driver.Dispose();
        }


        public List<string> GetItemPrices(string url)
        {
            var prices = new List<string>();
            // Запуск 
            try
            {
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(Delay);

                //поиска элемента по цене
                var priceElements = driver.FindElements(By.XPath("//span[@class='normal_price']")); 

                foreach (var element in priceElements)
                {
                    prices.Add(element.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            return prices;
        }

        public List<GameData> GetAppIds()
        {
            List<GameData> data = new List<GameData>();
            // Запуск 
            try
            {
                // Открытие страницы
                driver.Navigate().GoToUrl("https://www.steamcardexchange.net/index.php?badgeprices");

                Thread.Sleep(1000);

                var list = driver.FindElements(By.CssSelector("a[href*='/index.php?gamepage-appid-']"));

                for (int i = 0; i < list.Count; i++)
                {
                    data.Add(new GameData(ExtractAppId(list[i].GetAttribute("href")), list[i].Text.Trim()));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            return data;
        }

        private string ExtractAppId(string url)
        {
            // Извлекаем appid из URL
            string[] parts = url.Split('-');
            if (parts.Length < 1)
                return null;

            return parts[parts.Length - 1];
        }
    }
}
