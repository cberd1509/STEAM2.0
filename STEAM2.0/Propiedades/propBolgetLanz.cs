using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEAM2._0.Propiedades
{
    class propBolgetLanz
    {
        [
            Description("Tasa de inyección de vapor al yacimiento [BBL/dia]"),
            DisplayName("Tasa de Inyección"),
            Category("Parámetros de Inyección"),
        ]
        public double Qiny { get; set; } //Esta

        [
            Description("Calidad del vapor inyectado [Fraccion]"),
            DisplayName("Calidad del vapor"),
            Category("Parámetros de Inyección"),
        ]


        public double CalVapor { get; set; } //Esta

        [
            Description("Tiempo de Inyección [días]"),
            DisplayName("Tiempo de Inyección"),
            Category("Parámetros de Inyección"),
        ]
        public double Tiny { get; set; }//Esta

        [
            Description("Tiempo de estimulación [días]"),
            DisplayName("Tiempo de estimulación"),
            Category("Parámetros de Inyección"),
        ]
        public double Test { get; set; }//Esta

        [
            Description("Tiempo de Producción [días]"),
            DisplayName("Tiempo de Producción"),
            Category("Parámetros de Inyección"),
        ]
        public double TProd { get; set; }//Esta


        [
            Description("Temperatura del vapor [°F]"),
            DisplayName("Temperatura del vapor"),
            Category("Parámetros de Inyección"),
        ]
        public double tempVapor { get; set; } //Esta

        [
            Description("Entalpía del Agua a temperatura de yacimiento (Hr) [BTU/lbm]"),
            DisplayName("Entalpía del Agua@Tyac"),
            Category("Propiedades del Agua"),
        ]
        public double hr { get; set; } //Esta

        [
            Description("Calor latente de vaporización del agua (Lv) [BTU/lbm]"),
            DisplayName("Cal. Lat. Vaporizacion"),
            Category("Propiedades del Agua"),
        ]

        public double Lv { get; set; } //Esta

        [
           Description("Densidad del agua [lbm/ft3]"),
           DisplayName("Densidad del agua"),
           Category("Propiedades del Agua"),
           DefaultValue(typeof(double), "62.4"),
        ]
        public double densAgua { get; set; } //Esta

        [
           Description("Calor específico del agua [BTU/libra-ft]"),
           DisplayName("Calor Específico Agua"),
           Category("Propiedades del Agua"),
           DefaultValue(typeof(double), "1.0"),           
        ]
        public double calEspAgua { get; set; } //Esta


        [
            Description("Permeabilidad [D]"),
            DisplayName("Permeabilidad de la roca"),
            Category("Propiedades del Yacimiento"),
            ReadOnly(false)
        ]
        public double permRoca { get; set; } //Esta

        [
            Description("Densidad del Crudo"),
            DisplayName("Densidad del Crudo [lbm/ft3]"),
            Category("Propiedades del Yacimiento"),
        ]
        public double densOil { get; set; } //Esta

        [
            Description("Calor específico del crudo"),
            DisplayName("Calor específico del crudo [BTU / lb-°F]"),
            Category("Propiedades del Yacimiento"),
        ]
        public double calEspOil { get; set; } //Esta

        [
            Description("Radio de drenaje [ft]"),
            DisplayName("Radio de drenaje [ft]"),
            Category("Propiedades del Pozo"),
        ]
        public double rDrenaje { get; set; } //Esta

        [
            Description("Radio del Pozo [ft]"),
            DisplayName("Radio del Pozo [ft]"),
            Category("Propiedades del Pozo"),
        ]
        public double rPozo { get; set; } //Esta

        [
           Description("Pwf [psi]"),
           DisplayName("Presion de fondo fluyente [psi]"),
           Category("Propiedades del Pozo"),
       ]
        public double pwf { get; set; } //Esta

        [
           Description("Presion Lim Exterior [psi]"),
           DisplayName("Presión en el límite exterior"),
           Category("Propiedades del Pozo"),
       ]
        public double ple { get; set; } //Esta

        [
            Description("Relación agua petróleo [Fracción]"),
            DisplayName("WOR"),
            Category("Propiedades del Yacimiento"),
        ]
        public double WOR { get; set; } //Esta


        [
            Description("Espesor de la formación [ft]"),
            DisplayName("Espesor de la formación"),
            Category("Propiedades del Yacimiento"),
            RefreshProperties(RefreshProperties.All)
        ]
        public double espesor { get; set; } //Esta

        [
            Description("Difusividad térmica de la formación [ft2/hora]"),
            DisplayName("Difusividad Térmica Formación"),
            Category("Propiedades del Yacimiento"),
        ]
        public double difTermForm { get; set; } //Esta

        [
            Description("Conductividad térmica de la formación [BTU/ft-hora-°F]"),
            DisplayName("Conductividad Térmica Formación"),
            Category("Propiedades del Yacimiento"),
        ]
        public double condTermForm { get; set; } //Esta

        [
            Description("Temperatura del yacimiento [°F]"),
            DisplayName("Temperatura del yacimiento"),
            Category("Propiedades del Yacimiento"),
        ]
        public double tempYac { get; set; } //Esta

        [
            Description("Numero de ciclos de inyección"),
            DisplayName("# de Ciclos"),
            Category("Parámetros de Inyección"),
        ]
        public int numCiclos { get; set; } //Esta

        [
            Description("Capacidad calorífica de la formación [BTU/ft3 - °F]"),
            DisplayName("Capacidad calorífica de la formación"),
            Category("Propiedades del Yacimiento"),
        ]
        public double capCalRoca { get; set; } //Esta

        // Pedido de viscosidades

        [
            Description("Temperatura de la viscosidad 1 [°F]"),
            DisplayName("Temperatura para la viscosidad de referencia numero 1"),
            Category("Cálculo de viscosidad"),
            
        ]
        public double tvisc1 { get; set; } //Esta

        [
            Description("Temperatura de la viscosidad 2 [°F]"),
            DisplayName("Temperatura para la viscosidad de referencia numero 2"),
            Category("Cálculo de viscosidad"),

        ]
        public double tvisc2 { get; set; } //Esta

        [
            Description("Viscosidad 1 [cP]"),
            DisplayName("Viscosidad de referencia numero 1"),
            Category("Cálculo de viscosidad"),

        ]
        public double visc1 { get; set; } //Esta

        [
            Description("Viscosidad 2 [cP]"),
            DisplayName("Viscosidad de referencia numero 2"),
            Category("Cálculo de viscosidad"),

        ]
        public double visc2 { get; set; } //Esta





    }
}
