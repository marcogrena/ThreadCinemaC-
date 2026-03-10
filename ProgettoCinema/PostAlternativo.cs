using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace ProgettoCinema
{
    

    public class PostoAlternativo
    {
        public bool Occupato { get; private set; }
        public TipoPosto Tipo { get; private set; }

        private PictureBox picturePosto;
        private PictureBox overlayPersona;

        public PostoAlternativo(TipoPosto tipo)
        {
            Tipo = tipo;
            Occupato = false;
        }

        public void Disegna(Panel panel, int x, int y)
        {
            picturePosto = new PictureBox();

            picturePosto.Size = new Size(40, 40);
            picturePosto.Location = new Point(x, y);
            picturePosto.SizeMode = PictureBoxSizeMode.StretchImage;

            picturePosto.Image = GetImmaginePosto();

            picturePosto.Click += (s, e) => Toggle();

            panel.Controls.Add(picturePosto);

            AggiornaOverlay(panel);
        }

        private Image GetImmaginePosto()
        {
            switch (Tipo)
            {
                case TipoPosto.Vip:
                    return Image.FromFile("posto.vip.png");

                case TipoPosto.Bambino:
                    return Image.FromFile("posto.bambino.png");

                default:
                    return Image.FromFile("posto.normale.png");
            }
        }

        private void AggiornaOverlay(Control parent)
        {
            if (Occupato)
            {
                if (overlayPersona == null)
                {
                    overlayPersona = new PictureBox();
                    overlayPersona.Parent = picturePosto;
                    overlayPersona.Size = new Size(picturePosto.Size.Width - 5, picturePosto.Size.Height - 5);
                    overlayPersona.Location = new Point(2, 0);
                    overlayPersona.BackColor = Color.Transparent;
                    overlayPersona.SizeMode = PictureBoxSizeMode.StretchImage;
                    overlayPersona.Image = Image.FromFile("persona.png");
                    overlayPersona.BringToFront();
                }
            }
            else
            {
                if (overlayPersona != null)
                {
                    overlayPersona.Dispose();
                    overlayPersona = null;
                }
            }
        }

        public void Toggle()
        {
            Occupato = !Occupato;
            AggiornaOverlay(picturePosto.Parent);
        }
    }
}
