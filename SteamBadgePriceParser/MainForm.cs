using OpenQA.Selenium.Chrome;
using SteamBadgePriceParser.Elements;
using SteamBadgePriceParser.Properties;
using System.Globalization;

namespace SteamBadgePriceParser
{
    public partial class MainForm : Form
    {
        private Parser badgeParser;
        private SettingsObject settings;
        public List<GameData> GameDatas = new List<GameData>();
        public MainForm()
        {
            settings = new SettingsObject();
            if (File.Exists("UserSettings.json"))
            {
                settings.Load("UserSettings.json");
            }
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(settings.Language);

            InitializeComponent();
            
            badgeParser = new Parser(settings);
            badgeParser.StartDriver();
            listBox1.MouseWheelScroll += ScrollListBox_MouseWheelScroll;
            listBox2.MouseWheelScroll += ScrollListBox_MouseWheelScroll;
        }

        public void UpdateLocalization()
        {
            this.Controls.Clear();
            InitializeComponent();
            UpdateListboxes();
            listBox1.MouseWheelScroll += ScrollListBox_MouseWheelScroll;
            listBox2.MouseWheelScroll += ScrollListBox_MouseWheelScroll;
        }

            private void ScrollListBox_MouseWheelScroll(object sender, MouseEventArgs e)
        {
            listBox1.HandleScroll(e.Delta);
            listBox2.HandleScroll(e.Delta);
            vScrollBar1.Value = listBox2.TopIndex;
        }

        public void SettingsLabel_Click(object sender, EventArgs e)
        {
            SettingsPage sp = new SettingsPage(this, settings);
            sp.StartPosition = FormStartPosition.CenterParent;
            sp.ShowDialog(this);
            settings = sp.Settings;
        }

        private void FileLabel_Click(object sender, EventArgs e)
        {
            FileMenuStrip fms = new FileMenuStrip(this);
            fms.Location = new Point(FileLabel.Location.X, FileLabel.Location.Y + FileLabel.Height);

            Controls.Add(fms);
            Controls.SetChildIndex(fms, 0);
        }

        private async void SettingsLabel_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = SteamColors.HeaderText;
        }

        private async void SettingsLabel_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.White;
        }

        private async void SteamCardExchange_Click(object sender, EventArgs e)
        {
            badgeParser.Driver.Navigate().GoToUrl("https://www.steamcardexchange.net/index.php?badgeprices");
            await Task.Delay(10);
        }

        private void SteamCardExchange_MouseEnter(object sender, EventArgs e)
        {
            SteamCardExchange.ForeColor = Color.White;
            pictureBox1.BackgroundImage = Resources.exchangeLogoWhite;
        }

        private void SteamCardExchange_MouseLeave(object sender, EventArgs e)
        {
            SteamCardExchange.ForeColor = SteamColors.SecondaryText;
            pictureBox1.BackgroundImage = Resources.exchangeLogoGray;
        }

        private void splitter2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (splitter2.Location.X > panel3.Location.X - 20)
            {
                this.ClientSize = new Size(this.ClientSize.Width + (splitter2.Location.X - (panel3.Location.X - 20)), this.ClientSize.Height);
            }
        }

        private async void ParseGameIds_Click(object sender, EventArgs e)
        {
            GameDatas = badgeParser.GetAppIds();
            UpdateListboxes();
            vScrollBar1.Maximum = (GameDatas.Count - (listBox1.Height / listBox1.ItemHeight));
            await Task.Delay(10);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            badgeParser.Dispose();
        }

        private async void ParseGamePrices_Click(object sender, EventArgs e)
        {
            listBox2.DataSource = null;
            listBox2.Items.Clear();

            customProgressBar1.Maximum = listBox1.Items.Count - 1;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                List<string> prices = badgeParser.GetItemPrices(GameDatas[i].GetMarketUrl(foilCards.Checked));
                float summ = 0;
                foreach (string price in prices)
                {
                    summ += float.Parse(GetNumberFromPrice(price).Replace('.', ','));
                }
                listBox2.Items.Add(summ);
                GameDatas[i].price = summ;
                customProgressBar1.Value = i;
                ProgressLabel.Text = $"{i + 1}/{customProgressBar1.Maximum + 1}";
                await Task.Delay(settings.Delay);
            }
        }

        private string GetNumberFromPrice(string price)
        {
            string number = "";
            bool foundNumber = false;
            for (int i = 0; i < price.Length; i++)
            {
                if (price[i] >= '0' && price[i] <= '9')
                    foundNumber = true;
                if (foundNumber && !(price[i] >= '0' && price[i] <= '9' || price[i] == '.' || price[i] == ','))
                    break;
                if (foundNumber)
                    number += price[i];
            }
            return number;
        }

        public void UpdateListboxes()
        {
            listBox1.DataSource = GameDatas.Select(g => g.name).ToArray();
            listBox2.DataSource = GameDatas.Select((g) => g.price).ToArray();
        }

        private bool sortedByName = false;
        private bool sortedByPrice = false;
        private void gameNameButton_Click(object sender, EventArgs e)
        {
            if (!sortedByName)
            {
                GameDatas = GameDatas.OrderBy(g => g.name).ToList();
                gameNameButton.Image = Resources.triangle_up;
            }
            else
            {
                GameDatas = GameDatas.OrderByDescending(g => g.name).ToList();
                gameNameButton.Image = Resources.triangle_down;
            }

            sortedByName = !sortedByName;

            listBox1.DataSource = GameDatas.Select(g => g.name).ToArray();
            listBox2.DataSource = GameDatas.Select(g => g.price).ToArray();
        }

        private void gamePriceButton_Click(object sender, EventArgs e)
        {
            if (!sortedByPrice)
            {
                GameDatas = GameDatas.OrderBy(g => g.price).ToList();
                gamePriceButton.Image = Resources.triangle_up;
            }
            else
            {
                GameDatas = GameDatas.OrderByDescending(g => g.price).ToList();
                gamePriceButton.Image = Resources.triangle_down;
            }
            sortedByPrice = !sortedByPrice;

            UpdateListboxes();
        }

        private void marketToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
            {
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[2].Enabled = false;
                contextMenuStrip1.Items[3].Enabled = false;
            }
            else
            {
                contextMenuStrip1.Items[0].Enabled = true;
                contextMenuStrip1.Items[1].Enabled = true;
                if (listBox1.SelectedItems.Count > 1)
                {
                    contextMenuStrip1.Items[2].Enabled = false;
                    contextMenuStrip1.Items[3].Enabled = false;
                }
                else
                {
                    contextMenuStrip1.Items[2].Enabled = true;
                    contextMenuStrip1.Items[3].Enabled = true;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i))
                {
                    GameDatas.RemoveAt(i);
                }
            }
            UpdateListboxes();
        }

        private async void checkPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedItemsCounter = 0;
            customProgressBar1.Maximum = listBox1.SelectedItems.Count - 1;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (!listBox1.GetSelected(i))
                    continue;
                List<string> prices = badgeParser.GetItemPrices(GameDatas[i].GetMarketUrl(foilCards.Checked));
                float summ = 0;
                foreach (string price in prices)
                {
                    summ += float.Parse(GetNumberFromPrice(price).Replace('.', ','));
                }
                GameDatas[i].price = summ;
                customProgressBar1.Value = selectedItemsCounter;
                ProgressLabel.Text = $"{selectedItemsCounter + 1}/{listBox1.SelectedItems.Count}";
                selectedItemsCounter++;
                await Task.Delay(settings.Delay);
            }
            listBox2.DataSource = GameDatas.Select(g => g.price).ToArray();
        }

        private void marketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            badgeParser.Driver.Navigate().GoToUrl(GameDatas[listBox1.SelectedIndex].GetMarketUrl(foilCards.Checked));
        }

        private void sCExchangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            badgeParser.Driver.Navigate().GoToUrl(GameDatas[listBox1.SelectedIndex].GetExchangeUrl());
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            vScrollBar1.Maximum = GameDatas.Count - (listBox1.Size.Height / listBox1.ItemHeight);
            listBox1.TopIndex = vScrollBar1.Value;
            listBox2.TopIndex = vScrollBar1.Value;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != listBox2.Items.Count)
                return;
            if (((CustomListBox)sender).Name == listBox1.Name)
            {
                listBox2.SelectedIndexChanged -= listBox_SelectedIndexChanged;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox2.SetSelected(i, listBox1.GetSelected(i));
                }
                listBox2.SelectedIndexChanged += listBox_SelectedIndexChanged;
            }
            else
            {
                listBox1.SelectedIndexChanged -= listBox_SelectedIndexChanged;
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    listBox1.SetSelected(i, listBox2.GetSelected(i));
                }
                listBox1.SelectedIndexChanged += listBox_SelectedIndexChanged;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            GamePanel.Width = (int)((this.ClientSize.Width - 512) * 0.71f);
            PricePanel.Width = (int)((this.ClientSize.Width - 512) * 0.268f);
        }

        private async void reloadChromeButton_Click(object sender, EventArgs e)
        {
            badgeParser.UpdateSettings(settings);
            badgeParser.ReloadDriver();
            await Task.Delay(100);
        }
    }
}
