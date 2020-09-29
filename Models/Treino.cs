using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StrongMuscle.Models {
    [Table("Treinos")]
    class Treino : BaseModel {
        public Treino() {
            ItemExercicios = new List<ItemTreino>();
        }
        public char Categoria { get; set; }
        public char SubCategoria { get; set; }
        public List<ItemTreino> ItemExercicios { get; set; }
    }
}