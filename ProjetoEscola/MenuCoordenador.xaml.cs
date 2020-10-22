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
//using System.Data.SqlClient;
namespace ProjetoEscola
{
    /// <summary>
    /// Interaction logic for MenuCoordenador.xaml
    /// </summary>
    public partial class MenuCoordenador : Window
    {
        string idFuncionario;
        string nome;

        public MenuCoordenador(string idFuncionario, string nome)
        {

            this.idFuncionario = idFuncionario;
            this.nome = nome;
            InitializeComponent();
        }

        private void Funcionario_Click(object sender, RoutedEventArgs e)
        {
            Funcionario Funcionario = new Funcionario();
            Funcionario.ShowDialog();
        }

       
        private void Turma_Click(object sender, RoutedEventArgs e)
        {
            Turma Turma = new Turma();
            Turma.ShowDialog();
        }

        private void Aluno_Click(object sender, RoutedEventArgs e)
        {
            Aluno Aluno = new Aluno();
            Aluno.ShowDialog();
        }

        private void Curso_Click(object sender, RoutedEventArgs e)
        {
            Curso Curso = new Curso(idFuncionario);
            Curso.ShowDialog();
        }

       

        
      
    }
}
