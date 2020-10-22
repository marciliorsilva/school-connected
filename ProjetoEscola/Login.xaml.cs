using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace ProjetoEscola
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void EntrarT_Click(object sender, RoutedEventArgs e)
        {
            string usuario = usuarioT.Text;
            string senha = senhaT.Text;
            string erro = "";



            try
            {
                SqlConnection conexao = new SqlConnection(); /*permite se conectar a um servidor*/
                erro = "0";
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder(); /*informa qual banco será ultilizado no sistema*/
                erro = "1";
                banco.DataSource = ".\\SQLEXPRESS"; /* nome do servidor*/
                erro = "2";
                banco.InitialCatalog = "ESCOLA"; /*nome do banco de dados*/
                erro = "3";
                banco.IntegratedSecurity = true; /*normas de segurança do sql1*/
                erro = "4";
                conexao.ConnectionString = banco.ConnectionString; /*prepara o banco para ser utilizado pelo c#*/
                erro = "5";
                conexao.Open(); /*abrir o banco*/
                erro = "6";
                /*codigo obrigatorio fim*/
                string consulta = "Select cargo , idFuncionario , nome from Funcionario where usuario = '" + usuario + "' and senha = '" + senha + "' ";
                erro = "7";
                SqlCommand execute = new SqlCommand(consulta, conexao);
                erro = "8";
                SqlDataReader resultado = execute.ExecuteReader();
                erro = "9";
                bool existe = resultado.HasRows;
                erro = "10";

                if (existe == false)
                {
                    erro = "11";
                    MessageBox.Show("Usuario ou senha incorretos !");
                }

                else
                {
                    resultado.Read();
                    erro = "12";
                    string cargo = resultado["cargo"] + "";
                    erro = "13";
                    string idFuncionario = resultado["idFuncionario"] + "";
                    erro = "14";
                    string nome = resultado["nome"] + "";
                    erro = "15";
                   
                    if (cargo == "Adm")
                    {
                        erro = "16";
                        MenuCoordenador MenuCoordenador = new MenuCoordenador(idFuncionario,nome);
                        Hide();
                        MenuCoordenador.ShowDialog();
                        
                    }


                    else if (cargo == "Professor")
                    {
                        erro = "17";
                        MenuProfessor MenuProfessor = new MenuProfessor(idFuncionario, nome);
                        Hide();
                        MenuProfessor.ShowDialog();
                        
                    }

                }

                erro = "18";
                conexao.Close();
            }
            catch (SqlException ex)
            {
                erro = "19";
                MessageBox.Show("Erro no Banco." + ex.Message);
            }


        }

        private void fecharT_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
        }


       
   }

