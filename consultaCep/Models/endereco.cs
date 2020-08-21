using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace consultaCep.Models
{
    public class Endereco
    {
        public string Cep { get; set; }

        public string Rua { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}