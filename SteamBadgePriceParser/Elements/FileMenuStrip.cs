using System.Text.Json;
using System.Xml;

namespace SteamBadgePriceParser.Elements
{
    public partial class FileMenuStrip : UserControl
    {
        private System.Windows.Forms.Timer mouseCheckTimer;
        private MainForm mainForm;
        private bool timerStarted = false;
        public FileMenuStrip(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
            mouseCheckTimer = new System.Windows.Forms.Timer { Interval = 200 };
            mouseCheckTimer.Tick += MouseCheckTimer_Tick;
        }

        private void MouseCheckTimer_Tick(object sender, EventArgs e)
        {
            Point mousePos = Control.MousePosition;
            Point formPos = this.PointToClient(mousePos);

            if (formPos.X < 0 || formPos.Y < 0 || formPos.X > this.ClientSize.Width || formPos.Y > this.ClientSize.Height)
            {
                mouseCheckTimer.Stop();
                Dispose();
            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = Color.Black;

            if (!timerStarted)
                mouseCheckTimer.Start();
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = Color.White;
        }

        private void saveTxtFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save Game Data as TXT";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine("name || price || id");
                    foreach (var game in mainForm.gameDatas)
                    {
                        writer.WriteLine($"{game.name} || {game.price} || {game.id}");
                    }
                }
            }
        }

        private void saveJsonFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save Game Data as JSON";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = JsonSerializer.Serialize(mainForm.gameDatas, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }

        private void loadTxtFile_Click(object sender, EventArgs e)
        {
            List<GameData> gameDatas = new List<GameData>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Load Game Data from TXT";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    string line;
                    bool isFirstLine = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            continue; // Пропускаем заголовок
                        }

                        string[] parts = line.Split(" || ", StringSplitOptions.None);
                        if (parts.Length == 3)
                        {
                            gameDatas.Add(new GameData
                            {
                                name = parts[0],
                                price = float.Parse(parts[1]),
                                id = parts[2]
                            });
                        }
                    }
                }
            }
            mainForm.gameDatas = gameDatas;
            mainForm.UpdateListboxes();
        }

        private void LoadJsonFile_Click(object sender, EventArgs e)
        {
            List<GameData> gameDatas = new List<GameData>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            openFileDialog.Title = "Load Game Data from JSON";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                gameDatas = JsonSerializer.Deserialize<List<GameData>>(json);
            }
            mainForm.gameDatas = gameDatas;
            mainForm.UpdateListboxes();
        }

        private void FileMenuStrip_MouseLeave(object sender, EventArgs e)
        {
            mouseCheckTimer.Stop();
            this.Dispose();
        }
    }
}
