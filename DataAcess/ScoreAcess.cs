using DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataAcess
{
    /*
    * Esse é o ScoreAcess.
    * Ele contém os dois métodos que acessam o arquivo de dados:
    * "Salvar" (escrever) e "Carregar" os dados do arquivo binário.
    */
    public class ScoreAcess
    {
        static string filePath;    // O caminho para o arquivo.
        public ScoreAcess()
        {
            // O diretório em que o arquivo se localiza, o mesmo onde está o executável.
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "score.dat";    // Nome do arquivo.

            // Combina o diretório com o nome do arquivo, criando assim seu caminho.
            filePath = Path.Combine(dir, fileName);
        }

        // Esse método grava dados no arquivo binário.
        public void Save(List<ScoreModel> scorelist)
        {
            // Cria um formatador binário.
            BinaryFormatter formatter = new BinaryFormatter();

            // Abre um arquivo para gravação.
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // Serializa os dados e os escreve no arquivo.
                formatter.Serialize(stream, scorelist);
            }
        }

        /// <summary>
        /// Essa função retorna os dados do arquivo.
        /// </summary>
        /// <param name="scorelist">É a lista para onde os dados serão carregados.</param>
        /// <returns>Uma lista com os dados carregados.</returns>
        public List<ScoreModel> Load(ref List<ScoreModel> scorelist)
        {
            if (File.Exists(filePath))
            {
                // Cria um formatador binário.
                BinaryFormatter formatter = new BinaryFormatter();

                // Abre um arquivo para gravação.
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return (List<ScoreModel>)formatter.Deserialize(stream);    // Retorna uma lista com os dados.
                }
            }
            else
            {
                return new List<ScoreModel>();    // Retorna uma lista vazia.
            }
        }
    }
}