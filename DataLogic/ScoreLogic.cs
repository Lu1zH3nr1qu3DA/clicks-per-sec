using DataAcess;
using DataModel;
using System.Collections.Generic;

/// <summary>
///  Destinado às funções e métodos
///  Create (Cadastrar);
///  Read (Ler);
///  Update (Atualizar);
///  Delete (Deletar).
/// </summary>

namespace DataLogic
{
    public class ScoreLogic
    {
        // Método que leva a lista para ser gravada no arquivo.
        public void Save(List<ScoreModel> scorelist)
        {
            ScoreAcess score = new ScoreAcess();
            score.Save(scorelist);
        }

        // Função para retornar a lista para ser preenchida com os dados do arquivo.
        public List<ScoreModel> Load(ref List<ScoreModel> scorelist)
        {
            ScoreAcess dal = new ScoreAcess();
            return dal.Load(ref scorelist);
        }

        // Esse método renomeia a pontuação desejada na lista.
        public void Rename(ref List<ScoreModel> scorelist, ref int scoreid, string name)
        {
            ScoreModel renamescore = new ScoreModel();
            renamescore = scorelist[scoreid];
            renamescore.Name = name;

            ScoreAcess score = new ScoreAcess();
            scorelist.Add(renamescore);
            scorelist.Remove(scorelist[scoreid]);

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
