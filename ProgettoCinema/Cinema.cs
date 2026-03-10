using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCinema
{


    public class Cinema
    {
        private List<SalaCinematografica> sale;

        public Cinema()
        {
            sale = new List<SalaCinematografica>();
        }

        public void AggiungiSala(SalaCinematografica sala)
        {
            sale.Add(sala);
        }

        public SalaCinematografica GetSala(int index)
        {
            return sale[index];
        }

        public void DisegnaSala(int index, Panel panel)
        {
            panel.Controls.Clear();
            sale[index].Disegna(panel);
        }
    }
}
