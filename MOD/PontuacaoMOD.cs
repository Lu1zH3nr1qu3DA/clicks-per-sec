using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD
{
    [Serializable]
    public class PontuacaoMOD
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Cps { get; set; }
        public double Tempo { get; set; }
        public DateTime DataPontuacao { get; set; }
    }
}
