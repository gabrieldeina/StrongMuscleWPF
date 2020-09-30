using StrongMuscle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongMuscle.DAL {
    class TreinoDAO {

        private static Context _context = new Context();
        public static List<Treino> Listar() => _context.Treinos.ToList();
        public static void Cadastrar(Treino treino) {
            _context.Treinos.Add(treino);
            _context.SaveChanges();
        }
    }
}
