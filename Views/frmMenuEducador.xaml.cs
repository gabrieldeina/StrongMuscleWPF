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
        Exercicio exercicio = new Exercicio();
        Treino treino = new Treino();
        Cliente cliente = new Cliente();
        private List<dynamic> exercicios = new List<dynamic>();

        public frmMenuEducador() {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            // Load Exercícios
            LoadComboBoxes();
        }

        private void LoadComboBoxes() {
            cboExercicios.ItemsSource = ExercicioDAO.Listar();
            cboExercicios.DisplayMemberPath = "Nome";
            cboExercicios.SelectedValuePath = "Id";
            cboClientes.ItemsSource = ClienteDAO.Listar();
            cboClientes.DisplayMemberPath = "Nome";
            cboClientes.SelectedValuePath = "Id";
            cboTreinos.ItemsSource = TreinoDAO.Listar();
            cboTreinos.DisplayMemberPath = "Nome";
            cboTreinos.SelectedValuePath = "Id";
        }

        private void LimparFormulario() {
            txtNomeExercicio.Clear();
            btnCadastrarExercicio.IsEnabled = true;
            btnExcluirExercicio.IsEnabled = false;
            cboExercicios.SelectedItem = null;
            cboClientes.SelectedItem = null;
            cboTreinos.SelectedItem = null;
            cboCategoria.SelectedItem = null;
            cboSubCategoria.SelectedItem = null;
            txtRepeticao.Clear();
            exercicio = new Exercicio();
            treino = new Treino();
            cliente = new Cliente();
            exercicios = new List<dynamic>();
        }

        private void btnCadastrarExercicio_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(txtNomeExercicio.Text)) {
                exercicio = new Exercicio {
                    Nome = txtNomeExercicio.Text
                };
                if (ExercicioDAO.Cadastrar(exercicio)) {
                    MessageBox.Show($"Exercício cadastrado com sucesso", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
                    LoadComboBoxes();
                } else {
                    MessageBox.Show($"Esse exercício já existe", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else {
                MessageBox.Show($"Preencha o nome do exercício!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBuscarExercicio_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(txtNomeExercicio.Text)) {
                exercicio = ExercicioDAO.BuscarPorNome(txtNomeExercicio.Text);
                if (exercicio != null) {
                    txtNomeExercicio.Text = exercicio.Nome;
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
            if (exercicio != null) {
                ExercicioDAO.Remover(exercicio);
                MessageBox.Show("Exercício removido com sucesso!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                LimparFormulario();
            } else {
                MessageBox.Show("Exercício não existe", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Error);
                LimparFormulario();
            }
        }

        private void btnAdicionarExercício_Click(object sender, RoutedEventArgs e) {
            if (cboExercicios.SelectedItem != null) {
                if (!string.IsNullOrWhiteSpace(txtRepeticao.Text)) {
                    exercicio = ExercicioDAO.BuscarPorId((int)cboExercicios.SelectedValue);
                    PopularDataGrid(exercicio);
                    PopularTreino(exercicio);
                    cboExercicios.SelectedItem = null;
                    txtRepeticao.Clear();
                } else {
                    MessageBox.Show("Informe o número de repetições", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } else {
                MessageBox.Show("Selecione um exercício", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
            }

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
            treino.ItensTreino.Add(
                new ItemTreino {
                    Exercicio = ex,
                    Repeticao = txtRepeticao.Text
                }
            );
        }

        private void btnCadastrarTreino_Click(object sender, RoutedEventArgs e) {
            if (cboCategoria.SelectedItem != null) {
                if (cboSubCategoria.SelectedItem != null) {
                    if (exercicios.Count > 3) {
                        string categoria = ((ComboBoxItem)cboCategoria.SelectedItem).Content.ToString();
                        string subcategoria = ((ComboBoxItem)cboSubCategoria.SelectedItem).Content.ToString();
                        treino.Categoria = categoria;
                        treino.SubCategoria = subcategoria;
                        treino.Nome = $"{categoria} | {subcategoria}";
                        TreinoDAO.Cadastrar(treino);
                        MessageBox.Show("Treino cadastrado com sucesso!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparFormulario();
                        LoadComboBoxes();
                    } else {
                        MessageBox.Show("O treino deve ter mais de 3 exercícios", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                } else {
                    MessageBox.Show("Selecione uma subcategoria", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } else {
                MessageBox.Show("Selecione uma categoria", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
