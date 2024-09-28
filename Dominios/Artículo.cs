using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 

namespace Dominios
{
    public class Artículo
    {
        public int Id { get; set; }
        public string Código { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }

        public Imagen imagen { get; set; }

        public Categoria categoria { get; set; }

        public Marca marca { get; set; }



    }
}
