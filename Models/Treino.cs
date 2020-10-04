using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StrongMuscle.Models {
    [Table("Treinos")]
    class Treino : BaseModel {
        public Treino() {
            ItensTreino = new List<ItemTreino>();
        }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public List<ItemTreino> ItensTreino { get; set; }
    }
}