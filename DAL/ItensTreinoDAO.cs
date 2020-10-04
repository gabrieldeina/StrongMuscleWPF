using StrongMuscle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongMuscle.DAL {
    class ItensTreinoDAO {
        private static Context _context = SingletonContext.GetInstance();
        public static List<ItemTreino> Listar() => _context.ItensTreino.ToList();
    }
}
