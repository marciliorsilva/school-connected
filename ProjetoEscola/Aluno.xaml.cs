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
    /// Interaction logic for Aluno.xaml
    /// </summary>
    public partial class Aluno : Window
    {
        string idAluno= "";
        string nome = "";
        string cpf = "";
        string rg = "";
        string telefone = "";
        string celular = "";
        string dataNascimento = "";
        string estadoCivil = "";
        string email = "";
        string sexoA = "";
        string cidade = "";
        string rua = "";
        string uf = "";
        string bairro = "";
        string complemento = "";
        string numero = "";
        string cep = "";
        string nomePai = "";
        string nomeMae = "";
        string botao = "";
        public Aluno()
        {
            InitializeComponent();
        }

        private void consultarAluno_Click(object sender, RoutedEventArgs e)
        {
              try
            {
                SqlConnection conexao = new SqlConnection(); 
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS"; 
                banco.InitialCatalog = "ESCOLA"; 
                banco.IntegratedSecurity = true;  
                conexao.ConnectionString = banco.ConnectionString; 
                conexao.Open();

                string cpfConsultar = cpfConsultaAlunoT.Text;
                string consultar = "SELECT * FROM Aluno WHERE cpf = '"+cpfConsultar+"'";
                
                SqlCommand codigo = new SqlCommand(consultar, conexao);
                SqlDataReader resultado = codigo.ExecuteReader();
                resultado.Read();
                  
                if (resultado.HasRows == true)
                {
                    botao = "consultar";
                    nomeAlunoT.Text = resultado["nome"]+"";
                    cpfAlunoT.Text = resultado["cpf"] + "";
                    emailAlunoT.Text = resultado["email"] + "";
                    rgAlunoT.Text = resultado["rg"] + "";
                    telefoneAlunoT.Text = resultado["telefone"] + "";
                    celularAlunoT.Text = resultado["celular"] + "";
                    dataNascimentoAlunoT.Text = resultado["dataNascimento"] + "";
                    estadoCivilAlunoT.Text = resultado["estadoCivil"] + "";
                    ruaAlunoT.Text = resultado["rua"] + "";
                    bairroAlunoT.Text = resultado["bairro"] + "";
                    cepAlunoT.Text = resultado["cep"] + "";
                    complementoAlunoT.Text = resultado["complemento"] + "";
                    numeroAlunoT.Text = resultado["numero"] + "";
                    cidadeAlunoT.Text = resultado["cidade"] + "";
                    nomeMaeAlunoT.Text = resultado ["nomeMae"] + "";
                    nomePaiAlunoT.Text = resultado["nomePai"] + ""; 
                    string sexo2 = resultado["sexo"] + "";
                      if (sexo2 == "M")
                    {
                        sexoMAlunoT.IsChecked = true;
                    }
                    else
                    {
                        sexoFAlunoT.IsChecked = true;
                    }

                    string uf2 = resultado["uf"] + "";
                    ufAlunoT.Text = uf2 + "";
                    
                    
                    idAluno = resultado["idAluno"] + "";
                }
                else
                {
                   
                        MessageBox.Show("CPF Inválido" + idAluno);
                   
                }
                conexao.Close();
            }catch(SqlException ex)
            {

                MessageBox.Show("Erro no Banco: "+ex.Message);
            }


        }

        private void editarAluno_Click(object sender, RoutedEventArgs e)
        {
              if (idAluno != "" && botao == "consultar")
            {
                botao = "editar";
                nomeAlunoT.IsEnabled = true;
                cpfAlunoT.IsEnabled = true;
                emailAlunoT.IsEnabled = true;
                rgAlunoT.IsEnabled = true;
                telefoneAlunoT.IsEnabled = true;
                celularAlunoT.IsEnabled = true;
                dataNascimentoAlunoT.IsEnabled = true;
                estadoCivilAlunoT.IsEnabled = true;
                ruaAlunoT.IsEnabled = true;
                bairroAlunoT.IsEnabled = true;
                cepAlunoT.IsEnabled = true;
                complementoAlunoT.IsEnabled = true;
                numeroAlunoT.IsEnabled = true;
                cidadeAlunoT.IsEnabled = true;
                ufAlunoT.IsEnabled = true;
                nomeMaeAlunoT.IsEnabled = true;
                nomePaiAlunoT. IsEnabled =true;
               
            }
            else
            {
                MessageBox.Show("Para editar as informações do funcionário é necessário consultar " );
            }



        }

        private void novoAluno_Click(object sender, RoutedEventArgs e)
        {
            botao = "novo";
            nomeAlunoT.Text = "";
            cpfAlunoT.Text = "";
            emailAlunoT.Text = "";
            rgAlunoT.Text = "";
            telefoneAlunoT.Text = "";
            celularAlunoT.Text = "";
            dataNascimentoAlunoT.Text = "";
            estadoCivilAlunoT.Text = "";
            ruaAlunoT.Text = "";
            bairroAlunoT.Text = "";
            cepAlunoT.Text = "";
            complementoAlunoT.Text = "";
            numeroAlunoT.Text = "";
            cidadeAlunoT.Text = "";
            nomeMaeAlunoT.Text = "";
            nomePaiAlunoT.Text = ""; 


            idAluno = "";
            nome = "";
            cpf = "";
            rg = "";
            telefone = "";
            celular = "";
            dataNascimento = "";
            estadoCivil = "";
            email = "";
            sexoA = "";
            cidade = "";
            rua = "";
            uf = "";
            bairro = "";
            complemento = "";
            numero = "";
            cep = "";
            nomeMae = "";
            nomePai = "";

            nomeAlunoT.IsEnabled = true;
            cpfAlunoT.IsEnabled = true;
            emailAlunoT.IsEnabled = true;
            rgAlunoT.IsEnabled = true;
            telefoneAlunoT.IsEnabled = true;
            celularAlunoT.IsEnabled = true;
            dataNascimentoAlunoT.IsEnabled = true;
            estadoCivilAlunoT.IsEnabled = true;
            ruaAlunoT.IsEnabled = true;
            bairroAlunoT.IsEnabled = true;
            cepAlunoT.IsEnabled = true;
            complementoAlunoT.IsEnabled = true;
            numeroAlunoT.IsEnabled = true;
            cidadeAlunoT.IsEnabled = true;
            ufAlunoT.IsEnabled = true;
            sexoMAlunoT.IsEnabled = true;
            sexoFAlunoT.IsEnabled = true;
            nomeMaeAlunoT.IsEnabled = true;
            nomePaiAlunoT.IsEnabled = true;
           

        }

        private void excluirAluno_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "ESCOLA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;
                conexao.Open();

                string excluir = "DELETE FROM Aluno WHERE idAluno = " +
                    idAluno;
                SqlCommand codigo = new SqlCommand(excluir, conexao);
                codigo.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Aluno Excluido com sucesso !");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco !" + ex.Message);
            }

        }

        private void salvarAluno_Click(object sender, RoutedEventArgs e)
        {
            nome = nomeAlunoT.Text;
            cpf = cpfAlunoT.Text;
            rg = rgAlunoT.Text;
            telefone = telefoneAlunoT.Text;
            celular = celularAlunoT.Text;
            dataNascimento = dataNascimentoAlunoT.Text;
            estadoCivil = estadoCivilAlunoT.Text;
            email = emailAlunoT.Text;
            cidade = cidadeAlunoT.Text;
            rua = ruaAlunoT.Text;
            uf = ufAlunoT.Text;
            bairro = bairroAlunoT.Text;
            complemento = complementoAlunoT.Text;
            numero = numeroAlunoT.Text;
            cep = cepAlunoT.Text;
            nomePai = nomePaiAlunoT.Text;
            nomeMae = nomeMaeAlunoT.Text;

            if (sexoMAlunoT.IsChecked == true)
            {
                sexoA = "M";
            }
            else
            {
                sexoA = "F";
            }

            try
            {
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "ESCOLA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;
                conexao.Open();

                string sql = "";
                string mensagem = "";
                if (botao == "novo")
                {
                    sql = "INSERT INTO Aluno (nome,cpf, rg, telefone,celular,dataNascimento,estadoCivil,email,sexo,cidade,rua,uf,bairro, complemento,numero,cep,nomePai,nomeMae) VALUES ('" + nome + "', '" + cpf + "','" + rg + "','" + telefone + "', '" + celular + "','" + dataNascimento + "', '" + estadoCivil + "', '" + email + "','" + sexoA + "','" + cidade + "', '" + rua + "','" + uf + "', '" + bairro + "',  '" + complemento + "', '" + numero + "','" + cep + "', '" + nomePai + "','" + nomeMae + "')";
                    //(nome,cpf,rg,telefone,celular,dataNascimento,estadoCivil,email,cidade,rua,uf,bairro,complemento,numero,cep,nomePai,nomeMae)
                    mensagem = "Cadastro feito com sucesso";
                }
                else
                {

                    sql = "UPDATE Aluno SET nome='" + nome + "', cpf = '" + cpf + "', rg = '" + rg + "', telefone = '" + telefone + "', celular='" + celular + "',dataNascimento='" + dataNascimento + "', estadoCivil = '" + estadoCivil + "', email ='" + email + "',sexo ='" + sexoA + "',cidade='" + cidade + "', rua='" + rua + "',uf='" + uf + "', bairro='" + bairro + "',  complemento= '" + complemento + "', numero='" + numero + "',cep='" + cep + "',nomeMae = '" + nomeMae + "',nomePai ='" + nomePai + "' WHERE idAluno = " + idAluno + "";
                    mensagem = "Alteração feita com sucesso";
                }


                SqlCommand codigo = new SqlCommand(sql, conexao);
                codigo.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Informações alteradas com sucesso!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco!");
            }

        }

        private void cancelarAluno_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        }






        }


       
    

