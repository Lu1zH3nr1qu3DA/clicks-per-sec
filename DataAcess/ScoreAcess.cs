using DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataAcess
{
    public class ScoreAcess
    {
        static string filePath;
        public ScoreAcess()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "score.dat";
            filePath = Path.Combine(dir, fileName);
        }

        public void Save(List<ScoreModel> scorelist)
        {
            // Cria um formatador binário
            BinaryFormatter formatter = new BinaryFormatter();

            // Abre um arquivo para gravação
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // Serializa os dados e os escreve no arquivo
                formatter.Serialize(stream, scorelist);
            }
        }
        public void Delete(ref List<ScoreModel> scorelist, ScoreModel score)
        {
            scorelist.Remove(score);
            Save(scorelist);
        }
        public List<ScoreModel> LoadScores(ref List<ScoreModel> scorelist)
        {
            if (File.Exists(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return (List<ScoreModel>)formatter.Deserialize(stream);
                }
            }
            else
            {
                return new List<ScoreModel>();
            }
        }
    }
}
