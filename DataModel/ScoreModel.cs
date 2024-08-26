using System;

namespace DataModel
{
    /*
    * Esse é o DataModel.
    * É onde ficam as propriedades de objeto 
    * classificado como "Modelo de Pontuação".
    */
    [Serializable]
    public class ScoreModel
    {
        // Nome da pontuação
        public string Name { get; set; }
        // Pontuação em cliques por segundo
        public string Cps { get; set; }
        // Duração em segundos
        public string Time { get; set; }
        // Data da pontuação
        public string ScoreDt { get; set; }
    }
}