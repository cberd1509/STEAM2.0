using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STEAM2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private string AskName()
        {
            projectName nm = new projectName();

            string nombre="Proyecto Sin Título";

            if (nm.ShowDialog(this) == DialogResult.OK)
            {
                nombre = nm.nombre;
            }

            return nombre;

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void marxYLanghenheimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = AskName();
            MarxYLanghenheim form = new MarxYLanghenheim(nombre);
            form.MdiParent = this;
            form.Show();
        }

        private void mandiYVolekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = AskName();
            MandlVolek form = new MandlVolek(nombre);
            form.MdiParent = this;
            form.Show();
        }

        public void setStatus(string status)
        {
            toolStripStatusLabel1.Text = status;
        }

        private void menuStrip1_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item.Text == "")
            {
                e.Item.Visible = false;
            }
        }

        private void Form1_MdiChildActivate(object sender, EventArgs e)
        {
            if(ActiveMdiChild != null)
            {
                string nombre = ((MDIForm)ActiveMdiChild).nombre;
                string type = ((MDIForm)ActiveMdiChild).type;
                toolStripStatusLabel1.Text = nombre+" - "+type;
            }            
            else
            {
                toolStripStatusLabel1.Text = "Steam 2.0 Cargado Correctamente";
            }
        }

        private void bobergLantzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = AskName();
            BobergLantz form = new BobergLantz(nombre);
            form.MdiParent = this;
            form.Show();
        }

        private void gontijoYAzisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = AskName();
            GontijoAzis form = new GontijoAzis(nombre);
            form.MdiParent = this;
            form.Show();
        }
    }
}