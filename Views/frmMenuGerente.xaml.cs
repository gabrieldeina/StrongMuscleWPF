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
    /// Interaction logic for frmMenuGerente.xaml
    /// </summary>
    public partial class frmMenuGerente : Window {
        Funcionario f = new Funcionario();
        Cliente c = new Cliente();
        public frmMenuGerente() {
            InitializeComponent();
        }

        private void LimparFormulario() {
            txtNomeFuncionario.Clear();
            txtCpfFuncionario.Clear();
            txtTelefoneFuncionario.Clear();
            cboFuncao.SelectedItem = null;
            txtNomeCliente.Clear();
            txtCpfCliente.Clear();
            txtTelefoneCliente.Clear();
            txtAlturaCliente.Clear();
            txtPesoCliente.Clear();
            f = new Funcionario();
            c = new Cliente();
        }

        private void btnCadastrarFuncionario_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(txtNomeFuncionario.Text)) {
                if (!string.IsNullOrWhiteSpace(txtCpfFuncionario.Text)) {
                    txtCpfFuncionario.Text = txtCpfFuncionario.Text.Replace(".", "").Replace("-", "");
                    if (ValidarCpf.Validar(txtCpfFuncionario.Text)) {
                        if (!string.IsNullOrWhiteSpace(txtTelefoneFuncionario.Text)) {
                            txtTelefoneFuncionario.Text = txtTelefoneFuncionario.Text.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "");
                            if (cboFuncao.SelectedItem != null) {
                                f = new Funcionario {
                                    Nome = txtNomeFuncionario.Text,
                                    Cpf = txtCpfFuncionario.Text,
                                    Telefone = txtTelefoneFuncionario.Text,
                                    Funcao = ((ComboBoxItem)cboFuncao.SelectedItem).Content.ToString()
                                };
                                if (FuncionarioDAO.Cadastrar(f)) {
                                    MessageBox.Show($"Funcionário cadastrado com sucesso!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                                    LimparFormulario();
                                } else {
                                    MessageBox.Show($"Funcionário já cadastrado!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            } else {
                                MessageBox.Show($"Selecione uma função!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        } else {
                            MessageBox.Show($"Preencha o telefone do funcionário!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    } else {
                        MessageBox.Show($"CPF Inválido!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                } else {
                    MessageBox.Show($"Preencha o CPF do funcionário!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } else {
                MessageBox.Show($"Preencha o nome do funcionário!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnCadastrarCliente_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(txtNomeCliente.Text)) {
                if (!string.IsNullOrWhiteSpace(txtCpfCliente.Text)) {
                    txtCpfCliente.Text = txtCpfCliente.Text.Replace(".", "").Replace("-", "");
                    if (ValidarCpf.Validar(txtCpfCliente.Text)) {
                        if (!string.IsNullOrWhiteSpace(txtTelefoneCliente.Text)) {
                            txtTelefoneCliente.Text = txtTelefoneCliente.Text.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "");
                            if (!string.IsNullOrWhiteSpace(txtAlturaCliente.Text)) {
                                if (!string.IsNullOrWhiteSpace(txtPesoCliente.Text)) {
                                    c = new Cliente {
                                        Nome = txtNomeCliente.Text,
                                        Cpf = txtCpfCliente.Text,
                                        Telefone = txtTelefoneCliente.Text,
                                        Altura = Convert.ToDouble(txtAlturaCliente.Text),
                                        Peso = Convert.ToDouble(txtPesoCliente.Text),
                                        Categoria = CalcularCategoria.Categoria(Convert.ToDouble(txtAlturaCliente.Text), Convert.ToDouble(txtPesoCliente.Text)),
                                    };
                                    if (ClienteDAO.Cadastrar(c)) {
                                        MessageBox.Show($"Cliente cadastrado com sucesso!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                                        LimparFormulario();
                                    } else {
                                        MessageBox.Show($"Cliente já cadastrado!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                                    }
                                } else {
                                    MessageBox.Show($"Preencha a peso!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            } else {
                                MessageBox.Show($"Preencha a altura!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        } else {
                            MessageBox.Show($"Preencha o telefone do cliente!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    } else {
                        MessageBox.Show($"CPF Inválido!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                } else {
                    MessageBox.Show($"Preencha o CPF do cliente!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } else {
                MessageBox.Show($"Preencha o nome do cliente!", "Strong Muscle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}
