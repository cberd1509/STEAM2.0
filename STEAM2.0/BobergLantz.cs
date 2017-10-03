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
            propiedades.tempVapor = 604.19;
            propiedades.hr = 70;
            propiedades.Lv = 540.13;
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
            propiedades.tvisc1 = 70;
            propiedades.tvisc2 = 337;
            propiedades.visc1 = 87104;
            propiedades.visc2 = 3.321;


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


            //Determinación de la tasa de inyección de calor

            double Qi = (350.0 / 24.0) * Qiny * ((tempVapor - hr) + (CalVapor * Lv));

            //Determinación tiempo adimensional

            double td = (4 * condTermForm * capCalRoca * (capCalRoca * 24)) / (Math.Pow(capCalRoca, 2) * Math.Pow(espesor, 2));

            //Determinacion de la Función de Marx y Langenheim

            double Fm = (td) / (1 + 0.85 * Math.Pow(td, (0.5)));

            //Determinación de As a tiempo t

            double As = (Qi * Tiny * espesor * Fm) / (4 * condTermForm * capCalRoca * (tempVapor - hr));

            //Rh Radio de la zona calentada

            double Rh = Math.Pow(As / Math.PI, 0.5);


            //Controles de la Iteración

            double TavgPrev = 0;
            double TavgActual = 0;
            double iterCount = 0;
            double Qo=0;

            //Fin de Controles de la iteración

            while (true)
            {
                iterCount++;

                double Tavg;

                if (TavgActual == 0)
                {
                    //Temperatura Promedio
                    Tavg = (tempVapor + tempYac) / 2;
                }
                else
                {
                    //Temperatura Promedio
                    Tavg = TavgActual;
                }

                //Viscosidad a Tavg

                double visAvg = calcVis(Tavg, tvisc1, tvisc2, visc1, visc2);

                //Viscosidad a TR

                double visTR = calcVis(tempYac, tvisc1, tvisc2, visc1, visc2);

                //Tasa en Frío

                double QoC = (2 * Math.PI * 1.127 * espesor * permRoca * (ple - pwf) / (visTR * Math.Log(rDrenaje / rPozo)));

                //Tasa en Caliente

                double QoH = (2 * Math.PI * espesor * permRoca * (ple - pwf)) / (visTR * Math.Log((rDrenaje) / (Rh)) + visAvg * Math.Log((Rh) / (rPozo)));

                // Espesor Aumentado

                double Hra = (espesor * td) / (Fm);

                //X y Y

                double X = Math.Log10((condTermForm * (Test * 24)) / (capCalRoca * Math.Pow(Rh, 2)));
                double Y = Math.Log10((4 * condTermForm * (Test * 24)) / (capCalRoca * Math.Pow(Hra, 2)));

                //Vr y Vz

                double Vr = 0.180304 - 0.41269 * (X) + 0.18217 * Math.Pow(X, 2) + 0.149516 * Math.Pow(X, 3) + 0.024183 * Math.Pow(X, 4);
                double Vz = 0.474884 - 0.56832 * (Y) - 0.239719 * Math.Pow(Y, 2) - 0.035737 * Math.Pow(Y, 3);

                // Hog

                double Hog = (5.615 * densOil * calEspOil) * (Tavg - tempYac);

                //Ps

                double Ps = Math.Pow((Tavg / 115.1), (1 / 0.225));

                //Rs
                double Rs = 0;
                if (Ps > pwf)
                {
                    Rs = 1;
                }

                //Hw a Tavg

                double HwTavg = 1 * (Tavg - 32);

                //Hra a Tyac

                double HwTyac = 1 * (tempYac - 32);

                //Lv a Tavg

                double LvTavg = 1318 * Math.Pow(Ps, -0.08774);

                //Hws

                double Hws = (5.615 * densAgua * (Rs * (HwTavg - HwTyac) + Rs * LvTavg));

                //Hf

                double Hf = (QoH) * (Hog + Hws);

                //Delta energia

                double delta = (Hf * 10) / (Math.PI * Math.Pow(Rh, 2) * (Hra) * capCalRoca * (tempVapor - hr) * 2);

                //Tavg 2

                double Tavg2 = tempYac + (tempVapor - hr) * (Vr * Vz * (1 - delta) - delta);

                TavgActual = Tavg2;
                TavgPrev = Tavg;

                double Ea = (Math.Abs(TavgActual - TavgPrev) / TavgPrev);

                if(Ea<0.00000000000005 || iterCount>100)
                {
                    Qo = QoH;
                    break;
                }
                else
                {
                    ConsolaTB.AppendText("Iteracion " + iterCount + "\n");
                    ConsolaTB.AppendText("Tavg Anterior " + TavgPrev + "\n");
                    ConsolaTB.AppendText("Tavg Calculada " + TavgActual + "\n");
                    ConsolaTB.AppendText("Err. Rel " + Ea + "\n\n");
                }        

            }

            ConsolaTB.AppendText("==========================\n");
            ConsolaTB.AppendText("Caudal de Crudo: "+Qo+" BBL/day");


        }

        double calcVis(double t3, double t1, double t2, double v1, double v2)
        {
            double v3 = Math.Exp((-t1 * t2 * Math.Log(v1) + t1 * t2 * Math.Log(v2) + t1 * t3 * Math.Log(v1) - t2 * t3 * Math.Log(v2)) / (t3 * (t1 - t2)));

            return v3;
        }
        
    }
}
