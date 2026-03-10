using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCinema
{


    public class SalaCinematografica
    {
        public string Nome { get; set; }

        private PostoAlternativo[,] posti;

        public int Righe { get; }
        public int Colonne { get; }

        

        public SalaCinematografica(string nome, int righe, int colonne)
        {
            Nome = nome;
            Righe = righe;
            Colonne = colonne;

            posti = new PostoAlternativo[righe, colonne];
            
            InizializzaPosti();
        }

        private void InizializzaPosti()
        {
            for (int r = 0; r < Righe; r++)
            {
                for (int c = 0; c < Colonne; c++)
                {
                    TipoPosto tipo = TipoPosto.Normale;

                    if (r < 2)
                        tipo = TipoPosto.Vip;

                    if (r == Righe - 1)
                        tipo = TipoPosto.Bambino;

                    posti[r, c] = new PostoAlternativo(tipo);
                }
            }
        }

        public void Disegna(Panel panel)
        {
            int spazio = 45;

            for (int r = 0; r < Righe; r++)
            {
                for (int c = 0; c < Colonne; c++)
                {
                    posti[r, c].Disegna(panel, c * spazio, r * spazio);
                }
            }
        }

        public PostoAlternativo GetPosto(int r, int c)
        {
            return posti[r, c];
        }

        public int postiDisponibili()
        {
            int count = 0;
            for (int r = 0; r < Righe; r++)
            {
                for (int c = 0; c < Colonne; c++)
                {
                    if (!posti[r, c].Occupato)
                        count++;
                }
            }
            return count;
        }
    }
}
