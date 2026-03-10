using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

    public class CassaThread
    {
        private Thread thread;
        private SalaCinematografica sala;
        private Panel panel;
        private Random random;

        public int IdCassa { get; }

        private bool attiva = true;

        public CassaThread(int id, SalaCinematografica sala, Panel panel)
        {
            IdCassa = id;
            this.sala = sala;
            this.panel = panel;

            random = new Random(Guid.NewGuid().GetHashCode());

            thread = new Thread(VendiBiglietti);
        }

        public void Avvia()
        {
            thread.Start();
        }

        public void Ferma()
        {
            attiva = false;
        }

        private void VendiBiglietti()
        {
            int postiDisponibili = sala.postiDisponibili();
            while (attiva && postiDisponibili>0)
            {
                Thread.Sleep(random.Next(500, 2000));
                PostoAlternativo p;
                postiDisponibili = sala.postiDisponibili();
                do
                {
                    int r = random.Next(sala.Righe);
                    int c = random.Next(sala.Colonne);
                    p = sala.GetPosto(r, c);
                } while (p.Occupato);
                
                panel.Invoke(new Action(() =>
                {   
                    p.Toggle();
                }));
            }
        }
    }
}
