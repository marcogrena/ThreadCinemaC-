using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ProgettoCinema
{

    public class Posto
    {
        public bool Occupato { get; private set; }
        public TipoPosto Tipo { get; private set; }

        private PictureBox picturePosto;
        private PictureBox picturePersona;

        public Posto(TipoPosto tipo, bool occupato = false)
        {
            Tipo = tipo;
            Occupato = occupato;
        }

        public void Mostra(Panel panel, int x, int y)
        {
            picturePosto = new PictureBox();
            picturePosto.Size = new Size(40, 40);
            picturePosto.Location = new Point(x, y);
            picturePosto.SizeMode = PictureBoxSizeMode.StretchImage;

            picturePosto.Image = GetImmaginePosto();

            panel.Controls.Add(picturePosto);

            if (Occupato)
            {
                picturePersona = new PictureBox();
                picturePersona.Size = picturePosto.Size;
                picturePersona.Location = picturePosto.Location;
                picturePersona.SizeMode = PictureBoxSizeMode.StretchImage;
                picturePersona.BackColor = Color.Transparent;

                picturePersona.Image = Image.FromFile("persona.png");

                panel.Controls.Add(picturePersona);
                picturePersona.BringToFront();
            }
        }

        private Image GetImmaginePosto()
        {
            switch (Tipo)
            {
                case TipoPosto.Vip:
                    return Image.FromFile("posto_vip.png");

                case TipoPosto.Bambino:
                    return Image.FromFile("posto_bambino.png");

                default:
                    return Image.FromFile("posto_normale.png");
            }
        }

        public void Occupa()
        {
            Occupato = true;

            if (picturePersona == null)
            {
                picturePersona = new PictureBox();
                picturePersona.Size = picturePosto.Size;
                picturePersona.Location = picturePosto.Location;
                picturePersona.SizeMode = PictureBoxSizeMode.StretchImage;
                picturePersona.BackColor = Color.Transparent;
                picturePersona.Image = Image.FromFile("persona.png");

                picturePosto.Parent.Controls.Add(picturePersona);
                picturePersona.BringToFront();
            }
        }

        public void Libera()
        {
            Occupato = false;

            if (picturePersona != null)
            {
                picturePersona.Dispose();
                picturePersona = null;
            }
        }
    }
}
