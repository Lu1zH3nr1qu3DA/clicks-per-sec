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
        public List<ScoreModel> Load(ref List<ScoreModel> scorelist)
        {
            ScoreAcess dal = new ScoreAcess();
            return dal.Load(ref scorelist);
        }
        public void Rename(ref List<ScoreModel> scorelist, ref int scoreid, string name)
        {
            ScoreModel renamescore = new ScoreModel();
            renamescore = scorelist[scoreid];
            renamescore.Name = name;

            ScoreAcess score = new ScoreAcess();
            scorelist.Add(renamescore);
            scorelist.Remove(scorelist[scoreid]);
        }
        public void Delete(ref List<ScoreModel> scorelist, ref int scoreid)
        {
            ScoreModel delscore = new ScoreModel();
            delscore = scorelist[scoreid];

            ScoreAcess score = new ScoreAcess();
            scorelist.Remove(delscore);
            Save(scorelist);
        }
    }
}
