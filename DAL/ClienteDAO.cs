using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using StrongMuscle.Models;

namespace StrongMuscle.DAL {
    class ClienteDAO {
        private static Context _context = new Context();
        public static List<Cliente> Listar() => _context.Clientes.ToList();
        public static Cliente BuscarPorId(int id) => _context.Clientes.Find(id);
        public static Cliente BuscarPorCpf(string cpf) => _context.Clientes.FirstOrDefault(x => x.Cpf == cpf);
        public static bool Cadastrar(Cliente cliente) {
            if (BuscarPorCpf(cliente.Nome) == null) {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public static void Alterar(Cliente cliente) {
            _context.Clientes.Update(cliente);
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
