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
            type = "Modelo de Gontijo y Azis"; //Se especifica el tipo de ventana

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
            propiedades.espesor = 250;
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


            double Hlast = 0; //Inicialización de Hlast

            //Cálculo de la presión de vapor

            double Pvap = Math.Pow(tempVapor / 115.95, 4.4543); //Presión de vapor

            //Cálculo de la densidad del vapor

            double densVap = Math.Pow(Pvap, 0.9588) / 363.9; //Densidad del vapor

            //Cálculo de la viscosidad del vapor

            double visVapor = 0.001 * (0.2 * tempVapor + 82); //Viscosidad del vapor

            //Cálculo de la viscosidad del crudo a la temperatura de inyección

            double vistempIny = calcVis(tempVapor, tvisc1, tvisc2, visc1, visc2);

            //Cálculo del espesor de la zona

            double Ard = Math.Pow(((350 * 144 * Qiny * visVapor) / (6.328 * Math.PI * (densOil - densVap) * Math.Pow((espesor / zonas),2) * densVap * Kst)), 0.5); //Factor adimensional de flujo radial
            double hst = 0.5 * (espesor / zonas) * Ard; //Espesor de la zona de vapor

            //Cálculo del Radio

            double pct = 32.5 + ((4.6 * (Math.Pow(por, 0.32)) - 2) * (10 * Swc - 1.5)); //Capacidad calorifica isobarica volumetrica
            double hwTs = 68 * Math.Pow((tempVapor / 100),1.24); //Entalpia en superficie
            double hwTr = 68 * Math.Pow((tempYac / 100), 1.24); //Entalpia en yacimiento
            double Lvdh = 94 * Math.Pow((705 - tempVapor) , 0.38); //Calor latente de vaporización
            double cw = (hwTs - hwTr)/(tempVapor-tempYac); //Capacidad calorifica del agua
            double Qi = cw * (tempVapor - tempYac) + (Lvdh * CalVapor); //Tasa de inyección de calor
            double vsi = ((Qiny * Tiny * densAgua * Qi) - (Hlast)) / (pct * (tempVapor - tempYac)); //Volumen de Vapor Inicial
            double Rh = Math.Sqrt(vsi / (Math.PI * hst)); //Radio de la zona calentada

            //Determinacion de una temperatura promedio 

            double Tavg = (tempVapor + tempYac) / 2;

            ConsolaTB.Text = "\nIniciando cálculos para el modelo de Gontijo & Azis\n";
            ConsolaTB.AppendText("\nTemperatura promedio supuesta = "+Tavg);

            //Determinación de HlastEn

            double Hlasten = vsi* pct * (Tavg-tempYac); //Cantidad de calor que permanece en el yacimiento

            //Determinacion de Qmax

            double hiny = 350 * Qi * Qiny * Tiny; //Caudal total inyectado
            double qmax = hiny + Hlasten - (Math.PI * Math.Pow(Rh, 2) * condTermForm * (tempVapor - tempYac) * Math.Pow((Test) / (Math.PI * difTermForm), 0.5)); //Representa la cantidad de calor maximo que se le ha dado al yac
            double densacTy = (densOil - 0.0214 * (tempYac - 60));//Densidad del aceite a temp de yacimiento
            double denswaTy = (densAgua - 11 * Math.Log((705-60)/(705-tempYac)));//Densidad del aceite a temp de yacimiento
            double Mo = (3.065+0.00355*tempYac)*Math.Sqrt(densacTy); //Capacidad calorifica volumetrica del aceite
            double Mw = (cw*denswaTy); //Capacidad calorifica volumetrica del agua

            //Caudal de Aceite

            double rx = Math.Sqrt(Math.Pow(Rh,2)+espesor); //Radio a traves de la zona de aceite caliente
            double deltaSo = Sorw-Sorv; //Delta de saturacion de aceite
            double deltaH = espesor-hst; //Delta de espesor entre altura de vapor y espesor de formación
            double sent = espesor/rx; //Seno del angulo
            double deltaphi = deltaH*32.14*sent+((Pvap-50)/densacTy); //Diferencia de Potencial
            double Qo = 1.87 * rx * Math.Sqrt((permRoca * por * sent * difTermForm * deltaphi) / (Mo * vistempIny * (Math.Log(rx / rPozo) - 0.5)));
            double Qw = 1.87 * rx * Math.Sqrt((permRoca * por * deltaSo * difTermForm * deltaphi) / (Mw * 1 * (Math.Log(rx / rPozo) - 0.5)));

            ConsolaTB.AppendText("\nCaudal de Aceite = " + Qo.ToString("0.000") +" BBL/dia");
            ConsolaTB.AppendText("\nCaudal de Agua = " + Qw.ToString("0.000")+ " BBL/dia");


            //Caudal de calor removido

            double Qp = 5.615 * (Qw * Mw + Qo * Mo)*(Tavg - tempYac);//Caudal de calor removido por la formacion por la producción de los fluidos

            //Cálculo de la temperatura promedio

            double fhd=0; //Funcion adimensional de la perdida de calor radial
            double fvd=0; //Funcion de perdida de calor vertical
            double fpd=0; //Energia removida por fluidos produc
            double tdh=0;
            double tdv=0;

            for(int i = 0; i<=(Test+Tiny);i++)
            {
                tdh = difTermForm * (i - Tiny)/Math.Pow(Rh,2);
                fhd = 1 / (1 + 5 * tdh);
                tdv = 4 * difTermForm * (i - Tiny) / Math.Pow((espesor / zonas), 2);
                fvd = 1 / Math.Pow(1 + 5 * tdv, 0.5);
                fpd = (1 / (2 * qmax)) * Qp;            

            }

            Tavg = tempYac + (tempVapor - tempYac) * (fhd * fvd * (1 - fpd) - fpd);

            ConsolaTB.AppendText("\nTemperatura promedio final calculada = " +Tavg);
        }


        double calcVis(double t3, double t1, double t2, double v1, double v2)
        {
            double v3 = Math.Exp((-t1 * t2 * Math.Log(v1) + t1 * t2 * Math.Log(v2) + t1 * t3 * Math.Log(v1) - t2 * t3 * Math.Log(v2)) / (t3 * (t1 - t2)));

            return v3;
        }

    }
}
