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
    /// Interaction logic for Curso.xaml
    /// </summary>
    public partial class Curso : Window
    {

        string idFuncionario = "";
        string nomeCurso = "";
        string nomeDisciplina = "";
        string cargaHorariaCurso = "";
        string idCurso = "";
        string idDisciplina = "";
        string descricaoCurso = "";
        string cargaHorariaDisciplina = "";
        string botao = "";


        public Curso(string idFuncionario)
        {

            this.idFuncionario = idFuncionario;
 
            InitializeComponent();

            
            try
            {

                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "ESCOLA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;
                conexao.Open();

                string consultarCursos = "SELECT * FROM Curso";

               SqlCommand codigo = new SqlCommand (consultarCursos, conexao);
                SqlDataReader resultado = codigo.ExecuteReader();

               while (resultado.Read())
                {
                listaCursoT.Items.Add(resultado["nome"] + "");
                }
                 conexao.Close();

               }
               catch(SqlException ex)
               {

              MessageBox.Show("Erro no banco: " + ex.Message);

              }
            
            }

        private void consultarCurso_Click(object sender, RoutedEventArgs e)
        {
            
            //apagar a lista disciplina
            listaDisciplinaT.Items.Clear();

           //cria uma variavel para receber um novo nome de curso, para uma nova consulta de curso. 
            string nomeCursoConsultar = listaCursoT.Text;


            
            
                try
                {
                    SqlConnection conexao = new SqlConnection();
                    SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                    banco.DataSource = ".\\SQLEXPRESS";
                    banco.InitialCatalog = "ESCOLA";
                    banco.IntegratedSecurity = true;
                    conexao.ConnectionString = banco.ConnectionString;
                    conexao.Open();

                    string consultarCursos = "SELECT * FROM Curso WHERE nome = '" + nomeCursoConsultar + "'";
                    SqlCommand codigo = new SqlCommand(consultarCursos, conexao);
                    SqlDataReader resultado = codigo.ExecuteReader();
                    resultado.Read();


                    botao = "consultar";
                    nomeCurso = resultado["nome"] + "";
                    descricaoCurso = resultado["descricao"] + "";
                    idCurso = resultado["idCurso"] + "";
                    cargaHorariaCurso = resultado["cargaHoraria"] + "";

                    nomeCursoT.Text = nomeCurso;
                    descricaoCursoT.Text = descricaoCurso;
                    cargaHorariaCursoT.Text = cargaHorariaCurso;

                    conexao.Close();


                }

                catch (SqlException ex)
                {

                    MessageBox.Show("Erro no Banco: " + ex.Message);

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

                string consultarCursos = "SELECT * FROM Disciplina where idCurso = " + idCurso;

                SqlCommand codigo = new SqlCommand(consultarCursos, conexao);
                SqlDataReader resultado = codigo.ExecuteReader();

                while (resultado.Read())
                {
                    listaDisciplinaT.Items.Add(resultado["nome"] + "");
                  

                }

                conexao.Close();
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Erro no Banco: " + ex.Message); 
            
            }
        }

        private void novoCurso_Click(object sender, RoutedEventArgs e)
        {

           botao = "novo";
           nomeCursoT.Text = "";
           cargaHorariaCursoT.Text = "";
           descricaoCursoT.Text = "";

           idCurso = "";
           nomeCurso = "";
           cargaHorariaCurso = "";
           descricaoCurso = "";

           nomeCursoT.IsEnabled = true;
           cargaHorariaCursoT.IsEnabled = true;
           descricaoCursoT.IsEnabled = true;  
              

        }

        private void editarCurso_Click(object sender, RoutedEventArgs e)
        {
            if (idCurso != "" & botao == "consultar")
            {
                idCurso = "editar";
                nomeCursoT.IsEnabled = true;
                cargaHorariaCursoT.IsEnabled = true;
                descricaoCursoT.IsEnabled = true;
             
            }
            else
            {
                MessageBox.Show("Para editar as informações do Curso é necessário consultar. ");

            }
        }

        private void excluirCurso_Click(object sender, RoutedEventArgs e)
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

                string excluir = "DELETE FROM Curso WHERE idCurso = " +
                    idCurso;
                SqlCommand codigo = new SqlCommand(excluir, conexao);
                codigo.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("O Curso foi Excluido com sucesso !");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco !" + ex.Message);
            }

        }

        private void salvarCurso_Click(object sender, RoutedEventArgs e)
        {
            
       
         nomeCurso = nomeCursoT.Text;  
         cargaHorariaCurso = cargaHorariaCursoT.Text  ;
         descricaoCurso = descricaoCursoT.Text ;

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
                    sql = "INSERT INTO Curso (idFuncionario,nome,cargaHoraria,descricao) VALUES (" + idFuncionario + ",'" + nomeCurso + "','" + cargaHorariaCurso + "','" + descricaoCurso + "')";
                    mensagem = "Cadastro feito com sucesso";
                }
                else
                {

                    sql = "UPDATE Curso SET nome='" + nomeCurso + "', cargaHoraria = '" + cargaHorariaCurso  + "', descricaoCurso = '" + descricaoCurso  + "";
                    mensagem = "Alteração feita com sucesso";
                }


                SqlCommand codigo = new SqlCommand(sql, conexao);
                codigo.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Informações alteradas com sucesso!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco!  " + ex.Message);
            }

        }
//-------------------------------------------------------------------------------Disciplina--------------------------------------------------------------------------------
        private void novoDisciplina_Click(object sender, RoutedEventArgs e)
        {
            botao = "novo";
            nomeDisciplinaT.Text = "";
            cargaHorariaDisciplinaT.Text = "";
           

            idDisciplina = "";
            nomeDisciplina = "";
            cargaHorariaDisciplina = "";
           

            nomeDisciplinaT.IsEnabled = true;
            cargaHorariaDisciplinaT.IsEnabled = true;
        
              

        }

        private void editarDisciplina_Click(object sender, RoutedEventArgs e)
        {
            if (idDisciplina != "" & botao == "consultar")
            {
                idDisciplina = "editar";
                nomeDisciplinaT.IsEnabled = true;
                cargaHorariaDisciplinaT.IsEnabled = true;
              
            }
            else
            {
                MessageBox.Show("Para editar as informações da Disciplina é necessário consultar. ");

            }
        }

        private void excluirDisciplina_Click(object sender, RoutedEventArgs e)
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

                string excluir = "DELETE FROM Disciplina WHERE idDisciplina = " + idDisciplina;
                SqlCommand codigo = new SqlCommand(excluir, conexao);
                codigo.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("A Disciplina foi Excluida com sucesso !");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco !" + ex.Message);
            }

        }

        private void salvarDisciplina_Click(object sender, RoutedEventArgs e)
        {


            nomeDisciplina = nomeDisciplinaT.Text;
            cargaHorariaDisciplina = cargaHorariaDisciplinaT.Text;


            
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
                    sql = "INSERT INTO Disciplina (nome,cargaHoraria,idCurso) VALUES ('" + nomeDisciplina + "','" + cargaHorariaDisciplina + "','" + idCurso + "')";
                    mensagem = "Cadastro feito com sucesso";
                }
                else
                {

                    sql = "UPDATE Disciplina SET nome='" + nomeDisciplina + "', cargaHoraria = '" + cargaHorariaDisciplina +   "'";
                    mensagem = "Alteração feita com sucesso";
                }


                SqlCommand codigo = new SqlCommand(sql, conexao);
                codigo.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Informações alteradas com sucesso!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no banco!" + ex.Message);
            }



        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void consultarDisciplina_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conexao = new SqlConnection();
            SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
            banco.DataSource = ".\\SQLEXPRESS";
            banco.InitialCatalog = "ESCOLA";
            banco.IntegratedSecurity = true;
            conexao.ConnectionString = banco.ConnectionString;
            conexao.Open();

            string nomeConsultaDisciplina = listaDisciplinaT.SelectedValue.ToString();
            string consultar = "SELECT * FROM Disciplina WHERE idCurso = " + idCurso + "and nome =  '" + nomeConsultaDisciplina + "'";


            SqlCommand codigo = new SqlCommand(consultar, conexao);
            SqlDataReader resultado = codigo.ExecuteReader();

            resultado.Read();


           
            idDisciplina = resultado["idDisciplina"] + "";
            nomeDisciplinaT.Text = resultado["nome"] + "";
            cargaHorariaDisciplinaT.Text = resultado["cargaHoraria"] + "";

            conexao.Close();

        }

       



       
    

        
        }
      }
     
  

