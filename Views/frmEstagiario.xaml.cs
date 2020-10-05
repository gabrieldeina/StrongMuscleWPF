using StrongMuscle.DAL;
using StrongMuscle.Models;
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
    /// Interaction logic for frmEstagiario.xaml
    /// </summary>
    public partial class frmEstagiario : Window {
        Cliente cliente = new Cliente();
        public frmEstagiario() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            cboClientes.ItemsSource = ClienteDAO.Listar();
            cboClientes.DisplayMemberPath = "Nome";
            cboClientes.SelectedValuePath = "Id";
            cboTreinos.ItemsSource = TreinoDAO.Listar();
            cboTreinos.DisplayMemberPath = "Nome";
            cboTreinos.SelectedValuePath = "Id";
        }

        private void LimparFormulario() {
            cboClientes.SelectedItem = null;
            cboTreinos.SelectedItem = null;
        }

        private void btnVincularTreino_Click(object sender, RoutedEventArgs e) {
            if (cboClientes.SelectedItem != null) {
                if (cboTreinos.SelectedItem != null) {
                    cliente = ClienteDAO.BuscarPorId((int)cboClientes.SelectedValue);
                    cliente.Treino = TreinoDAO.BuscarPorId((int)cboTreinos.SelectedValue);
                    ClienteDAO.Alterar(cliente);
                    MessageBox.Show("Treino vinculado ao cliente", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
                } else {
                    MessageBox.Show("Selecione um treino", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } else {
                MessageBox.Show("Selecione um cliente", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
