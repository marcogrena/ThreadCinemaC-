using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCinema
{
    public partial class Form1 : Form
    {
        Cinema cinema;
        CassaThread cassa1;
        CassaThread cassa2;
        CassaThread cassa3;
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            cinema = new Cinema();

            SalaCinematografica sala1 = new SalaCinematografica("Sala 1", 5, 8);
            SalaCinematografica sala2 = new SalaCinematografica("Sala 2", 6, 10);

            cinema.AggiungiSala(sala1);
            cinema.AggiungiSala(sala2);

            cinema.DisegnaSala(0, panel1);
            cinema.DisegnaSala(1, panel2);

            cassa1 = new CassaThread(1, sala1, panel1);
            cassa2 = new CassaThread(2, sala2, panel1);
            cassa3 = new CassaThread(3, sala1, panel1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cassa1.Avvia();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cassa2.Avvia();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cassa3.Avvia();
        }
    }
}
