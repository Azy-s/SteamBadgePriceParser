using System.Text.Json;

namespace SteamBadgePriceParser
{
    public class SettingsObject
    {
        public string UserDataDir { get; set; }
        public string UserName { get; set; }
        public bool GUIMode { get; set; }
        public bool SandboxMode { get; set; }
        public int Delay { get; set; }
        public string Language { get; set; }
        public SettingsObject() 
        {
            UserDataDir = $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\Google\\Chrome\\User Data";
            UserName = "Default";
            GUIMode = true;
            SandboxMode = true;
            Delay = 100;
            Language = "en";
        }

        public SettingsObject(string userDataDir, string userName, bool gUIMode, bool sandboxMode, int delay, string lang)
        {
            UserDataDir = userDataDir;
            UserName = userName;
            GUIMode = gUIMode;
            SandboxMode = sandboxMode;
            Delay = delay;
            Language = lang;
        }

        public SettingsObject(SettingsObject settings)
        {
            UserDataDir = settings.UserDataDir;
            UserName = settings.UserName;
            GUIMode = settings.GUIMode;
            SandboxMode = settings.SandboxMode;
            Delay = settings.Delay;
            Language = settings.Language;
        }

        public void UpdateSettigs(SettingsObject settings)
        {
            UserDataDir = settings.UserDataDir;
            UserName = settings.UserName;
            GUIMode = settings.GUIMode;
            SandboxMode = settings.SandboxMode;
            Delay = settings.Delay;
            Language = settings.Language;
        }
        public void Save(string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving the settings: {ex.Message}");
            }
        }

        public void Load(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                SettingsObject settings = JsonSerializer.Deserialize<SettingsObject>(json);
                UpdateSettigs(settings);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while loading settings: {ex.Message}");
            }
        }
    }
}
