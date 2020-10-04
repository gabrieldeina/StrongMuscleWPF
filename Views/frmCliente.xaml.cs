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
    /// Interaction logic for frmCliente.xaml
    /// </summary>
    public partial class frmCliente : Window {
        private List<ItemTreino> exercicios = new List<ItemTreino>();
        public frmCliente() {
            InitializeComponent();
        }

        private void btnBuscarTreino_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(txtCpf.Text)) {
                txtCpf.Text = txtCpf.Text.Replace(".", "").Replace("-", "");
                if (ValidarCpf.Validar(txtCpf.Text)) {
                    if (ClienteDAO.BuscarPorCpf(txtCpf.Text) != null) {
                        Cliente cliente = ClienteDAO.BuscarPorCpf(txtCpf.Text);
                        if (cliente.Treino != null) {
                            PopularDataGrid(cliente.Treino);
                            MessageBox.Show("Acertou", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                        } else {
                            MessageBox.Show("Cliente sem treino, fale com um educador", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    } else {
                        MessageBox.Show("Cliente não cadastrado, fale com o gerente", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                } else {
                    MessageBox.Show("CPF inválido", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } else {
                MessageBox.Show("Informe o CPF", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void PopularDataGrid(Treino treino) {
            exercicios = ItensTreinoDAO.Listar();

            foreach (ItemTreino itemTreino in exercicios) {
                dynamic item = new {
                    Nome = itemTreino.Exercicio.Nome,
                    Repeticoes = itemTreino.Repeticao,
                };
                exercicios.Add(item);
                dtaTreino.ItemsSource = exercicios;
                dtaTreino.Items.Refresh();
            }
        }
    }
}
