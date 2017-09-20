using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MN = Meta.Numerics;

namespace STEAM2._0
{
    public partial class MandlVolek : MDIForm
    {

        public double beta;

        private propMandlVolek propiedades = new propMandlVolek();

        /*La clase de todos los formularios MDI hereda de una superclase MDIForm que contendrá metodos comunes a todos los formularios. 
        Además,tendra alguna información de campos en comun como el nombre y el tipo de ventana*/
        public MandlVolek(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;
            Text = nombre;
            type = "Modelo de Mandl y Volek"; //Se especifica el tipo de ventana

            propertyGrid1.SelectedObject = propiedades;
        }

 

        private void MandlVolek_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            propiedades.Qiny = 600;
            propiedades.hw = 415.4;
            propiedades.hr = 85;
            propiedades.CalVapor = 0.7;
            propiedades.Lv = 799.1;
            propiedades.por = 0.32;
            propiedades.densRoca = 142;
            propiedades.Calculo = true;
            propiedades.SGOil = 0.99;
            propiedades.calEspRoca = 0.252;
            propiedades.SatOil = 0.75;
            propiedades.densAgua = 62.4;
            propiedades.calEspAgua = 1;
            propiedades.espesor = 205;
            propiedades.difTermForm = 0.02;
            propiedades.condTermForm = 1.2;
            propiedades.tempVapor = 360;
            propiedades.tempYac = 75;
            propiedades.sor = 0.15;
            propiedades.Tiny = 5000;

            propertyGrid1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var watch = System.Diagnostics.Stopwatch.StartNew();
            ConsolaTB.Text = "\nIniciando cálculos para el modelo de Mandl & Volek\n";
            progressBar1.Value = 0;

            double Qiny, hw, hr, CalVapor, Lv, por, densRoca, SGOil, calEspRoca, SatOil, Sw, densAgua, calEspAgua, espesor, difTermForm, condTermForm, tempVapor, tempYac, sor, Tiny;

            Qiny = propiedades.Qiny;
            hw = propiedades.hw;
            hr = propiedades.hr;
            CalVapor = propiedades.CalVapor;
            Lv = propiedades.Lv;
            por = propiedades.por;
            densRoca = propiedades.densRoca;
            SGOil = propiedades.SGOil;
            calEspRoca = propiedades.calEspRoca;
            SatOil = propiedades.SatOil;
            densAgua = propiedades.densAgua;
            calEspAgua = propiedades.calEspAgua;
            espesor = propiedades.espesor;
            difTermForm = propiedades.difTermForm;
            condTermForm = propiedades.condTermForm;
            tempVapor = propiedades.tempVapor;
            tempYac = propiedades.tempYac;
            sor = propiedades.sor;
            Tiny = propiedades.Tiny;
            Sw = 1 - SatOil;

            bool Calculo = propiedades.Calculo;

            double capCalForm;

            if (!Calculo)
            {
                capCalForm = propiedades.capCalRoca;
                ConsolaTB.AppendText("\nCapacidad Calorífica de la Formación = " + capCalForm.ToString("F5") + " BTU/ft3-°F");
            }
            else
            {
                double densidadCrudo = SGOil * 62.4;
                double calEspCrudo = 0.388 + (0.00045 * tempYac) / Math.Pow(propiedades.SGOil, 0.5);

                ConsolaTB.AppendText("\nLa capacidad calorífica será calculada\n");
                ConsolaTB.AppendText("\nCalor específico del crudo = " + calEspCrudo.ToString("F5"));

                capCalForm = (1 - por) * densRoca * calEspRoca + por * (densidadCrudo * calEspCrudo * SatOil + densAgua * calEspAgua * (Sw));
                ConsolaTB.AppendText("\nCap Calorífica Formación = " + capCalForm.ToString("F5") + " BTU/ft3-°F");
            }

            beta = Math.Pow(1 + (Lv * CalVapor / (calEspAgua * (tempVapor - tempYac))), -1);
            ConsolaTB.AppendText("\nParámetro Mandi & Volek= " + beta.ToString("F3"));

            MN.Interval inter = MN.Interval.FromEndpoints(0, 1);
            double xi = MN.Analysis.FunctionMath.FindZero(errorComp, inter);

            string erp = (100 * (MN.Functions.AdvancedMath.Erfc(xi) - beta) / MN.Functions.AdvancedMath.Erfc(xi)).ToString("F5");

            ConsolaTB.AppendText("\n% Error Xiterado vs Parámetro Mandi & Volek = " + erp);

            double tc = Math.Pow((xi * capCalForm * espesor * Math.Pow(difTermForm, 0.5)) / (2 * condTermForm), 2);

            ConsolaTB.AppendText("\nTiempo critico = "+tc.ToString("F3")+" horas");

            double Qi = (350.0 / 24.0) * Qiny * ((hw - hr) + CalVapor * Lv); //Tasa de inyección de calor

            ConsolaTB.AppendText("\nTasa de Inyección de Calor = " + Qi.ToString("F3") + " BTU/día\n");

            progressBar1.Value = 20;

            /* Comienzo de la corrida de calculos */


            DataTable caudales = OfficeHandler.createTable("Tiempo", "Caudal");

            double tiempo=0;

            /*Calculo con Marx y Langhenheim */

            ConsolaTB.AppendText("\nCalculando tasas de flujo en región menor a Tc con Marx & Langhenheim:\n\n");

            while(tiempo<tc && tiempo<(Tiny*24))
            {
                tiempo = tiempo + 24;

                double X = ((2 * propiedades.condTermForm) / (capCalForm * propiedades.espesor * Math.Pow(propiedades.difTermForm, 0.5))) * Math.Pow(tiempo, 0.5);

                double error = MN.Functions.AdvancedMath.Erfc(X);

                double q0 = 4.274 * (Qi * propiedades.por * (propiedades.SatOil - propiedades.sor) * error) / (capCalForm * (propiedades.tempVapor - propiedades.tempYac));

                ConsolaTB.AppendText("\nT=" + tiempo + " horas \t Q=" + q0.ToString("F3") + " BBL/dia");

                caudales.Rows.Add(tiempo, q0);                
            }

            progressBar1.Value = 70;

            if (tiempo <= Tiny * 24) { ConsolaTB.AppendText("\n\nCalculando tasas de flujo en región mayor a Tc con Mandl & Volek: "); }

            while(tiempo<=Tiny*24)
            {
                tiempo = tiempo + 24;
                double X = ((2 * propiedades.condTermForm) / (capCalForm * propiedades.espesor * Math.Pow(propiedades.difTermForm, 0.5))) * Math.Pow(tiempo, 0.5);

                double error = MN.Functions.AdvancedMath.Erfc(X);

                double t1 = 4.274 * (Qi * propiedades.por * (propiedades.SatOil - propiedades.sor) ) / (capCalForm * (propiedades.tempVapor - propiedades.tempYac));

                double xdiff = Math.Pow(X, 2) - Math.Pow(MN.Functions.AdvancedMath.Erfc(xi), 2);

                double t2 = (1 - ((xdiff - 2) * Math.Pow(xdiff, 0.5) / (3 * Math.Pow(Math.PI, 0.5)))-((xdiff-3)/(6*Math.Pow(Math.PI*xdiff,0.5))))*error;

                double t3 = ((1 / (3 * Math.PI)) * (xdiff - 2 + (Math.Pow(MN.Functions.AdvancedMath.Erfc(xi), 2) / 2 * Math.Pow(X, 2))) * Math.Pow(xdiff / X, 0.5))-(beta/(2*Math.Pow(Math.PI*xdiff,0.5)));

                double q0 = t1 * (t2+t3);

                ConsolaTB.AppendText("\nT=" + tiempo + " horas \t Q=" + q0.ToString("F3") + " BBL/dia");

                caudales.Rows.Add(tiempo, q0);                

            }

            progressBar1.Value = 95;

            double Acumulado = 0;

            foreach (DataRow row in caudales.Rows)
            {
                Acumulado = Acumulado + Double.Parse(row["Caudal"].ToString());
            }

            watch.Stop();
            double elapsedMs = watch.ElapsedMilliseconds;

            ConsolaTB.AppendText("\n\nCálculos finalizados. \nTiempo total = " + propiedades.Tiny.ToString("F2") + " días\nAcumulado= " + Acumulado.ToString("F3") + " Barriles \nTiempo de calculo=" + elapsedMs / 1000 + " segundos");

            progressBar1.Value = 100;

            if (MessageBox.Show("Cálculos finalizados, ¿ Desea exportar a excel los resultados ?", "Cálculos finalizados", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                OfficeHandler.exportExcel(caudales);
            }

        }

        private double errorComp(double x)
        {

            return beta-MN.Functions.AdvancedMath.Erfc(x);
        }

    }
}
