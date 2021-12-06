using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProjekt_MaciejPozorski
{

   
    public partial class Form2 : Form
    {
        int proba = 0;      
        int liczba = 0;
        int strzal;
        
        
       static int losowanie(int l)      //losowanie randomowej liczby w przedziale od 1 do 100
        {
            Random rnd = new Random();
          return l = rnd.Next(1, 100);                             
        }
        
    private void res()                       //resetowanie wszystkich funkcji i informacji
        {
            progressBar1.Value = 60;
            timer1.Enabled = true;
            liczba = losowanie(liczba);
            listBox1.Items.Clear();
            proba = 0;
            informacja_label.Text = "";
        }
        private void dodajlista()                         //dodaje podane liczby do textbox'a oraz sprawdza czy się nie powtarzają
        {
            if (!listBox1.Items.Contains(textBox1.Text))
            {
                if (textBox1.Text != "")
                {
                    listBox1.Items.Add(textBox1.Text);
                    textBox1.Text = "";
                }
                else MessageBox.Show("Wprowadz wartość!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Taką liczbę już podałeś " + textBox1.Text, "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            gracz_lb.Text = "Gracz: " + Form1.imie;
        }



        private void start2_btn_Click(object sender, EventArgs e)
        {
            

            if (start2_btn.Text == "Start")
            {
               
                res();
                label3.Text = "Próba: " + proba;
                start2_btn.Text = "Sprawdź";

                //kod niżej pokazuje wylosowaną liczbę dla łatwiejszego sprzawdzania :)
               // label4.Text =""+ liczba;     
               
                return;
               
            }
            if (start2_btn.Text == "Sprawdź")
            {
               
                    try                                            //zapobiega wpisaniu liter
                    {
                        strzal = int.Parse(textBox1.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Błąd w wprowadzonym zapisie!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        
                    }
                    

                    if (progressBar1.Value != 0)
                    {
                        dodajlista();
                        proba++;
                        label3.Text = "Próba: " + proba;
                        if (strzal != liczba)
                        {
                            if (strzal > liczba)
                            {
                                informacja_label.Text = "Za dużo!";
                            }
                            if (strzal < liczba)
                            {
                                informacja_label.Text = "Za mało!";
                            }
                        }
                        else  // kod się uruchamia kiedy zgadniemy liczbę
                        {
                        timer1.Enabled = false;
                        informacja_label.Text = "Wygrałeś!";
                        start2_btn.Text = "Start";
                        MessageBox.Show("Gratulacje liczba to: " + strzal + " wygrałeś w " + proba + " próbie!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else   //uruchamia się kiedy nie zdążymy sprawdzić liczby na czas
                    {
                        DialogResult result = MessageBox.Show("Nie zdążyłeś na czas! Liczba to: " + liczba + " Czy chcesz kontynuować?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                            this.Close();
                        }
                        if (result == DialogResult.Yes)
                        {

                        start2_btn.Text = "Start";

                        }
                    }

                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(-1);
        }

        

        private void start2_btn_MouseEnter(object sender, EventArgs e)
        {
            start2_btn.BackColor = Color.DarkMagenta;
        }

        private void start2_btn_MouseLeave(object sender, EventArgs e)
        {
            start2_btn.BackColor = Color.GhostWhite;
        }
    }
}
