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

    public partial class Funcionario : Window
    {
        string idFuncionario = "";
        string nome = "";
        string cpf = "";
        string rg = "";
        string telefone = "";
        string celular = "";
        string senha = "";
        string usuario = "";
        string dataNascimento = "";
        string estadoCivil = "";
        string email = "";
        string cargo = "";
        string sexoF = "";
        string cidade = "";
        string rua = "";
        string uf = "";
        string bairro = "";
        string complemento = "";
        string numero = "";
        string cep = "";
        string botao = "";
        string nomePai = "";
        string nomeMae = "";

        public Funcionario()
        {
            InitializeComponent();
        }

        private void consultar_Click(object sender, RoutedEventArgs e)
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

                string cpfConsultar = cpfConsultaT.Text;
                string consultar = "SELECT * FROM Funcionario WHERE cpf = '"+cpfConsultar+"'";
                
                SqlCommand codigo = new SqlCommand(consultar, conexao);
                SqlDataReader resultado = codigo.ExecuteReader();
                resultado.Read();

                if (resultado.HasRows == true)
                {
                    botao = "consultar";
                    nomeT.Text = resultado["nome"]+"";
                    cpfT.Text = resultado["cpf"] + "";
                    emailT.Text = resultado["email"] + "";
                    rgT.Text = resultado["rg"] + "";
                    telefoneT.Text = resultado["telefone"] + "";
                    celularT.Text = resultado["celular"] + "";
                    usuarioT.Text = resultado["usuario"] + "";
                    senhaT.Text = resultado["senha"] + "";
                    dataNascimentoT.Text = resultado["dataNascimento"] + "";
                    estadoCivilT.Text = resultado["estadoCivil"] + "";
                    ruaT.Text = resultado["rua"] + "";
                    bairroT.Text = resultado["bairro"] + "";
                    cepT.Text = resultado["cep"] + "";
                    complementoT.Text = resultado["complemento"] + "";
                    numeroT.Text = resultado["numero"] + "";
                    cidadeT.Text = resultado["cidade"] + "";
                    nomePaiT.Text = resultado["nomePai"] + "";
                    nomeMaeT.Text = resultado["nomeMae"] + "";
                    string cargo2 =resultado["cargo"] + "";
                    if (cargo2 == "Coordenador")
                    {
                        cargoT.Text = "Coordenador";
                    }
                    else 
                    {
                        cargoT.Text = "Professor";
                    }
                    string uf2 = resultado["uf"] + "";
                    ufT.Text = uf2 + "";
                    string sexo2 = resultado["sexo"] + "";
                    if (sexo2 == "M")
                    {
                        sexoMT.IsChecked = true;
                    }
                    else
                    {
                        sexoFT.IsChecked = true;
                    }
                    idFuncionario = resultado["idFuncionario"] + "";
                }
                else
                {
                   
                        MessageBox.Show("CPF Inválido" + idFuncionario);
                   
                }
                conexao.Close();
            }catch(SqlException ex)
            {

                MessageBox.Show("Erro no Banco: "+ex.Message);
            }
        }

        private void editar_Click(object sender, RoutedEventArgs e)
        {
            

            if (idFuncionario != "" && botao == "consultar")
            {
                botao = "editar";
                nomeT.IsEnabled = true;
                cpfT.IsEnabled = true;
                emailT.IsEnabled = true;
                rgT.IsEnabled = true;
                telefoneT.IsEnabled = true;
                celularT.IsEnabled = true;
                usuarioT.IsEnabled = true;
                senhaT.IsEnabled = true;
                dataNascimentoT.IsEnabled = true;
                estadoCivilT.IsEnabled = true;
                ruaT.IsEnabled = true;
                bairroT.IsEnabled = true;
                cepT.IsEnabled = true;
                complementoT.IsEnabled = true;
                numeroT.IsEnabled = true;
                cidadeT.IsEnabled = true;
                ufT.IsEnabled = true;
                cargoT.IsEnabled = true;
                nomeMaeT.IsEnabled = true;
                nomePaiT.IsEnabled = true;
                sexoFT.IsEnabled = true;
                sexoMT.IsEnabled = true;
                 
            }
            else
            {
                MessageBox.Show("Para editar as informações do funcionário é necessário consultar ");
            }



        }

        private void novo_Click(object sender, RoutedEventArgs e)
        {
            botao = "novo";
            nomeT.Text =  "";
            cpfT.Text = "";
            emailT.Text = "";
            rgT.Text =  "";
            telefoneT.Text= "";
            celularT.Text =  "";
            usuarioT.Text =  "";
            senhaT.Text =  "";
            dataNascimentoT.Text =  "";
            estadoCivilT.Text = "";
            ruaT.Text =  "";
            bairroT.Text =  "";
            cepT.Text =  "";
            complementoT.Text =  "";
            numeroT.Text =  "";
            cidadeT.Text =  "";
            nomeMaeT.Text = "";
            nomePaiT.Text = ""; 


            idFuncionario = "";
            nome = "";
            cpf = "";
            rg = "";
            telefone = "";
            celular = "";
            senha = "";
            usuario = "";
            dataNascimento = "";
            estadoCivil = "";
            email = "";
            cargo = "";
            sexoF = "";
            cidade = "";
            rua = "";
            uf = "";
            bairro = "";
            complemento = "";
            numero = "";
            cep = "";
            nomeMae = "";
            nomePai = "";

            nomeT.IsEnabled = true;
            cpfT.IsEnabled = true;
            emailT.IsEnabled = true;
            rgT.IsEnabled = true;
            telefoneT.IsEnabled = true;
            celularT.IsEnabled = true;
            usuarioT.IsEnabled = true;
            senhaT.IsEnabled = true;
            dataNascimentoT.IsEnabled = true;
            estadoCivilT.IsEnabled = true;
            ruaT.IsEnabled = true;
            bairroT.IsEnabled = true;
            cepT.IsEnabled = true;
            complementoT.IsEnabled = true;
            numeroT.IsEnabled = true;
            cidadeT.IsEnabled = true;
            ufT.IsEnabled = true;
            cargoT.IsEnabled = true;
            nomeMaeT.IsEnabled = true;
            nomePaiT.IsEnabled = true; 

            sexoMT.IsEnabled = true;
            sexoFT.IsEnabled = true;
           




        }

        private void salvar_Click(object sender, RoutedEventArgs e)
        {
            nome = nomeT.Text;
            cpf = cpfT.Text;
            rg = rgT.Text;
            telefone = telefoneT.Text;
            celular = celularT.Text;
            senha = senhaT.Text;
            usuario = usuarioT.Text;
            dataNascimento = dataNascimentoT.Text;
            estadoCivil = estadoCivilT.Text;
            email = emailT.Text;
            cargo = cargoT.Text;
            cidade = cidadeT.Text;
            rua = ruaT.Text;
            uf = ufT.Text;
            bairro = bairroT.Text;
            complemento = complementoT.Text;
            numero = numeroT.Text;
            cep = cepT.Text;
            nomePai = nomePaiT.Text;
            nomeMae = nomeMaeT.Text; 

            if (sexoMT.IsChecked == true)
            {
                sexoF = "M";
            }
            else
            {
                sexoF = "F";
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
                    sql = "insert into Funcionario(nome,cpf,rg,telefone,celular,senha,usuario,dataNascimento,estadoCivil,email,cargo,sexo,cidade,rua,uf,bairro,complemento,numero,cep,nomePai,nomeMae) VALUES ('" + nome + "', '" + cpf + "','" + rg + "','" + telefone + "', '" + celular + "','" + senha + "', '" + usuario + "', '" + dataNascimento + "', '" + estadoCivil + "', '" + email + "', '" + cargo + "','" + sexoF + "', '" + cidade + "', '" + rua + "','" + uf + "', '" + bairro + "',  '" + complemento + "', '" + numero + "','" + cep + "', '" + nomePai + "','" + nomeMae + "')";
                                                                                                                                                                                                              //(nome,cpf,rg,telefone,celular,senha,usuario,dataNascimento,estadoCivil,email,cargo,sexo,cidade,rua,uf,bairro,complemento,numero,cep,nomePai,nomeMae)
                    mensagem = "Cadastro feito com sucesso";
                }
                else
                {

                    sql = "UPDATE Funcionario SET nome='" + nome + "', cpf = '" + cpf + "', rg = '" + rg + "', telefone = '" + telefone + "', celular='" + celular + "', senha='" + senha + "', usuario = '" + usuario + "', dataNascimento='" + dataNascimento + "', estadoCivil = '" + estadoCivil + "', email ='" + email + "', cargo = '" + cargo + "', sexo = '" + sexoF + "', cidade='" + cidade + "', rua='" + rua + "',uf='" + uf + "', bairro='" + bairro + "',  complemento= '" + complemento + "', numero='" + numero + "',cep='" + cep + "',nomeMae = '" + nomeMae + "',nomePai ='" + nomePai + "' WHERE idFuncionario = " + idFuncionario + "";
                    mensagem = "Alteração feita com sucesso";
                }


                SqlCommand codigo = new SqlCommand(sql, conexao);
                codigo.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Informações alteradas com sucesso!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco! " + ex.Message);
            }

        }

        private void excluir_Click(object sender, RoutedEventArgs e)
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

                string excluir = "DELETE FROM Funcionario WHERE idFuncionario = " + idFuncionario;
                SqlCommand codigo = new SqlCommand(excluir, conexao);
                codigo.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Funcionário Excluido com sucesso !");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco !" + ex.Message);
            }

        }

        private void cancela_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
