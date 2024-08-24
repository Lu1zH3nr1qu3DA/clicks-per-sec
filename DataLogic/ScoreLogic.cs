using DataAcess;
using DataModel;
using System.Collections.Generic;

namespace DataLogic
{
    public class ScoreLogic
    {

        public void Save(List<ScoreModel> scorelist)
        {
            ScoreAcess score = new ScoreAcess();
            score.Save(scorelist);
        }
        public void Rename()
        {
            ScoreAcess score = new ScoreAcess();

        }
        public void Delete(ref List<ScoreModel> scorelist, ScoreModel delscore)
        {
            ScoreAcess score = new ScoreAcess();
            score.Delete(ref scorelist, delscore);
        }
        public List<ScoreModel> LoadScores(ref List<ScoreModel> scorelist)
        {
            ScoreAcess dal = new ScoreAcess();
            return dal.LoadScores(ref scorelist);
        }
    }
}
