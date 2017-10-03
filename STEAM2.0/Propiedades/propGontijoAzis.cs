using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEAM2._0
{
    class propGontijoAzis
    {

        [
            Description("Tasa de inyección de vapor al yacimiento [BBL/dia]"),
            DisplayName("Tasa de Inyección"),
            Category("Parámetros de Inyección"),
        ]
        public double Qiny { get; set; } 

        [
            Description("Calidad del vapor en fondo de pozo[Fraccion]"),
            DisplayName("Calidad del vapor"),
            Category("Parámetros de Inyección"),
        ]


        public double CalVapor { get; set; } 

        [
            Description("Tiempo de Inyección [días]"),
            DisplayName("Tiempo de Inyección"),
            Category("Parámetros de Inyección"),
        ]
        public double Tiny { get; set; }

        [
            Description("Tiempo de estimulación [días]"),
            DisplayName("Tiempo de estimulación"),
            Category("Parámetros de Inyección"),
        ]
        public double Test { get; set; }

        [
            Description("Tiempo de Producción [días]"),
            DisplayName("Tiempo de Producción"),
            Category("Parámetros de Inyección"),
        ]
        public double TProd { get; set; }

        [
            Description("Caudal Mínimo de Aceite [BBL/dia]"),
            DisplayName("Qmin Aceite"),
            Category("Parámetros de Inyección"),
        ]
        public double Qmin { get; set; }

        [
            Description("Máxima producción de líquidos en superficie [BBL/dia]"),
            DisplayName("STLMax"),
            Category("Parámetros de Inyección"),
        ]
        public double STLMax { get; set; }

        [
           Description("Area del Patrón [Acre]"),
           DisplayName("Area del Patrón"),
           Category("Parámetros de Inyección"),
        ]
        public double area { get; set; }

        [
            Description("Temperatura del vapor [°F]"),
            DisplayName("Temperatura del vapor"),
            Category("Parámetros de Inyección"),
        ]
        public double tempVapor { get; set; }

        [
            Description("Permeabilidad Relativa al Vapor"),
            DisplayName("Kr al Vapor"),
            Category("Parámetros de Inyección"),
        ]
        public double Kst { get; set; }


        [
           Description("Densidad del agua [lbm/ft3]"),
           DisplayName("Densidad del agua"),
           Category("Propiedades del Agua"),
           DefaultValue(typeof(double), "62.4"),
        ]
        public double densAgua { get; set; }

        [
            Description("Permeabilidad [D]"),
            DisplayName("Permeabilidad de la roca"),
            Category("Propiedades del Yacimiento"),
            ReadOnly(false)
        ]

        public double permRoca { get; set; }


        [
           Description("Espesor medio del yacimiento [ft]"),
           DisplayName("Espesor"),
           Category("Propiedades del Yacimiento"),
       ]
        public double espesor { get; set; }


        [
           Description("Número de Zonas"),
           DisplayName("Zonas"),
           Category("Propiedades del Yacimiento"),
       ]
        public double zonas { get; set; }

        [
            Description("Densidad del Crudo"),
            DisplayName("Densidad del Crudo [lbm/ft3]"),
            Category("Propiedades del Yacimiento"),
        ]
        public double densOil { get; set; }

        [
            Description("Porosidad [Fracción]"),
            DisplayName("Porosidad"),
            Category("Propiedades del Yacimiento"),
        ]
        public double por { get; set; }

        [
            Description("Saturación de agua connata"),
            DisplayName("Swcon"),
            Category("Propiedades del Yacimiento"),
        ]
        public double Swc { get; set; }

        [
            Description("Saturación de aceite residual al vapor"),
            DisplayName("Sorv"),
            Category("Propiedades del Yacimiento"),
        ]
        public double Sorv { get; set; }

        [
            Description("Saturación de aceite residual al agua"),
            DisplayName("Sorw"),
            Category("Propiedades del Yacimiento"),
        ]
        public double Sorw { get; set; }


        [
            Description("Radio del Pozo [ft]"),
            DisplayName("Radio del Pozo [ft]"),
            Category("Propiedades del Pozo"),
        ]
        public double rPozo { get; set; }

        [
            Description("Difusividad térmica de la formación [ft2/hora]"),
            DisplayName("Difusividad Térmica Formación"),
            Category("Propiedades del Yacimiento"),
        ]
        public double difTermForm { get; set; }

        [
            Description("Conductividad térmica de la formación [BTU/ft-hora-°F]"),
            DisplayName("Conductividad Térmica Formación"),
            Category("Propiedades del Yacimiento"),
        ]
        public double condTermForm { get; set; }

        [
            Description("Temperatura del yacimiento [°F]"),
            DisplayName("Temperatura del yacimiento"),
            Category("Propiedades del Yacimiento"),
        ]
        public double tempYac { get; set; }

        // Pedido de viscosidades

        [
            Description("Temperatura de la viscosidad 1 [°F]"),
            DisplayName("Temperatura para la viscosidad de referencia numero 1"),
            Category("Cálculo de viscosidad"),

        ]
        public double tvisc1 { get; set; }

        [
            Description("Temperatura de la viscosidad 2 [°F]"),
            DisplayName("Temperatura para la viscosidad de referencia numero 2"),
            Category("Cálculo de viscosidad"),

        ]
        public double tvisc2 { get; set; }

        [
            Description("Viscosidad 1 [cP]"),
            DisplayName("Viscosidad de referencia numero 1"),
            Category("Cálculo de viscosidad"),

        ]
        public double visc1 { get; set; }

        [
            Description("Viscosidad 2 [cP]"),
            DisplayName("Viscosidad de referencia numero 2"),
            Category("Cálculo de viscosidad"),

        ]
        public double visc2 { get; set; }

    }
}
