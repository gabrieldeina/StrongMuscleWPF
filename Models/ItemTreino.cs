using System;
using System.Collections.Generic;
using System.Text;

namespace StrongMuscle.Models {
    class ItemTreino : BaseModel {
        public ItemTreino() {
            Exercicio = new Exercicio();
        }
        public Exercicio Exercicio { get; set; }
        public string Repeticao { get; set; }
    }
}