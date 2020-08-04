using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Findаpair
{
    
    public partial class Form1 : Form
    {
        private int n = 6;
        private int count = 0;
        private int countTrue = 0;
        private int indicator= 0;
        private Label secondLabel;
        private Label firstLabel;
        private List<string> Elems1 = new List<string> { "A", "B", "C", "D", "Y", "G", "K", "L", "M", "N", "Q", "T", "U", "X", "Z", "H", "F", "V", "A", "B", "C", "D", "Y", "G", "K", "L", "M", "N", "Q", "T", "U", "X", "Z", "H", "F", "V" };
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            tableFiller(Elems1);
        }

        //Заполняем таблицу случайными элементами
        private void tableFiller(List<string> Elems)
        {
            List<string> ElemsN = new List<string>();
            ElemsN.AddRange(Elems);
            for (int i = 0; i <= 35; i++)
            {
                Panel panel = new Panel();
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Dock = DockStyle.Fill;

                Label label = new Label();
                label.Dock = DockStyle.Fill;
                label.Visible = true;
                label.BackColor = Color.Black;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Font = new Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                int buf = rand.Next(0, ElemsN.Count);
                label.Text = ElemsN[buf];
                label.Click += new EventHandler(label_Click);
                ElemsN.RemoveAt(buf);
                panel.Controls.Add(label);
                tableLayoutPanel1.Controls.Add(panel);
            }
        }
        private void label_Click(object sender, EventArgs e)
        {
            Label clicedLabel = sender as Label;

            if(countTrue == 18)
            {
                MessageBox.Show("Поздравляем, вы нашли все пары ! \b Чтобы начать заного перезапустите программу.");
            }
            if (clicedLabel.BackColor == Color.White || clicedLabel.BackColor == Color.LightGreen)
            {
                return;
            }

            indicator++;

            if (indicator == 2)
            {
                label2.Text = Convert.ToString(++count);
                secondLabel = clicedLabel;
                if (firstLabel.Text == secondLabel.Text)
                {
                    countTrue++;
                    
                    indicator = 0;
                    firstLabel.BackColor = Color.LightGreen;
                    secondLabel.BackColor = Color.LightGreen;
                    firstLabel = null;
                    secondLabel = null;
                    if (countTrue == 18)
                    {
                        MessageBox.Show("Поздравляем, вы нашли все пары ! Чтобы начать заного перезапустите программу.");
                    }
                    return;
                }
                else
                {
                    secondLabel.BackColor = Color.White;
                    return;
                }
            }
            if( indicator == 3)
            {
                indicator = 1;
                firstLabel.BackColor = Color.Black;
                if (secondLabel != null)
                {
                    secondLabel.BackColor = Color.Black;
                }
                secondLabel = null;
                firstLabel = clicedLabel;
                firstLabel.BackColor = Color.White;
                return;
            }
            //Если все хорошо
            clicedLabel.BackColor = Color.White;
            firstLabel = clicedLabel;
        }
    }
}
