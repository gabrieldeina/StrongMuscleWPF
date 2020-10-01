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
    /// Interaction logic for frmMenuEducador.xaml
    /// </summary>
    public partial class frmMenuEducador : Window {
        Exercicio ex = new Exercicio();
        public frmMenuEducador() {
            InitializeComponent();
        }

        private void LimparFormulario() {
            txtNomeExercicio.Clear();
            btnCadastrarExercicio.IsEnabled = true;
            btnExcluirExercicio.IsEnabled = false;
            ex = new Exercicio();
        }

        private void btnCadastrarExercicio_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(txtNomeExercicio.Text)) {
                ex = new Exercicio {
                    Nome = txtNomeExercicio.Text
                };
                if (ExercicioDAO.Cadastrar(ex)) {
                    MessageBox.Show($"Exercício cadastrado com sucesso", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
                } else {
                    MessageBox.Show($"Esse exercício já existe", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else {
                MessageBox.Show($"Preencha o nome do exercício!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBuscarExercicio_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(txtNomeExercicio.Text)) {
                ex = ExercicioDAO.BuscarPorNome(txtNomeExercicio.Text);
                if (ex != null) {
                    txtNomeExercicio.Text = ex.Nome;
                    btnCadastrarExercicio.IsEnabled = false;
                    btnExcluirExercicio.IsEnabled = true;
                } else {
                    MessageBox.Show($"Esse exercício não existe!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } else {
                MessageBox.Show($"Preencha o nome do exercício!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnExcluirExercicio_Click(object sender, RoutedEventArgs e) {
            if (ex != null) {
                ExercicioDAO.Remover(ex);
                MessageBox.Show("Exercício removido com sucesso!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                LimparFormulario();
            } else {
                MessageBox.Show("Exercício não existe", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Error);
                LimparFormulario();
            }
        }
    }
}
