namespace SteamBadgePriceParser.Elements
{
    partial class FileMenuStrip
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileMenuStrip));
            saveTxtFile = new Button();
            saveJsonFile = new Button();
            loadTxtFile = new Button();
            LoadJsonFile = new Button();
            SuspendLayout();
            // 
            // saveTxtFile
            // 
            resources.ApplyResources(saveTxtFile, "saveTxtFile");
            saveTxtFile.FlatAppearance.BorderSize = 0;
            saveTxtFile.FlatAppearance.MouseDownBackColor = Color.FromArgb(161, 168, 180);
            saveTxtFile.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 222, 223);
            saveTxtFile.ForeColor = SystemColors.Control;
            saveTxtFile.Name = "saveTxtFile";
            saveTxtFile.UseVisualStyleBackColor = true;
            saveTxtFile.Click += saveTxtFile_Click;
            saveTxtFile.MouseEnter += button_MouseEnter;
            saveTxtFile.MouseLeave += button_MouseLeave;
            // 
            // saveJsonFile
            // 
            resources.ApplyResources(saveJsonFile, "saveJsonFile");
            saveJsonFile.FlatAppearance.BorderSize = 0;
            saveJsonFile.FlatAppearance.MouseDownBackColor = Color.FromArgb(161, 168, 180);
            saveJsonFile.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 222, 223);
            saveJsonFile.ForeColor = SystemColors.Control;
            saveJsonFile.Name = "saveJsonFile";
            saveJsonFile.UseVisualStyleBackColor = true;
            saveJsonFile.Click += saveJsonFile_Click;
            saveJsonFile.MouseEnter += button_MouseEnter;
            saveJsonFile.MouseLeave += button_MouseLeave;
            // 
            // loadTxtFile
            // 
            resources.ApplyResources(loadTxtFile, "loadTxtFile");
            loadTxtFile.FlatAppearance.BorderSize = 0;
            loadTxtFile.FlatAppearance.MouseDownBackColor = Color.FromArgb(161, 168, 180);
            loadTxtFile.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 222, 223);
            loadTxtFile.ForeColor = SystemColors.Control;
            loadTxtFile.Name = "loadTxtFile";
            loadTxtFile.UseVisualStyleBackColor = true;
            loadTxtFile.Click += loadTxtFile_Click;
            loadTxtFile.MouseEnter += button_MouseEnter;
            loadTxtFile.MouseLeave += button_MouseLeave;
            // 
            // LoadJsonFile
            // 
            resources.ApplyResources(LoadJsonFile, "LoadJsonFile");
            LoadJsonFile.FlatAppearance.BorderSize = 0;
            LoadJsonFile.FlatAppearance.MouseDownBackColor = Color.FromArgb(161, 168, 180);
            LoadJsonFile.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 222, 223);
            LoadJsonFile.ForeColor = SystemColors.Control;
            LoadJsonFile.Name = "LoadJsonFile";
            LoadJsonFile.UseVisualStyleBackColor = true;
            LoadJsonFile.Click += LoadJsonFile_Click;
            LoadJsonFile.MouseEnter += button_MouseEnter;
            LoadJsonFile.MouseLeave += button_MouseLeave;
            // 
            // FileMenuStrip
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(61, 68, 80);
            Controls.Add(LoadJsonFile);
            Controls.Add(loadTxtFile);
            Controls.Add(saveJsonFile);
            Controls.Add(saveTxtFile);
            Name = "FileMenuStrip";
            MouseLeave += FileMenuStrip_MouseLeave;
            ResumeLayout(false);
        }

        #endregion

        private Button saveTxtFile;
        private Button saveJsonFile;
        private Button loadTxtFile;
        private Button LoadJsonFile;
    }
}
