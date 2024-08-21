using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MOD;

namespace BLL
{
    public class PontuacaoBLL
    {
        public void Inserir(PontuacaoMOD objpontuacao)
        {
            PontuacaoDAL pontuacao = new PontuacaoDAL();
            pontuacao.Inserir(objpontuacao);
        }
    }
}
