using STEAM2._0.Propiedades;
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
    public partial class BobergLantz : MDIForm
    {
        public double beta;

        private propBolgetLanz propiedades = new propBolgetLanz();

        public BobergLantz(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;
            Text = nombre;
            type = "Modelo de Boberg y Lantz"; //Se especifica el tipo de ventana

            propertyGrid1.SelectedObject = propiedades;
        }

        private void BobergLantz_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            propiedades.Qiny = 1370;
            propiedades.CalVapor = 0.8;
            propiedades.Tiny = 35;
            propiedades.Test = 10;
            propiedades.TProd = 360;
            propiedades.tempVapor = 604;
            propiedades.hr = 70;
            propiedades.Lv = 504.3;
            propiedades.densAgua = 62.4;
            propiedades.calEspAgua = 1;
            propiedades.permRoca = 2.5;
            propiedades.densOil = 60;
            propiedades.calEspOil = 0.5;
            propiedades.rDrenaje = 70;
            propiedades.rPozo = 0.33333;
            propiedades.pwf = 87;
            propiedades.ple = 400;
            propiedades.WOR = 1;
            propiedades.espesor = 55;
            propiedades.difTermForm = 0.04;
            propiedades.condTermForm = 1.4;
            propiedades.tempYac = 70;
            propiedades.numCiclos = 1;
            propiedades.capCalRoca = 35;
            propiedades.tvisc1 = 60;
            propiedades.tvisc2 = 200;
            propiedades.visc1 = 156210.4;
            propiedades.visc2 = 220.13;


            propertyGrid1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Qiny = propiedades.Qiny;
            double CalVapor = propiedades.CalVapor;
            double Tiny = propiedades.Tiny;
            double Test = propiedades.Test;
            double TProd = propiedades.TProd;
            double tempVapor = propiedades.tempVapor;
            double hr = propiedades.hr;
            double Lv = propiedades.Lv;
            double densAgua = propiedades.densAgua;
            double calEspAgua = propiedades.calEspAgua;
            double permRoca = propiedades.permRoca;
            double densOil = propiedades.densOil;
            double calEspOil = propiedades.calEspOil;
            double rDrenaje = propiedades.rDrenaje;
            double rPozo = propiedades.rPozo;
            double pwf = propiedades.pwf;
            double ple = propiedades.ple;
            double WOR = propiedades.WOR;
            double espesor = propiedades.espesor;
            double difTermForm = propiedades.difTermForm;
            double condTermForm = propiedades.condTermForm;
            double tempYac = propiedades.tempYac;
            double numCiclos = propiedades.numCiclos;
            double capCalRoca = propiedades.capCalRoca;
            double tvisc1 = propiedades.tvisc1;
            double tvisc2 = propiedades.tvisc2;
            double visc1 = propiedades.visc1;
            double visc2 = propiedades.visc2;
        }
    }
}
