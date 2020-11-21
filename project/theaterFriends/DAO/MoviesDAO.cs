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
                imgByte = new byte[0];  //DBNull.Value;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id", model.Id));
            parameters.Add(new SqlParameter("name", model.Name));
            parameters.Add(new SqlParameter("description", model.Description));
            parameters.Add(new SqlParameter("type", model.Type));
            parameters.Add(new SqlParameter("language", model.Language));
            parameters.Add(new SqlParameter("subtitle", model.Subtitle));
            parameters.Add(new SqlParameter("image", imgByte));
            parameters.Add(new SqlParameter("min_age", model.Min_age));
            parameters.Add(new SqlParameter("length", model.Length));

            return parameters.ToArray();
        }

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

            if (registro["image"] != DBNull.Value)
                movie.ImagemEmByte = registro["image"] as byte[];

            return movie;
        }

        protected override void SetTabela()
        {
            Tabela = "Movies";
        }
    }
}
