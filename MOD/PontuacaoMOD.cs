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
        public string Nome { get; set; }
        public double Cps { get; set; }
        public double Tempo { get; set; }
        public DateTime DataPontuacao { get; set; }
        public PontuacaoMOD(ref string nome, ref double cps, ref double tempoi, ref DateTime dataPontuacao)
        {
            Nome = nome;
            Cps = cps;
            Tempo = tempoi;
            DataPontuacao = dataPontuacao;
        }
        public override string ToString()
        {
            return $"{Nome}, {Cps}, {Tempo}, {DataPontuacao}";
        }
    }
}
