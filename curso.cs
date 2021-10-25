using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taller_visicion_de_computadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void abrirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OFDARCHIVO.Title = "archivo de imagen";
            OFDARCHIVO.Title = "archivo jpg|*.jpg|archivo de mapa de bits|*.bmp ";
            OFDARCHIVO.FileName = "";
            if (OFDARCHIVO.ShowDialog() == DialogResult.OK)
            {
                PBRGB.Image = Image.FromFile(OFDARCHIVO.FileName);
            }
        }

        private void cambiarImagenAGrisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap imagenRGB = new Bitmap(PBRGB.Image);
            Bitmap imagenGRIS = new Bitmap(imagenRGB.Width, imagenRGB.Height);

            for (int y = 0; y < imagenRGB.Height; y++)
            {
                for (int x = 0; x < imagenRGB.Width; x++)
                {
                    Byte gris;

                    gris = (Byte)(0.3 * imagenRGB.GetPixel(x, y).R +
                        0.59 * imagenRGB.GetPixel(x, y).G +
                        0.11 * imagenRGB.GetPixel(x, y).B);
                    imagenGRIS.SetPixel(x, y, Color.FromArgb(255, gris, gris, gris));

                }
            }
            pbgris.Image = imagenGRIS;
        }

        private void cambiarImangenABinarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap imagenGRIS = new Bitmap(pbgris.Image);
            Bitmap imagenbinaria = new Bitmap(imagenGRIS.Width, imagenGRIS.Height);

            for (int y = 0; y < imagenGRIS.Height; y++)
            {
                for (int x = 0; x < imagenGRIS.Width; x++)
                {


                    if (imagenGRIS.GetPixel(x, y).R <= 128)
                        imagenbinaria.SetPixel(x, y, Color.FromArgb(225, 0, 0, 0));
                    else
                        imagenbinaria.SetPixel(x, y, Color.FromArgb(225, 225, 225, 225));

                }
            }
            pbbinario.Image = imagenbinaria;

        }

        private void pbgris_Click(object sender, EventArgs e)
        {

        }
    }
}
