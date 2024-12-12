using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using theaterFriends.Models;

namespace theaterFriends.DAO
{
    public abstract class PadraoDAO<T> where T : PadraoViewModel
    {
        protected abstract void SetTabela(string table = "");
        protected PadraoDAO()
        {
            SetTabela();
        }
        protected string Tabela { get; set; }
        protected string NomeProcedureListagem { get; set; } = "spListagem";
        protected string NomeProcedureListagemSearch { get; set; } = "spListagemSearch";
        protected abstract SqlParameter[] CriaParametros(T model);
        protected abstract T MontaModel(DataRow registro);


        public virtual int Insert(T model) //duvida aqui,
        {
            int ultimoId = HelperDAO.ExecutaProc("spInsert_" + Tabela, CriaParametros(model), true); //true or false, não sei
            return ultimoId;
        }
        public virtual void Update(T model)
        {
            HelperDAO.ExecutaProc("spUpdate_" + Tabela, CriaParametros(model));
        }
        public virtual void Delete(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("tabela", Tabela)
            };
            HelperDAO.ExecutaProc("spDelete", p);
        }
        public virtual T Login(string email, string pass, string table)
        {
            SetTabela(table);
            var p = new SqlParameter[]
            {
                new SqlParameter("email", email != null ? email : ""),
                new SqlParameter("pass", pass != null ? pass : ""),
                new SqlParameter("tabela", Tabela)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spLogin", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }
        public virtual T Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id),
                new SqlParameter("tabela", Tabela)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsulta", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }


        public virtual List<T> ConsultaHorario(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id),
                //new SqlParameter("tabela", Tabela)
            };
            var tabela = HelperDAO.ExecutaProcSelect("sp_ListagemExibicao", p);
            List<T> lista = new List<T>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }

        public virtual List<T> Listagem(string val = "", string option = "")
        {
            var p = new SqlParameter[] { };
            if (val.Length > 0 && option.Length > 0)
            {
                p = new SqlParameter[]
                {
                    new SqlParameter("ordem", "id"),
                    new SqlParameter("tabela", Tabela),
                    new SqlParameter("value", val),
                    new SqlParameter("option", option),
                };
            }else
            {
                p = new SqlParameter[]
                {
                    new SqlParameter("ordem", "id"),
                    new SqlParameter("tabela", Tabela)
                };
            }

            var tabela = HelperDAO.ExecutaProcSelect(
                val.Length > 0 && option.Length > 0 ? NomeProcedureListagemSearch 
                    : NomeProcedureListagem, p);
            List<T> lista = new List<T>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }
            return lista;
        }
    }
}
