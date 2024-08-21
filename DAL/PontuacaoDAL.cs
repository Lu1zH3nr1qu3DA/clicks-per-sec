using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOD;

namespace DAL
{
    public class PontuacaoDAL
    {
        public void Inserir(PontuacaoMOD objDados)
        {
            //Objeto de conexao com o banco de dados
            AcessoDados consulta = new AcessoDados();

            try
            {
                consulta.LimparParametros();

                string SQL = " INSERT INTO Pontuacao (Nome, Cps, Tempo, DataPontuacao) " +
                             " VALUES (@Nome, @Cps, @Tempo, @DataPontuacao) ";

                //Passagem dos valores para os parametros
                consulta.AdicionarParametro("@Nome", SqlDbType.VarChar, objDados.Nome);
                consulta.AdicionarParametro("@Cps", SqlDbType.VarChar, objDados.Cps);
                consulta.AdicionarParametro("@Tempo", SqlDbType.VarChar, objDados.Tempo);
                consulta.AdicionarParametro("@DataPontuacao", SqlDbType.DateTime, objDados.DataPontuacao);

                consulta.ExecutaAtualizacao(SQL);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro banco de dados: " + ex.Message);
            }
        }
    }
}
