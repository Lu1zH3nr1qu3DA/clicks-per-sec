using DataAcess;
using DataModel;
using System.Collections.Generic;

/*
 * Aqui é onde ficam as funções e métodos que tem o objetivo de:
 * C - Create (Cadastrar);
 * R - Read (Ler);
 * U - Update (Atualizar/Renomear);
 * D - Delete (Deletar).
 */

namespace DataLogic
{
    public class ScoreLogic
    {
        // Esse método leva a lista para ser gravada no arquivo.
        public void Save(List<ScoreModel> scorelist)
        {
            ScoreAcess score = new ScoreAcess();
            score.Save(scorelist);
        }

        // Essa função retorna a lista para ser preenchida com os dados do arquivo.
        public List<ScoreModel> Load(ref List<ScoreModel> scorelist)
        {
            ScoreAcess dal = new ScoreAcess();
            return dal.Load(ref scorelist);
        }

        // Esse método renomeia a pontuação desejada na lista.
        public void Rename(ref List<ScoreModel> scorelist, ref int scoreid, string name)
        {
            ScoreModel renamescore = new ScoreModel();
            renamescore = scorelist[scoreid];    // Copia os dados do item a ser renomeado.
            renamescore.Name = name;    // Altera o nome do item copiado.

            ScoreAcess score = new ScoreAcess();
            scorelist.Add(renamescore);    // Adiciona o item copiado como um novo item na lista.
            scorelist.Remove(scorelist[scoreid]);    // Remove o item com o nome antigo da lista.

            // Sobrescreve os dados no arquivo com a lista alterada.
            Save(scorelist);
        }

        // Esse método deleta um item da lista.
        public void Delete(ref List<ScoreModel> scorelist, ref int scoreid)
        {
            scorelist.Remove(scorelist[scoreid]);

            Save(scorelist);
        }
    }
}
