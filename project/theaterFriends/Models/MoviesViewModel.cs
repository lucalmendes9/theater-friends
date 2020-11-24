using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theaterFriends.Models
{
    public class MoviesViewModel : PadraoViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
        public int Min_age { get; set; }
        public string Language { get; set; }
        public bool Subtitle { get; set; }

        //Atributos não mapeados

        public string City { get; set; }
        public string Description_Theater { get; set; }
        public DateTime Start_Date { get; set; }

        //For Cover = Image

        public IFormFile Imagem { get; set; } //Imagem recebida do form pelo controller
        public byte[] ImagemEmByte { get; set; } //Imagem em bytes pronta para ser salva

        public string ImagemEmBase64 //Imagem usada para ser enviada ao form no formato para ser exibida
        {
            get
            {
                if (ImagemEmByte != null)
                    return Convert.ToBase64String(ImagemEmByte);
                else
                    return "";
            }
        }

    }
}
