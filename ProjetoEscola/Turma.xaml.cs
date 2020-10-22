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
    /// Interaction logic for Turma.xaml
    /// </summary>
    public partial class Turma : Window
    {

        String curso = "";
        String codigoTurma = "";
        String vagas = "";
        String dataInicio = "";
        String dataFim = "";
        String turno = "";
        String disciplina = "";
        String nomeTurma = "";
        String botao = "";
        String identificadorCurso = "";
        String idCurso = "";
        String identificadorDisciplina = "";

        public Turma()
        {
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

                string consultarTurma = "SELECT * FROM Turma";

                SqlCommand codigo = new SqlCommand(consultarTurma, conexao);
                SqlDataReader resultado = codigo.ExecuteReader();

                while (resultado.Read())
                {
                    listaTurmaT.Items.Add(resultado["nomeTurma"] + "");
                }
                conexao.Close();




            }
            catch (SqlException ex)
            {

                MessageBox.Show("Erro no banco: " + ex.Message);

            }
        }




        private void consultarTurma_Click(object sender, RoutedEventArgs e)
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

                 
                String listar = listaTurmaT.Text;
                String consultarTurma = "SELECT * FROM Turma WHERE nome = '" + listar + "'";
              
                SqlCommand codigo = new SqlCommand(consultarTurma, conexao);
                SqlDataReader resultado = codigo.ExecuteReader();
                resultado.Read();

                dataInicio = resultado["dataInicio"] + "";
                dataFim = resultado["dataTermino"]+"";
                vagas = resultado["vagas"] + "";
                String codigoTurma = resultado["codigo"] + "";
                String turno2 = resultado["turno"] + "";
                turnoT.Text = turno2 + "";
                identificadorCurso = resultado["identificadorCurso"] + "";


                dtFimT.Text = dataFim;
                dtInicioT.Text = dataInicio;
                vagasT.Text = vagas;
                turnoT.SelectedIndex = turnoT.Items.Add(turno);
                nomeTurmaT.Text = codigoTurma+"";
                conexao.Close();
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Erro no Banco: " + ex.Message);
            }

            //consultar Curso
            try
            {
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "ESCOLA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;
                conexao.Open();

                String listar =  listaTurmaT.Text;
                String consultarCurso = "SELECT * FROM Curso WHERE nome = '" + listar + "'";
                
                SqlCommand codigo = new SqlCommand(consultarCurso, conexao);
                SqlDataReader resultado = codigo.ExecuteReader();
                resultado.Read();

                String nomecurso = resultado["nome"]+"";
                idCurso = resultado["idCurso"]+"";
                listaCursoT.SelectedIndex = listaCursoT.Items.Add(resultado["nome"]);
                while(resultado.Read())
                {
                  listaCursoT.Items.Add(resultado["nome"]);
                }


                conexao.Close();

            }

            catch (SqlException ex)
            {

                MessageBox.Show("Erro no Banco: " + ex.Message);
            }

            //consultar Disciplina

            try 
            {
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "ESCOLA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;
                conexao.Open();


                String listar = listaTurmaT.Text;
                String consultarDisciplina = "SELECT * FROM Disciplina WHERE idCurso =" + idCurso;

                SqlCommand codigo = new SqlCommand(consultarDisciplina, conexao);
                SqlDataReader resultado = codigo.ExecuteReader();
                resultado.Read();
                identificadorDisciplina = resultado["idDisciplina"] + "";
                listaDisciplinaT.Items.Add(resultado["nome"]);  
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Erro no Banco: " + ex.Message);
            }
        }
//-----------------------------------------------------------------------------------------------------------
        private void excluirProfessorDisciplina_Click(object sender, RoutedEventArgs e)
        {
            string disciplina = listaDisciplinaT.SelectedValue.ToString();

            try 
            {
                SqlConnection conexao = new SqlConnection();
                SqlConnectionStringBuilder banco = new SqlConnectionStringBuilder();
                banco.DataSource = ".\\SQLEXPRESS";
                banco.InitialCatalog = "ESCOLA";
                banco.IntegratedSecurity = true;
                conexao.ConnectionString = banco.ConnectionString;
                conexao.Open();

                String listar = listaTurmaT.Text;
                String consultarDisciplina = "select  * from Disciplina where nome = '" + disciplina + "'";

                SqlCommand codigo = new SqlCommand(consultarDisciplina, conexao);
                SqlDataReader resultado = codigo.ExecuteReader();
                resultado.Read();
                String nomeDisciplina = resultado["nome"] + "";


                disciplinasProfessorT.SelectedIndex = disciplinasProfessorT.Items.Add(resultado["nome"]);
                
                while(resultado.Read())
                {
                    disciplinasProfessorT.Items.Add(resultado["nome"]);
                
                }
            
            
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Erro no Banco: " + ex.Message);
            }
            
        }

        private void novo_Click(object sender, RoutedEventArgs e)
        {
            botao = "novo";
            nomeTurmaT.Text = "";
            vagasT.Text = "";
            dtInicioT.Text = "";
            dtFimT.Text = "";
        
            nomeTurma = "";
            vagas = "";
            dataFim = "";
            dataInicio = "";
            
            
            
            listaCursoT.IsEnabled = true;
            nomeTurmaT.IsEnabled = true;
            vagasT.IsEnabled = true;
            dtFimT.IsEnabled = true;
            dtInicioT.IsEnabled = true;
            turnoT.IsEnabled = true;
        }

        private void editar_Click(object sender, RoutedEventArgs e)
        {
            if (idTurma != "" && botao == "consultar")
            {
                botao = "editar";
                listaCursoT.IsEnabled = true;
                nomeTurmaT.IsEnabled = true;
                vagasT.IsEnabled = true;
                dtFimT.IsEnabled = true;
                dtInicioT.IsEnabled = true;
                turnoT.IsEnabled = true;


            }
            else
            {
                MessageBox.Show("Para editar as informações do funcionário é necessário consultar ");
            }
        }
    }
}
    
    

