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
        public void Delete(ScoreModel delscore, List<ScoreModel> scorelist)
        {
            ScoreAcess score = new ScoreAcess();
            score.Delete(scorelist, delscore);
        }
        public List<ScoreModel> LoadScores(ref List<ScoreModel> scorelist)
        {
            ScoreAcess dal = new ScoreAcess();
            return dal.LoadScores(ref scorelist);
        }
    }
}
