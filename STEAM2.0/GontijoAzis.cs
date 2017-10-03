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
    public partial class GontijoAzis : MDIForm
    {
        private propGontijoAzis propiedades = new propGontijoAzis();
        public GontijoAzis(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;
            Text = nombre;
            type = "Modelo de Boberg y Lantz"; //Se especifica el tipo de ventana

            propertyGrid1.SelectedObject = propiedades;
        }

        private void ClickDemo(object sender, EventArgs e)
        {
            propiedades.Qiny = 647;
            propiedades.CalVapor = 0.7;
            propiedades.Tiny = 6;
            propiedades.Test = 5;
            propiedades.TProd = 55;
            propiedades.tempVapor = 360;
            propiedades.densAgua = 62.4;
            propiedades.permRoca = 1.5;
            propiedades.densOil = 61.8;
            propiedades.rPozo = 0.31;
            propiedades.espesor = 55;
            propiedades.difTermForm = 0.48;
            propiedades.condTermForm = 24;
            propiedades.tempYac = 110;
            propiedades.tvisc1 = 100;
            propiedades.tvisc2 = 300;
            propiedades.visc1 = 5000;
            propiedades.visc2 = 12;
            propiedades.por = 0.32;
            propiedades.Swc = 0.25;
            propiedades.Sorv = 0.05;
            propiedades.Sorw = 0.25;
            propiedades.Qmin = 1;
            propiedades.STLMax = 800;
            propiedades.area = 588;
            propiedades.zonas = 4;
            propiedades.Kst = 0.1;



            propertyGrid1.Refresh();
        }

        private void Calcular(object sender, EventArgs e)
        {
            double Qiny = propiedades.Qiny;
            double CalVapor = propiedades.CalVapor;
            double Tiny = propiedades.Tiny;
            double Test = propiedades.Test;
            double TProd = propiedades.TProd;
            double tempVapor = propiedades.tempVapor;
            double densAgua = propiedades.densAgua;
            double permRoca = propiedades.permRoca;
            double densOil = propiedades.densOil;
            double rPozo = propiedades.rPozo;
            double espesor = propiedades.espesor;
            double difTermForm = propiedades.difTermForm;
            double condTermForm = propiedades.condTermForm;
            double tempYac = propiedades.tempYac;
            double tvisc1 = propiedades.tvisc1;
            double tvisc2 = propiedades.tvisc2;
            double visc1 = propiedades.visc1;
            double visc2 = propiedades.visc2;
            double por = propiedades.por;
            double Swc = propiedades.Swc;
            double Sorv = propiedades.Sorv;
            double Sorw = propiedades.Sorw;
            double Qmin = propiedades.Qmin;
            double STLMax = propiedades.STLMax;
            double area = propiedades.area;
            double zonas = propiedades.zonas;
            double Kst = propiedades.Kst;


            //Cálculo de la presión de vapor

            double Pvap = Math.Pow(tempVapor / 115.95, 4.4543);

            //Cálculo de la densidad del vapor

            double densVap = Math.Pow(Pvap, 0.9588) / 363.9;

            //Cálculo de la viscosidad del vapor

            double visVapor = 0.001 * (0.2 * tempVapor + 82);

            //Cálculo de la viscosidad del crudo a la temperatura de inyección

            double vistempIny = calcVis(tempVapor, tvisc1, tvisc2, visc1, visc2);



        }


        double calcVis(double t3, double t1, double t2, double v1, double v2)
        {
            double v3 = Math.Exp((-t1 * t2 * Math.Log(v1) + t1 * t2 * Math.Log(v2) + t1 * t3 * Math.Log(v1) - t2 * t3 * Math.Log(v2)) / (t3 * (t1 - t2)));

            return v3;
        }

    }
}
