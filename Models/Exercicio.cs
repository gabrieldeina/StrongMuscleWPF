using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StrongMuscle.Models {
    [Table("Exercicios")]
    class Exercicio : BaseModel {
        public string Nome { get; set; }
    }
}