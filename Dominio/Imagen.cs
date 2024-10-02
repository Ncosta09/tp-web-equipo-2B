using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
        public int Id { get; set; }
        public string imgUrl { get; set; }

        public override string ToString()
        {
            return imgUrl;
        }
    }
}
