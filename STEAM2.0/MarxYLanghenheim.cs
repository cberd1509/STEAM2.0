using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MN = Meta.Numerics.Functions;

namespace STEAM2._0
{

    /*La clase de todos los formularios MDI hereda de una superclase MDIForm que contendrá metodos comunes a todos los formularios. 
     Además,tendra alguna información de campos en comun como el nombre y el tipo de ventana*/
   
    public partial class MarxYLanghenheim : MDIForm
    {
        private propMarxYLangenheim propiedades = new propMarxYLangenheim();
        public MarxYLanghenheim(string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;
            Text = nombre;
            type = "Modelo de Marx y Langhenheim"; //Se especifica el tipo de ventana

            propertyGrid1.SelectedObject = propiedades;
        }

        private void MarxYLanghenheim_Activated(object sender, EventArgs e)
        {
            
        }

        private void MarxYLanghenheim_Load(object sender, EventArgs e)
        {

        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            ConsolaTB.Text = "\nIniciando cálculos para el modelo de Marx & Langhenheim\n";
            progressBar1.Value = 0;

            double capCalForm;
            double Sw = 1 - propiedades.SatOil;

            if(!propiedades.Calculo)
            {
                capCalForm = propiedades.capCalRoca;
                ConsolaTB.AppendText("\nCapacidad Calorífica de la Formación = " + capCalForm.ToString("F5") + " BTU/ft3-°F");
            }
            else
            {
                double densidadCrudo = propiedades.SGOil * 62.4;
                double calEspCrudo = 0.388 + (0.00045 * propiedades.tempYac) / Math.Pow(propiedades.SGOil, 0.5);

                ConsolaTB.AppendText("\nLa capacidad calorífica será calculada\n");
                ConsolaTB.AppendText("\nCalor específico del crudo = "+calEspCrudo.ToString("F5"));

                capCalForm = (1 - propiedades.por) * propiedades.densRoca * propiedades.calEspRoca + propiedades.por * (densidadCrudo * calEspCrudo * propiedades.SatOil + propiedades.densAgua * propiedades.calEspAgua * (Sw));
                ConsolaTB.AppendText("\nCap Calorífica Formación = " + capCalForm.ToString("F5") + " BTU/ft3-°F");
            }

            progressBar1.Value = 10;

            double Qi = (350.0 / 24.0) * propiedades.Qiny * ((propiedades.hw - propiedades.hr) + propiedades.CalVapor * propiedades.Lv); //Tasa de inyección de calor

            ConsolaTB.AppendText("\nTasa de Inyección de Calor = "+Qi.ToString("F3") + " BTU/día\n");

            DataTable caudales = OfficeHandler.createTable("Tiempo", "Caudal");
            progressBar1.Value = 15;

            ConsolaTB.AppendText("\nCalculando tasas de flujo: ");

            for (int i = 1; i < propiedades.Tiny; i++)
            {
                int t = i * 24;

                double X = ((2 * propiedades.condTermForm) / (capCalForm * propiedades.espesor * Math.Pow(propiedades.difTermForm, 0.5))) * Math.Pow(t, 0.5);

                double error = MN.AdvancedMath.Erfc(X);

                double q0 = 4.274 * (Qi * propiedades.por * (propiedades.SatOil - propiedades.sor) * error) / (capCalForm * (propiedades.tempVapor - propiedades.tempYac));

                ConsolaTB.AppendText("\nT="+t+" horas \t Q="+q0.ToString("F3") + " BBL/dia");

                caudales.Rows.Add(t,q0);
            }

            progressBar1.Value = 80;

            double Acumulado = 0;

            foreach(DataRow row in caudales.Rows)
            {
                Acumulado = Acumulado + Double.Parse(row["Caudal"].ToString());
            }

            watch.Stop();
            double elapsedMs = watch.ElapsedMilliseconds;

            ConsolaTB.AppendText("\n\nCálculos finalizados. \nTiempo total = " + propiedades.Tiny.ToString("F2") + " días\nAcumulado= " + Acumulado.ToString("F3") + " Barriles \nTiempo de calculo="+elapsedMs/1000+" segundos");

            progressBar1.Value = 100;

            if(MessageBox.Show("Cálculos finalizados, ¿ Desea exportar a excel los resultados ?", "Cálculos finalizados", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                OfficeHandler.exportExcel(caudales);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            propiedades.Qiny = 647;
            propiedades.hw = 862.85;
            propiedades.hr = 78.02;
            propiedades.CalVapor = 0.7;
            propiedades.Lv = 1195.2;
            propiedades.por = 0.32;
            propiedades.densRoca = 142;
            propiedades.Calculo = true;
            propiedades.SGOil = 0.99;
            propiedades.calEspRoca = 0.252;
            propiedades.SatOil = 0.75;
            propiedades.densAgua = 62.4;
            propiedades.calEspAgua = 1;
            propiedades.espesor = 80;
            propiedades.difTermForm = 0.02;
            propiedades.condTermForm = 1;
            propiedades.tempVapor = 360;
            propiedades.tempYac = 110;
            propiedades.sor = 0.05;
            propiedades.Tiny = 200;

            propertyGrid1.Refresh();

        }
    }
}
