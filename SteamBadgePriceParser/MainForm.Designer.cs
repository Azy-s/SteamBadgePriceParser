using SteamBadgePriceParser.Elements;

namespace SteamBadgePriceParser
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            customProgressBar1 = new CustomProgressBar();
            ProgressLabel = new Label();
            SteamCardExchange = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            FileLabel = new Label();
            SettingsLabel = new Label();
            listBox1 = new CustomListBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            checkPriceToolStripMenuItem = new ToolStripMenuItem();
            marketToolStripMenuItem = new ToolStripMenuItem();
            sCExchangeToolStripMenuItem = new ToolStripMenuItem();
            splitter1 = new Splitter();
            listBox2 = new CustomListBox();
            splitter2 = new Splitter();
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            label2 = new Label();
            panel3 = new Panel();
            label3 = new Label();
            foilCards = new CustomCheckBox();
            GamePanel = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            gameNameButton = new Button();
            PricePanel = new Panel();
            panel9 = new Panel();
            panel8 = new Panel();
            gamePriceButton = new Button();
            vScrollBar1 = new CustomVScrollBar();
            reloadChromeButton = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            GamePanel.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            PricePanel.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.FromArgb(23, 29, 37);
            panel1.Controls.Add(customProgressBar1);
            panel1.Controls.Add(ProgressLabel);
            panel1.Controls.Add(SteamCardExchange);
            panel1.Controls.Add(pictureBox1);
            panel1.Name = "panel1";
            // 
            // customProgressBar1
            // 
            resources.ApplyResources(customProgressBar1, "customProgressBar1");
            customProgressBar1.ForeColor = Color.FromArgb(25, 153, 255);
            customProgressBar1.Name = "customProgressBar1";
            // 
            // ProgressLabel
            // 
            resources.ApplyResources(ProgressLabel, "ProgressLabel");
            ProgressLabel.Name = "ProgressLabel";
            // 
            // SteamCardExchange
            // 
            resources.ApplyResources(SteamCardExchange, "SteamCardExchange");
            SteamCardExchange.BackColor = Color.Transparent;
            SteamCardExchange.Cursor = Cursors.Hand;
            SteamCardExchange.Name = "SteamCardExchange";
            SteamCardExchange.Click += SteamCardExchange_Click;
            SteamCardExchange.MouseEnter += SteamCardExchange_MouseEnter;
            SteamCardExchange.MouseLeave += SteamCardExchange_MouseLeave;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.BackgroundImage = Properties.Resources.exchangeLogoGray;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            pictureBox1.Click += SteamCardExchange_Click;
            pictureBox1.MouseEnter += SteamCardExchange_MouseEnter;
            pictureBox1.MouseLeave += SteamCardExchange_MouseLeave;
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.BackColor = Color.FromArgb(23, 29, 37);
            panel2.Controls.Add(FileLabel);
            panel2.Controls.Add(SettingsLabel);
            panel2.ForeColor = Color.FromArgb(139, 146, 154);
            panel2.Name = "panel2";
            // 
            // FileLabel
            // 
            resources.ApplyResources(FileLabel, "FileLabel");
            FileLabel.Cursor = Cursors.Hand;
            FileLabel.Name = "FileLabel";
            FileLabel.Click += FileLabel_Click;
            FileLabel.MouseEnter += SettingsLabel_MouseEnter;
            FileLabel.MouseLeave += SettingsLabel_MouseLeave;
            // 
            // SettingsLabel
            // 
            resources.ApplyResources(SettingsLabel, "SettingsLabel");
            SettingsLabel.Cursor = Cursors.Hand;
            SettingsLabel.Name = "SettingsLabel";
            SettingsLabel.Click += SettingsLabel_Click;
            SettingsLabel.MouseEnter += SettingsLabel_MouseEnter;
            SettingsLabel.MouseLeave += SettingsLabel_MouseLeave;
            // 
            // listBox1
            // 
            resources.ApplyResources(listBox1, "listBox1");
            listBox1.BackColor = Color.FromArgb(36, 40, 47);
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.ContextMenuStrip = contextMenuStrip1;
            listBox1.ForeColor = Color.FromArgb(202, 205, 212);
            listBox1.FormattingEnabled = true;
            listBox1.Name = "listBox1";
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            listBox1.SelectedIndexChanged += listBox_SelectedIndexChanged;
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem, checkPriceToolStripMenuItem, marketToolStripMenuItem, sCExchangeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Opened += marketToolStripMenuItem_DropDownOpening;
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(deleteToolStripMenuItem, "deleteToolStripMenuItem");
            deleteToolStripMenuItem.Image = Properties.Resources.delete_element;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // checkPriceToolStripMenuItem
            // 
            resources.ApplyResources(checkPriceToolStripMenuItem, "checkPriceToolStripMenuItem");
            checkPriceToolStripMenuItem.Image = Properties.Resources._172527_price_tag_euro_icon;
            checkPriceToolStripMenuItem.Name = "checkPriceToolStripMenuItem";
            checkPriceToolStripMenuItem.Click += checkPriceToolStripMenuItem_Click;
            // 
            // marketToolStripMenuItem
            // 
            resources.ApplyResources(marketToolStripMenuItem, "marketToolStripMenuItem");
            marketToolStripMenuItem.Image = Properties.Resources._2849824_store_shopping_market_buy_shop_icon;
            marketToolStripMenuItem.Name = "marketToolStripMenuItem";
            marketToolStripMenuItem.DropDownOpening += marketToolStripMenuItem_DropDownOpening;
            marketToolStripMenuItem.Click += marketToolStripMenuItem_Click;
            // 
            // sCExchangeToolStripMenuItem
            // 
            resources.ApplyResources(sCExchangeToolStripMenuItem, "sCExchangeToolStripMenuItem");
            sCExchangeToolStripMenuItem.Image = Properties.Resources.exchangeLogoGray;
            sCExchangeToolStripMenuItem.Name = "sCExchangeToolStripMenuItem";
            sCExchangeToolStripMenuItem.Click += sCExchangeToolStripMenuItem_Click;
            // 
            // splitter1
            // 
            resources.ApplyResources(splitter1, "splitter1");
            splitter1.BackColor = Color.FromArgb(23, 29, 37);
            splitter1.Name = "splitter1";
            splitter1.TabStop = false;
            splitter1.SplitterMoved += splitter2_SplitterMoved;
            // 
            // listBox2
            // 
            resources.ApplyResources(listBox2, "listBox2");
            listBox2.BackColor = Color.FromArgb(36, 40, 47);
            listBox2.BorderStyle = BorderStyle.None;
            listBox2.ContextMenuStrip = contextMenuStrip1;
            listBox2.ForeColor = Color.FromArgb(202, 205, 212);
            listBox2.FormattingEnabled = true;
            listBox2.Name = "listBox2";
            listBox2.SelectionMode = SelectionMode.MultiExtended;
            listBox2.SelectedIndexChanged += listBox_SelectedIndexChanged;
            // 
            // splitter2
            // 
            resources.ApplyResources(splitter2, "splitter2");
            splitter2.BackColor = Color.FromArgb(23, 29, 37);
            splitter2.Name = "splitter2";
            splitter2.TabStop = false;
            splitter2.SplitterMoved += splitter2_SplitterMoved;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.BackColor = Color.FromArgb(41, 46, 54);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 88, 99);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 77, 88);
            button1.ForeColor = Color.FromArgb(224, 224, 224);
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ParseGameIds_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.FromArgb(225, 227, 229);
            label1.Name = "label1";
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.BackColor = Color.FromArgb(41, 46, 54);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(80, 88, 99);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 77, 88);
            button2.ForeColor = Color.FromArgb(224, 224, 224);
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = false;
            button2.Click += ParseGamePrices_Click;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = Color.FromArgb(225, 227, 229);
            label2.Name = "label2";
            // 
            // panel3
            // 
            resources.ApplyResources(panel3, "panel3");
            panel3.BackColor = Color.FromArgb(56, 58, 68);
            panel3.ForeColor = Color.FromArgb(29, 31, 37);
            panel3.Name = "panel3";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = Color.FromArgb(225, 227, 229);
            label3.Name = "label3";
            // 
            // foilCards
            // 
            resources.ApplyResources(foilCards, "foilCards");
            foilCards.FlatAppearance.BorderSize = 0;
            foilCards.FlatAppearance.CheckedBackColor = Color.Transparent;
            foilCards.FlatAppearance.MouseDownBackColor = Color.Transparent;
            foilCards.FlatAppearance.MouseOverBackColor = Color.Transparent;
            foilCards.Name = "foilCards";
            foilCards.UseVisualStyleBackColor = true;
            // 
            // GamePanel
            // 
            resources.ApplyResources(GamePanel, "GamePanel");
            GamePanel.BackColor = Color.FromArgb(36, 40, 47);
            GamePanel.Controls.Add(panel6);
            GamePanel.Controls.Add(panel5);
            GamePanel.Name = "GamePanel";
            // 
            // panel6
            // 
            resources.ApplyResources(panel6, "panel6");
            panel6.Controls.Add(listBox1);
            panel6.Name = "panel6";
            // 
            // panel5
            // 
            resources.ApplyResources(panel5, "panel5");
            panel5.Controls.Add(gameNameButton);
            panel5.Name = "panel5";
            // 
            // gameNameButton
            // 
            resources.ApplyResources(gameNameButton, "gameNameButton");
            gameNameButton.BackColor = Color.FromArgb(33, 37, 44);
            gameNameButton.FlatAppearance.BorderSize = 0;
            gameNameButton.ForeColor = Color.FromArgb(223, 227, 238);
            gameNameButton.Image = Properties.Resources.triangle_down;
            gameNameButton.Name = "gameNameButton";
            gameNameButton.UseVisualStyleBackColor = false;
            gameNameButton.Click += gameNameButton_Click;
            // 
            // PricePanel
            // 
            resources.ApplyResources(PricePanel, "PricePanel");
            PricePanel.BackColor = Color.FromArgb(36, 40, 47);
            PricePanel.Controls.Add(panel9);
            PricePanel.Controls.Add(panel8);
            PricePanel.Name = "PricePanel";
            // 
            // panel9
            // 
            resources.ApplyResources(panel9, "panel9");
            panel9.Controls.Add(listBox2);
            panel9.Name = "panel9";
            // 
            // panel8
            // 
            resources.ApplyResources(panel8, "panel8");
            panel8.Controls.Add(gamePriceButton);
            panel8.Name = "panel8";
            // 
            // gamePriceButton
            // 
            resources.ApplyResources(gamePriceButton, "gamePriceButton");
            gamePriceButton.BackColor = Color.FromArgb(33, 37, 44);
            gamePriceButton.FlatAppearance.BorderSize = 0;
            gamePriceButton.ForeColor = Color.FromArgb(223, 227, 238);
            gamePriceButton.Image = Properties.Resources.triangle_down;
            gamePriceButton.Name = "gamePriceButton";
            gamePriceButton.UseVisualStyleBackColor = false;
            gamePriceButton.Click += gamePriceButton_Click;
            // 
            // vScrollBar1
            // 
            resources.ApplyResources(vScrollBar1, "vScrollBar1");
            vScrollBar1.ArrowColor = Color.FromArgb(53, 58, 63);
            vScrollBar1.BorderColor = Color.Transparent;
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.ThumbColor = Color.FromArgb(68, 71, 77);
            vScrollBar1.TrackColor = Color.FromArgb(40, 40, 40);
            vScrollBar1.ValueChanged += vScrollBar1_ValueChanged;
            // 
            // reloadChromeButton
            // 
            resources.ApplyResources(reloadChromeButton, "reloadChromeButton");
            reloadChromeButton.BackColor = Color.Brown;
            reloadChromeButton.FlatAppearance.BorderSize = 0;
            reloadChromeButton.FlatAppearance.MouseDownBackColor = Color.DarkRed;
            reloadChromeButton.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            reloadChromeButton.ForeColor = Color.FromArgb(224, 224, 224);
            reloadChromeButton.Name = "reloadChromeButton";
            reloadChromeButton.UseVisualStyleBackColor = false;
            reloadChromeButton.Click += reloadChromeButton_Click;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 31, 41);
            Controls.Add(vScrollBar1);
            Controls.Add(splitter2);
            Controls.Add(PricePanel);
            Controls.Add(splitter1);
            Controls.Add(GamePanel);
            Controls.Add(foilCards);
            Controls.Add(panel3);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(reloadChromeButton);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.FromArgb(103, 112, 123);
            Name = "MainForm";
            FormClosed += MainForm_FormClosed;
            Resize += MainForm_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            GamePanel.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            PricePanel.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel8.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private CustomListBox listBox1;
        private Label SettingsLabel;
        private Label SteamCardExchange;
        private PictureBox pictureBox1;
        private Splitter splitter1;
        private CustomListBox listBox2;
        private Splitter splitter2;
        private Button button1;
        private Label label1;
        private Button button2;
        private Label label2;
        private Panel panel3;
        private Label label3;
        private Label ProgressLabel;
        private CustomProgressBar customProgressBar1;
        private CustomCheckBox foilCards;
        private Panel GamePanel;
        private Button gameNameButton;
        private Panel panel5;
        private Panel panel6;
        private Panel PricePanel;
        private Panel panel9;
        private Panel panel8;
        private Button gamePriceButton;
        private Label FileLabel;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem checkPriceToolStripMenuItem;
        private ToolStripMenuItem marketToolStripMenuItem;
        private ToolStripMenuItem sCExchangeToolStripMenuItem;
        private CustomVScrollBar vScrollBar1;
        private Button reloadChromeButton;
    }
}
