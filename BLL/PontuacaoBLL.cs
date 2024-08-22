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

        public void Salvar(List<PontuacaoMOD> listapontuacao)
        {
            PontuacaoDAL dal = new PontuacaoDAL();
            dal.Salvar(listapontuacao);
        }
        public List<PontuacaoMOD> CarregarPlacar(ref List<PontuacaoMOD> listapontuacao)
        {
            PontuacaoDAL dal = new PontuacaoDAL();
            return dal.CarregarPlacar(ref listapontuacao);
        }
    }
}
