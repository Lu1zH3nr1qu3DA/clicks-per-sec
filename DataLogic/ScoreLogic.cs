using DataAcess;
using DataModel;
using System.Collections.Generic;

namespace DataLogic
{
    public class ScoreLogic
    {

        public void Save(List<ScoreModel> scorelist)
        {
            ScoreAcess dal = new ScoreAcess();
            dal.Save(scorelist);
        }
        public List<ScoreModel> LoadScores(ref List<ScoreModel> scorelist)
        {
            ScoreAcess dal = new ScoreAcess();
            return dal.LoadScores(ref scorelist);
        }
    }
}
