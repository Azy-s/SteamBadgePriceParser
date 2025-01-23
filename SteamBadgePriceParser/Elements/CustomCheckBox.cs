using SteamBadgePriceParser.Properties;

namespace SteamBadgePriceParser
{
    public class CustomCheckBox : CheckBox
    {
        private bool mouseOnCheckBox = false;
        public CustomCheckBox() 
        {
            this.Appearance = Appearance.Button;
            this.AutoSize = true;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.CheckedBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.Image = Properties.Resources.checkbox_off;
            this.Size = new Size(49, 36);
            this.UseVisualStyleBackColor = true;
            this.CheckedChanged += checkBox1_CheckedChanged;
            this.MouseEnter += checkBox1_MouseEnter;
            this.MouseLeave += checkBox1_MouseLeave;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Checked)
            {
                this.Image = mouseOnCheckBox ? Resources.checkbox_on_highlighted : Resources.checkbox_on;
            }
            else
            {
                this.Image = mouseOnCheckBox ? Resources.checkbox_off_highlighted : Resources.checkbox_off;
            }
        }

        private void checkBox1_MouseEnter(object sender, EventArgs e)
        {
            mouseOnCheckBox = true;
            this.Image = this.Checked ? Resources.checkbox_on_highlighted : Resources.checkbox_off_highlighted;
        }

        private void checkBox1_MouseLeave(object sender, EventArgs e)
        {
            mouseOnCheckBox = false;
            this.Image = this.Checked ? Resources.checkbox_on : Resources.checkbox_off;
        }
    }
}
