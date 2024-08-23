using System;

namespace DataModel
{
    [Serializable]
    public class ScoreModel
    {
        public string Name { get; set; }
        public string Cps { get; set; }
        public string Time { get; set; }
        public string ScoreDt { get; set; }
    }
}
