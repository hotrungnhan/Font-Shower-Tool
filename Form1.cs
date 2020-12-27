using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4
{
    public partial class Form1 : Form
    {
        FontStyle curstyle;
        public Form1()
        {
            InitializeComponent();
            button1.BackColor = this.showLabel.ForeColor;
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name);
            }
            comboBox1.SelectedItem = showLabel.Font.Name;

            for (int i = 8; i <= 72; i += 2)
            {
                comboBox2.Items.Add(i);
            }
            comboBox2.Text = showLabel.Font.Size.ToString();
            curstyle = showLabel.Font.Style;
        }



        private void button_Click(object sender, EventArgs e)
        {
            var button = sender as RadioButton;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            button.Checked = true;
            switch (button.Text)
            {
                case "Left":

                    showLabel.TextAlign = ContentAlignment.MiddleLeft;
                    break;
                case "Center":
                    showLabel.TextAlign = ContentAlignment.MiddleCenter;

                    break;
                case "Right":

                    showLabel.TextAlign = ContentAlignment.MiddleRight;
                    break;
            }
        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            var button = sender as CheckBox;
            if (button.Checked == true)
                switch (button.Text)
                {
                    case "U":

                        curstyle = FontStyle.Underline | curstyle;
                        break;
                    case "I":
                        curstyle = FontStyle.Italic | curstyle;

                        break;
                    case "B":

                        curstyle = FontStyle.Bold | curstyle;
                        break;
                }
            else
            {
                switch (button.Text)
                {
                    case "U":

                        curstyle = ~(FontStyle.Underline ^ ~curstyle);
                        break;
                    case "I":
                        curstyle = ~(FontStyle.Italic ^ ~curstyle);

                        break;
                    case "B":

                        curstyle = ~(FontStyle.Bold ^ ~curstyle);
                        break;
                }
            }
            this.showLabel.Font = new Font(this.comboBox1.Text, float.Parse(this.comboBox2.Text), curstyle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog(); //Khởi tạo đối tượng ColorDialog 
            if (dlg.ShowDialog() == DialogResult.OK) //Nếu nhấp vào nút OK trên hộp thoại
            {
                showLabel.ForeColor = dlg.Color;
                button1.BackColor = dlg.Color;
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.Text != "" && this.comboBox2.Text != "")
                this.showLabel.Font = new Font(this.comboBox1.Text, float.Parse(this.comboBox2.Text), curstyle);
        }
    }
}
