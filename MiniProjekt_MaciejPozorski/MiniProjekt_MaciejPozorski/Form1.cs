using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MiniProjekt_MaciejPozorski
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string imie = "";

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog plik = new OpenFileDialog();                    //kontrolka pozwala nam załadować zdjęcie po kliknięciu w pole
            plik.Filter = "JPG (*.jpg)|*.jpg";                             //filt ładujący jedynie pliki jpg
            if (plik.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(plik.FileName);
                label2.Visible = false;
                pictureBox1.BackColor = Color.GhostWhite;
            }
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog plik = new OpenFileDialog();
            plik.Filter = "JPG (*.jpg)|*.jpg";
            if (plik.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(plik.FileName);
                label2.Visible = false;
                pictureBox1.BackColor = Color.GhostWhite;
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            if (nazwa_tb.Text.Length == 0) // nie pozwoli nam uruchomić gry bez podania imienia
            {
                MessageBox.Show("Nie podano nazwy użytkownika!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                imie = nazwa_tb.Text;
                Form2 frm2 = new Form2();
                frm2.Show();
            }
        }

        private void zasadyGryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gra polega na znalezieniu wylosowanej przez komputer liczby. Masz na to minutę!", "Zasady", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            if (checkBox1.Checked)
            {
                sp.SoundLocation = @"No Sanctuary Here.wav";
                sp.PlayLooping();
            }
            else
            {
                sp.Stop();
            }
        }

        private void checkBox1_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(checkBox1, "Uwaga głośna muzyka!");
        }
    }
}
