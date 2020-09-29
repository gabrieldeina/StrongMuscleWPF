using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StrongMuscle.Models {
    [Table("Clientes")]
    class Cliente : Pessoa {
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Categoria { get; set; }
        public Treino Treino { get; set; }
    }
}