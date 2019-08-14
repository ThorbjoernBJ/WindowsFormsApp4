using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public int Bank = 100;
        public Decimal Ratefaktor = 1.5m;
        public Decimal Rate = 3m;
        public Random rnd = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            

            // her starter jeg med at lave de 6 forskellige udfald
            int Udfald1 = 0;
            int Udfald2 = 0;
            int Udfald3 = 0;
            int Udfald4 = 0;
            int Udfald5 = 0;
            int Udfald6 = 0;
            int[] Udfald = new int[6] { 0,0,0,0,0,0};
            
            do
            {
                Udfald1 = rnd.Next(1, 15);
                Udfald[0] = Udfald1;
            }
            while (Udfald1==0);

            do
            {
                Udfald2 = rnd.Next(1, 15);
                Udfald[1] = Udfald2;
            }
            while (Udfald[0] == Udfald2);

            do
            {
                Udfald3 = rnd.Next(1, 15);
                Udfald[2] = Udfald3;
            }
            while (Udfald[0] == Udfald3 || Udfald[1] == Udfald3);

            do
            {
                Udfald4 = rnd.Next(1, 15);
                Udfald[3] = Udfald4;
            }
            while (Udfald[0] == Udfald4 || Udfald[1] == Udfald4 || Udfald[2] == Udfald4);

            do
            {
                Udfald5 = rnd.Next(1, 15);
                Udfald[4] = Udfald5;
            }
            while (Udfald[0] == Udfald5 || Udfald[1] == Udfald5 || Udfald[2] == Udfald5 || Udfald[3] == Udfald5);

            do
            {
                Udfald6 = rnd.Next(1, 15);
                Udfald[5] = Udfald6;
            }
            while (Udfald[0] == Udfald6 || Udfald[1] == Udfald6 || Udfald[2] == Udfald6 || Udfald[3] == Udfald6 || Udfald[4] == Udfald6);







            string Text = Udfald[0].ToString() + " " + Udfald[1].ToString() + " " + Udfald[2].ToString() + " " + Udfald[3].ToString() + " " + Udfald[4].ToString() + " " + Udfald[5].ToString();



            Resultat.Text = Text;

            //Her laver jeg et array over de indtastede værdier
            decimal[] DGæt = new decimal[6] { numericUpDown1.Value, numericUpDown3.Value, numericUpDown4.Value , numericUpDown5.Value,numericUpDown6.Value,numericUpDown7.Value};

            //Her vil jeg omdanne min decimal array til en int array
            for (int i = 0; i < Udfald.Length; i++)
            {
                DGæt[i] = Convert.ToDecimal(DGæt[i]);
            }

            int Gevinst = 0;

            // Her vil jeg sammenligne gæt og udfladet
            for (int i = 0;i < Udfald.Length; i++)
            {
                

                for (int j = 0; j < DGæt.Length; j++)
                {
                    if (Udfald[i] == DGæt[j])
                    {
                        Gevinst += 1;


                        break;
                    }

                }

            }

            

            // Gevinsten
            pris.Text = "Gevinst" + Gevinst * Rate + 'R';

            //Hvor meget du mister i din bank af at spille
            Bank = Bank - 5;

            //Selve regnestykket, men også udskrivningen.
            Double BankNu = Convert.ToDouble(Bank) + Convert.ToDouble(Gevinst) * Convert.ToDouble(Rate);
            Banklbl.Text = "Bank " + BankNu.ToString() + 'R';

            // Her kan bankværdien hentes.
            //Jeg vil gerne bruge Bank label som reference til en int bank værdi i stedet for at have en public int.
            string[] BankSplit = Banklbl.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int index1 = BankSplit[0].LastIndexOf(' ');
            int index2 = BankSplit[0].LastIndexOf('R');
            string BankBox = BankSplit[0].Substring(index1, index2 - index1);
            //For at undersøge om ring virker:
            label2.Text = "Du har lige nu " + BankBox;






        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Vi converter Bank label til et string array og splitter der hvor der er et mellemrum.
            //Dernæst tages den del af arrayet, som er efter mellemrummet.
            string[] BankNu = Banklbl.Text.Split(' ');

            label2.Text = "Du har lige nu " + BankNu[1];
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UpgradeRateButton_Click(object sender, EventArgs e)
        {
            /*
            //For at få fat i og bruge raten bruges følgende string, substring og decimal inddelinger
            string[] RateSplit = RateLabel.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int index1 = RateSplit[0].LastIndexOf('x');
            int index2 = RateSplit[0].LastIndexOf(',');
            int index3 = RateSplit[0].LastIndexOf(' ');
            string NyRateOver = RateSplit[0].Substring(index1 + 2, index2 - (index1 + 2));
            string NyRateUnder = RateSplit[0].Substring(index2 + 1, index3 - (index2 + 1));
            Decimal NyRateO = Convert.ToDecimal(NyRateOver);
            Decimal NyRateU = Convert.ToDecimal(NyRateUnder);
            double Iamdead = Math.Pow(10, -1);
            Decimal NyRate = 2 * 3;
            */

            Rate = Rate * Ratefaktor;


            //For at undersøge om det virker:
            RateLabel.Text = "Din gevinst rate er lige nu: x " + Rate ;


            //Hvor meget du mister i din bank for at upgradere.
            Bank = Bank - 50;

            //Selve regnestykket, men også udskrivningen.
            
            Banklbl.Text = "Bank " + Bank.ToString() + 'R';

                       
            //For at undersøge om ring virker:
            label2.Text = "Du har lige nu " + Bank + 'R';



        }
    }
}
