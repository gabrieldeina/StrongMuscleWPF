using StrongMuscle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrongMuscle.DAL {
    class FuncionarioDAO {
        private static Context _context = SingletonContext.GetInstance();
        public static List<Funcionario> Listar() => _context.Funcionarios.ToList();
        public static Funcionario BuscarPorId(int id) => _context.Funcionarios.Find(id);
        public static Funcionario BuscarPorCpf(string cpf) => _context.Funcionarios.FirstOrDefault(x => x.Cpf == cpf);
        public static bool Cadastrar(Funcionario funcionario) {
            if (BuscarPorCpf(funcionario.Cpf) == null) {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static void Alterar(Funcionario funcionario) {
            _context.Funcionarios.Update(funcionario);
            _context.SaveChanges();
        }
        public static bool Login(string cpf) {
            if (BuscarPorCpf(cpf) != null) {
                return true;
            }
            return false;
        }
    }
}
