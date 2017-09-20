using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEAM2._0
{

    
    class propVapor
    {

        [
            Description("Tasa de inyección de vapor al yacimiento [BBL/dia]"),
            DisplayName("Tasa de Inyección"),
            Category("Parámetros de Inyección"),
        ]
        public double Qiny { get; set; }

        [
            Description("Calidad del vapor inyectado [Fraccion]"),
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
            Description("Temperatura del vapor [°F]"),
            DisplayName("Temperatura del vapor"),
            Category("Parámetros de Inyección"),
        ]
        public double tempVapor { get; set; }


        [
            Description("Entalpía del Agua Saturada (Hw) [BTU/lbm]"),
            DisplayName("Entalpía del Agua Saturada"),
            Category("Propiedades del Agua"),
        ]
        public double hw { get; set; }


        [
            Description("Entalpía del Agua a temperatura de yacimiento (Hr) [BTU/lbm]"),
            DisplayName("Entalpía del Agua@Tyac"),
            Category("Propiedades del Agua"),
        ]
        public double hr { get; set; }

        [
            Description("Calor latente de vaporización del agua (Lv) [BTU/lbm]"),
            DisplayName("Cal. Lat. Vaporizacion"),
            Category("Propiedades del Agua"),
        ]

        public double Lv { get; set; }

        [
           Description("Densidad del agua [lbm/ft3]"),
           DisplayName("Densidad del agua"),
           Category("Propiedades del Agua"),
           DefaultValue(typeof(double),"62.4"),
           ReadOnly(true)
        ]
        public double densAgua { get; set; }

        [
           Description("Calor específico del agua [BTU/libra-ft]"),
           DisplayName("Calor Específico Agua"),
           Category("Propiedades del Agua"),
           DefaultValue(typeof(double), "1.0"),
           ReadOnly(true)
        ]
        public double calEspAgua { get; set; }


        [
            Description("Porosidad de la roca [Fracción]"),
            DisplayName("Porosidad"),
            Category("Propiedades del Yacimiento"),
        ]
        public double por { get; set; }


        [
            Description("Densidad de la roca [lbm/ft3]"),
            DisplayName("Densidad"),
            Category("Propiedades del Yacimiento"),
            ReadOnly(true)
        ]
        public double densRoca { get; set; }

        [
            Description("Gravedad específica del crudo"),
            DisplayName("Gravedad Específica Crudo"),
            Category("Propiedades del Yacimiento"),
            ReadOnly(true)
        ]
        public double SGOil { get; set; }

        [
            Description("Calor específico de la roca [BTU/libra-ft]"),
            DisplayName("Cal. Esp. Roca"),
            Category("Propiedades del Yacimiento"),
            ReadOnly(true)
        ]
        public double calEspRoca { get; set; }

        [
            Description("Saturación del crudo [fracción]"),
            DisplayName("Saturación de crudo"),
            Category("Propiedades del Yacimiento"),
        ]
        public double SatOil { get; set; }

        [
            Description("Espesor de la formación [ft]"),
            DisplayName("Espesor de la formación"),
            Category("Propiedades del Yacimiento"),
            RefreshProperties(RefreshProperties.All)
        ]
        public double espesor { get; set; }

        [
            Description("Difusividad térmica de la formación [BTU/ft-hora-°F]"),
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

        [
            Description("Saturación de aceite remanente al vapor [°F]"),
            DisplayName("SOR"),
            Category("Propiedades del Yacimiento"),
        ]
        public double sor { get; set; }

        [
            Description("Capacidad calorífica de la formación [BTU/ft3 - °F]"),
            DisplayName("Capacidad calorífica de la formación"),
            Category("Propiedades del Yacimiento"),
            DefaultValue(typeof(bool),"False"),
            ReadOnly(false)
        ]
        public double capCalRoca { get; set; }


        private bool calculo;

        [
            Description("Tipo de calculo para la capacidad calorífica"),
            DisplayName("Calcular capacidad calorifica"),
            Category("Propiedades del Yacimiento"),
            RefreshProperties(RefreshProperties.All)
        ]
        public bool Calculo {
            get
            {
                return this.calculo;
            }

            set
            {
                this.calculo = value;
                
                if(Calculo)
                {
                    disableField("capCalRoca", true);

                    disableField("calEspRoca", false);
                    disableField("densAgua", false);
                    disableField("densRoca", false);
                    disableField("SGOil", false);
                    disableField("calEspAgua", false);
                }
                else
                {
                    disableField("capCalRoca", false);

                    disableField("calEspRoca", true);
                    disableField("densAgua", true);
                    disableField("densRoca", true);
                    disableField("SGOil", true);
                    disableField("calEspAgua", true);
                }
                
            }
        }

        private void disableField(string Nombre, bool state)
        {
            PropertyDescriptor p1 = TypeDescriptor.GetProperties(this.GetType())[Nombre];
            ReadOnlyAttribute attr = p1.Attributes[typeof(ReadOnlyAttribute)] as ReadOnlyAttribute;
            System.Reflection.FieldInfo aField = attr.GetType().GetField("isReadOnly", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aField.SetValue(attr, state);
        }

    }
}
