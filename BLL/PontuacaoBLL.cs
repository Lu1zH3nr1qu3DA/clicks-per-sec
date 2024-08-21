using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MOD;

namespace BLL
{
    public class PontuacaoBLL
    {

        public void Salvar(PontuacaoMOD pontuacao)
        {
            PontuacaoDAL dal = new PontuacaoDAL();
            dal.Salvar(pontuacao);
        }

        public void CarregarPontuacao()
        {
            PontuacaoDAL dal = new PontuacaoDAL();
            dal.CarregarPontuacao();
        }
        public List<PontuacaoMOD> CarregarPlacar()
        {
            PontuacaoDAL dal = new PontuacaoDAL();
            return dal.CarregarPlacar();
        }
    }
}
