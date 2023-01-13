using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EscolaApp
{
    static class NAluno
    {
        private static List<Aluno> alunos = new List<Aluno>();
        public static void Inserir(Aluno t)
        { // C - Create
            Abrir();
            alunos.Add(t);
            Salvar();
        }
        public static List<Aluno> Listar()
        { // R - Read
            Abrir();
            return alunos;
        }
        public static Aluno Listar(int id)
        {
            // Encontra, se existir, uma turma com o id
            foreach (Aluno obj in alunos)
                if (obj.Id == id) return obj;
            return null;
        }
        public static void Atualizar(Aluno t)
        { // U - Update
            Abrir();
            Aluno obj = Listar(t.Id);
            obj.Nome = t.Nome;
            obj.Matricula = t.Matricula;
            obj.Email = t.Email;
            obj.IdTurma = t.IdTurma;
            Salvar();
        }
        public static void Excluir(Aluno t)
        { // D - Delete
            Abrir();
            alunos.Remove(Listar(t.Id));
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Aluno>));
                f = new StreamReader("./aluno.xml");
                alunos = (List<Aluno>)xml.Deserialize(f);
            }
            catch
            {
                alunos = new List<Aluno>();
            }
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Aluno>));
            StreamWriter f = new StreamWriter("./aluno.xml", false);
            xml.Serialize(f, alunos);
            f.Close();
        }
        public static void Matricular(Aluno a, Turma t)
        {
            a.IdTurma = t.Id;
            Atualizar(a);
        }
        public static List<Aluno> Listar(Turma t)
        {
            Abrir(); // Abre a lista com todos os alunos
            List<Aluno> diario = new List<Aluno>(); // Lista de alunos da turma t
            foreach (Aluno obj in alunos)
                if (obj.IdTurma == t.Id) diario.Add(obj);
            return diario;
        }
    }
}
