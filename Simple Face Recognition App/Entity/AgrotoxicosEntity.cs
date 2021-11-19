using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS.Entity
{
    public class AgrotoxicosEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Grupo { get; set; }
        public string Classificacao { get; set; }
        public int Nivel { get; set; }

        public AgrotoxicosEntity() { }
    }
}
