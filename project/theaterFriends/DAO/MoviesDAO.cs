using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using theaterFriends.Models;

namespace theaterFriends.DAO
{
    public class MoviesDAO : PadraoDAO<MoviesViewModel>
    {
        protected override SqlParameter[] CriaParametros(MoviesViewModel model)
        {
            object imgByte = model.ImagemEmByte;
            if (imgByte == null)
                imgByte = DBNull.Value;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id", model.Id));
            parameters.Add(new SqlParameter("name", model.Name));
            parameters.Add(new SqlParameter("description", model.Description));
            parameters.Add(new SqlParameter("type", model.Type));
            parameters.Add(new SqlParameter("language", model.Language));
            parameters.Add(new SqlParameter("subtitle", model.Subtitle));
            parameters.Add(new SqlParameter("cover", imgByte));
            parameters.Add(new SqlParameter("min_age", model.Min_age));
            parameters.Add(new SqlParameter("length", model.Length));

            return parameters.ToArray();
        }

        //public override List<MoviesViewModel> Listagem()
        //{
        //    var p = new SqlParameter[]
        //       {
        //        new SqlParameter("tabela", Tabela),
        //        new SqlParameter("Ordem", "id")
        //       };
        //    var tabela = HelperDAO.ExecutaProcSelect("sp_ListagemExibicao", p);
        //    List<MoviesViewModel> lista = new List<MoviesViewModel>();
        //    foreach (DataRow registro in tabela.Rows)
        //    {
        //        lista.Add(MontaModel(registro));
        //    }
        //    return lista;

        //}

      
        protected override MoviesViewModel MontaModel(DataRow registro)
        {
            MoviesViewModel movie = new MoviesViewModel
            {
                Id = Convert.ToInt32(registro["id"]),
                Name = registro["name"].ToString(),
                Description = registro["description"].ToString(),
                Type = registro["type"].ToString(),
                Language = registro["language"].ToString(),
                Min_age = Convert.ToInt32(registro["min_age"]),
                Length = Convert.ToInt32(registro["length"]),
                Subtitle = Convert.ToBoolean(registro["subtitle"])
            };

            if (registro["cover"] != DBNull.Value)
                movie.ImagemEmByte = registro["cover"] as byte[];

            return movie;
        }

        protected override void SetTabela(string table)
        {
            Tabela = (table != null && table != "") ? table : "Movies";
        }
    }
}
