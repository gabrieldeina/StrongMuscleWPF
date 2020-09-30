using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StrongMuscle.Models {
    [Table("Funcionarios")]
    class Funcionario : Pessoa {
        public string Funcao { get; set; }
    }
}
