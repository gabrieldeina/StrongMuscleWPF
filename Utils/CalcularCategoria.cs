using System;
using System.Collections.Generic;
using System.Text;

namespace StrongMuscle.Utils {
    class CalcularCategoria {
        public static string Categoria(double altura, double peso) {
            double imc = peso / altura * altura;
            if (imc > 0) {
                if (imc < 21) {
                    return "Ectomorfo";
                }
                if (imc <= 25) {
                    return "Mesomorfo";
                }
                if (imc > 25) {
                    return "Endomorfo";
                }
            }
            return null;
        }
    }
}
