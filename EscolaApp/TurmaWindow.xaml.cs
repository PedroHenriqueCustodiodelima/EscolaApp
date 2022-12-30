using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EscolaApp
{
    /// <summary>
    /// Lógica interna para TurmaWindow.xaml
    /// </summary>
    public partial class TurmaWindow : Window
    {
        public TurmaWindow()
        {
            InitializeComponent();
        }

        private void InserirClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string curso = txtCurso.Text;
            string desc = txtTurma.Text;
            int ano = int.Parse(txtAno.Text);
            Turma t = new Turma()
            {
                Id = id, Curso = curso, Descricao = desc, AnoLetivo = ano
            };
            NTurma.Inserir(t);
            ListarClick(sender, e);
        }
        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listTurmas.ItemsSource = null;
            listTurmas.ItemsSource = NTurma.Listar();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string curso = txtCurso.Text;
            string desc = txtTurma.Text;
            int ano = int.Parse(txtAno.Text);
            Turma t = new Turma()
            {
                Id = id, Curso = curso, Descricao = desc, AnoLetivo = ano
            };
            NTurma.Atualizar(t);
            ListarClick(sender, e);
        }

        private void ExcluirClick(object sender, RoutedEventArgs e)
        {
            if (listTurmas.SelectedItem != null)
            {

                NTurma.Excluir((Turma)listTurmas.SelectedItem);
                ListarClick(sender, e);
            }
            else
                MessageBox.Show("Selecione a turma a ser excluida");
        }

        private void listTurmas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listTurmas.SelectedItem != null)
            {
                Turma obj = (Turma)listTurmas.SelectedItem;
                txtId.Text = obj.Id.ToString();
                txtCurso.Text = obj.Curso;
                txtTurma.Text = obj.Descricao;
                txtAno.Text = obj.AnoLetivo.ToString();
            }
        }
    }
}
