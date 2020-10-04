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
        Treino tr = new Treino();
        Cliente cl = new Cliente();
        private List<dynamic> exercicios = new List<dynamic>();

        public frmMenuEducador() {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            // Load Exercícios
            CarregarExercicios();
        }

        private void CarregarExercicios() {
            cboExercicios.ItemsSource = ExercicioDAO.Listar();
            cboExercicios.DisplayMemberPath = "Nome";
            cboExercicios.SelectedValuePath = "Id";
        }

        private void LimparFormulario() {
            txtNomeExercicio.Clear();
            btnCadastrarExercicio.IsEnabled = true;
            btnExcluirExercicio.IsEnabled = false;
            cboExercicios.SelectedItem = null;
            txtRepeticao.Clear();
            ex = new Exercicio();
            tr = new Treino();
            cl = new Cliente();
        }

        private void btnCadastrarExercicio_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(txtNomeExercicio.Text)) {
                ex = new Exercicio {
                    Nome = txtNomeExercicio.Text
                };
                if (ExercicioDAO.Cadastrar(ex)) {
                    MessageBox.Show($"Exercício cadastrado com sucesso", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
                    CarregarExercicios();
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

        private void btnAdicionarExercício_Click(object sender, RoutedEventArgs e) {
            ex = ExercicioDAO.BuscarPorId((int)cboExercicios.SelectedValue);
            PopularDataGrid(ex);
            PopularTreino(ex);
            cboExercicios.SelectedItem = null;
            txtRepeticao.Clear();
        }

        private void PopularDataGrid(Exercicio ex) {
            dynamic item = new {
                Nome = ex.Nome,
                Repeticoes = txtRepeticao.Text,
            };
            exercicios.Add(item);
            dtaExercicios.ItemsSource = exercicios;
            dtaExercicios.Items.Refresh();
        }

        private void PopularTreino(Exercicio ex) {
            tr.ItensTreino.Add(
                new ItemTreino {
                    Exercicio = ex,
                    Repeticao = txtRepeticao.Text
                }
            );
        }

        private void btnCadastrarTreino_Click(object sender, RoutedEventArgs e) {
            string categoria = ((ComboBoxItem)cboCategoria.SelectedItem).Content.ToString();
            string subcategoria = ((ComboBoxItem)cboSubCategoria.SelectedItem).Content.ToString();
            tr.Categoria = categoria;
            tr.SubCategoria = subcategoria;
            tr.Nome = $"{categoria} | {subcategoria}";
            TreinoDAO.Cadastrar(tr);
            MessageBox.Show("Treino cadastrado com sucesso!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
            LimparFormulario();
        }

        private void btnVincularTreino_Click(object sender, RoutedEventArgs e) {
            cl = ClienteDAO.BuscarPorId((int)cboClientes.SelectedValue);
            cl.Treino = TreinoDAO.BuscarPorId((int)cboTreinos.SelectedValue);
            ClienteDAO.Alterar(cl);
        }
    }
}
