using System.Globalization;

namespace SteamBadgePriceParser
{
    public partial class SettingsPage : Form
    {
        public SettingsObject Settings;
        private MainForm mainForm;
        public SettingsPage(MainForm main, SettingsObject settingsObject)
        {
            InitializeComponent();
            mainForm = main;
            Settings = settingsObject;
            userDataTextBox.Text = Settings.UserDataDir;
            userNameTextBox.Text = Settings.UserName;
            delayTextBox.Text = Settings.Delay.ToString();
            guiCheckBox.Checked = Settings.GUIMode;
            sandboxCheckbox.Checked = Settings.SandboxMode;
            languageComboBox.SelectedIndexChanged -= languageComboBox_SelectedIndexChanged;
            if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "en")
            {
                languageComboBox.SelectedIndex = 0;
            }
            else
            {
                languageComboBox.SelectedIndex = 1;
            }
            languageComboBox.SelectedIndexChanged += languageComboBox_SelectedIndexChanged;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Settings.GUIMode = guiCheckBox.Checked;
            Settings.SandboxMode = sandboxCheckbox.Checked;
            Settings.UserDataDir = userDataTextBox.Text;
            Settings.UserName = userNameTextBox.Text;
            Settings.Language = (languageComboBox.SelectedIndex == 0) ? "en" : "ru";
            Settings.Save("UserSettings.json");
            this.Close();
        }

        private void SettingsPage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Settings = new SettingsObject();
            userDataTextBox.Text = Settings.UserDataDir;
            userNameTextBox.Text = Settings.UserName;
            delayTextBox.Text = Settings.Delay.ToString();
            guiCheckBox.Checked = Settings.GUIMode;
            sandboxCheckbox.Checked = Settings.SandboxMode;
        }

        private void ChangeLanguage(string langCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);
            UpdateLocalization();
            mainForm.BeginInvoke(new Action(() => { mainForm.UpdateLocalization(); }));
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (languageComboBox.SelectedItem.ToString())
            {
                case "English":
                    ChangeLanguage("en");
                    Settings.Language = "en";
                    break;
                case "Русский":
                    ChangeLanguage("ru");
                    Settings.Language = "en";
                    break;
                default:
                    ChangeLanguage("en");
                    break;
            }
        }

        private void UpdateLocalization()
        {
            this.Controls.Clear();
            InitializeComponent();
            languageComboBox.SelectedIndexChanged -= languageComboBox_SelectedIndexChanged;
            if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "en")
            {
                languageComboBox.SelectedIndex = 0;
            }
            else
            {
                languageComboBox.SelectedIndex = 1;
            }
            languageComboBox.SelectedIndexChanged += languageComboBox_SelectedIndexChanged;
            userDataTextBox.Text = Settings.UserDataDir;
            userNameTextBox.Text = Settings.UserName;
            delayTextBox.Text = Settings.Delay.ToString();
            guiCheckBox.Checked = Settings.GUIMode;
            sandboxCheckbox.Checked = Settings.SandboxMode;
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Choose folder";
                folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolderPath = folderDialog.SelectedPath;
                    userDataTextBox.Text = selectedFolderPath;
                }
            }
        }
    }
}
