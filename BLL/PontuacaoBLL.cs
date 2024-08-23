using DAL;
using MOD;
using System.Collections.Generic;

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
