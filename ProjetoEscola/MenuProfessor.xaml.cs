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

namespace ProjetoEscola
{
    /// <summary>
    /// Interaction logic for MenuProfessor.xaml
    /// </summary>
    public partial class MenuProfessor : Window
    {
        string idFuncionario;
        string nome;
        
        public MenuProfessor(string idFuncionario, string nome)
        {
            this.idFuncionario = idFuncionario;
            this.nome = nome;
            InitializeComponent();
        }
    }
}
