using StrongMuscle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongMuscle.DAL {
    class ExercicioDAO {
        private static Context _context = new Context();
        public static List<Exercicio> Listar() => _context.Exercicios.ToList();
        public static Exercicio BuscarPorId(int id) => _context.Exercicios.Find(id);
        public static Exercicio BuscarPorNome(string nome) => _context.Exercicios.FirstOrDefault(x => x.Nome == nome);
        public static bool Cadastrar(Exercicio exercicio) {
            if (BuscarPorNome(exercicio.Nome) == null) {
                _context.Exercicios.Add(exercicio);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static void Alterar(Exercicio exercicio) {
            _context.Exercicios.Update(exercicio);
            _context.SaveChanges();
        }
        public static void Remover(Exercicio exercicio) {
            _context.Exercicios.Remove(exercicio);
            _context.SaveChanges();
        }
    }
}
