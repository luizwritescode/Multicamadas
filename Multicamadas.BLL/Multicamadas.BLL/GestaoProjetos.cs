using System.Linq;
using System.Collections.Generic;
using Multicamadas.MODEL;
using Multicamadas.DAL.DBContext;

namespace Multicamadas.BLL
{
    public static class GestaoProjetos
    {
        public static void Add(Projetos _projeto)
        {
            using (var db = new MDFContext())
            {
                db.Add(_projeto);
                db.SaveChanges();
            }
        }

        public static Projetos GetById(int Id)
        {
            using (var db = new MDFContext())
            {
                return db.Projetos.Find(Id);
            }
        }

        public static List<Projetos> GetAll()
        {
            using (var db = new MDFContext())
            {
                return db.Projetos.ToList();
            }
        }

        public static void Update(Projetos _projeto)
        {
            using (var db = new MDFContext())
            {
                var projeto = db.Projetos.Find(_projeto.Id);
                projeto.NomeProjeto = _projeto.NomeProjeto;
                projeto.NomeGerente = _projeto.NomeGerente;
                projeto.DataInicio = _projeto.DataInicio;
                projeto.DataFim = _projeto.DataFim;
                projeto.Resumo = _projeto.Resumo;
                projeto.Status = _projeto.Status;
                db.SaveChanges();
            }
        }

        public static void Delete(Projetos _projeto)
        {
            using (var db = new MDFContext())
            {
                var projeto = db.Projetos.Find(_projeto.Id);
                db.Remove(projeto);
                db.SaveChanges();
            }
        }
    }
}
