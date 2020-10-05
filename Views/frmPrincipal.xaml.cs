using StrongMuscle.DAL;
using StrongMuscle.Models;
using StrongMuscle.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StrongMuscle.Views {
    /// <summary>
    /// Interaction logic for frmPrincipal.xaml
    /// </summary>
    public partial class frmPrincipal : Window {
        public frmPrincipal() {
            InitializeComponent();
        }

        private void menuSair_Click(object sender, RoutedEventArgs e) {
            Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (MessageBox.Show("Deseja realmente sair?", "Strong Muscle", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            txtCpf.Text = txtCpf.Text.Replace(".", "").Replace("-", "");
            if (ValidarCpf.Validar(txtCpf.Text)) {
                if (FuncionarioDAO.BuscarPorCpf(txtCpf.Text) != null) {
                    Funcionario funcionario = new Funcionario();
                    funcionario = FuncionarioDAO.BuscarPorCpf(txtCpf.Text);

                    if (funcionario.Funcao.Equals("Gerente")) {
                        frmMenuGerente frm = new frmMenuGerente();
                        frm.ShowDialog();
                        txtCpf.Clear();
                    }
                    if (funcionario.Funcao.Equals("Educador Físico")) {
                        frmMenuEducador frm = new frmMenuEducador();
                        frm.ShowDialog();
                        txtCpf.Clear();
                    }
                    if (funcionario.Funcao.Equals("Estagiário")) {
                        frmEstagiario frm = new frmEstagiario();
                        frm.ShowDialog();
                        txtCpf.Clear();
                    }
                } else if (ClienteDAO.BuscarPorCpf(txtCpf.Text) != null) {
                    MessageBox.Show("Para acessar o menu de clientes, clique abaixo!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtCpf.Clear();
                } else {
                    MessageBox.Show("CPF não cadastrado!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } else {
                MessageBox.Show("CPF Inválido!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnMenuCliente_Click(object sender, RoutedEventArgs e) {
            frmCliente frm = new frmCliente();
            frm.ShowDialog();
            txtCpf.Clear();
        }
    }
}
