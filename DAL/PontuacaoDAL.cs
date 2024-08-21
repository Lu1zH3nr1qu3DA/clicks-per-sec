using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using MOD;

namespace DAL
{
    public class PontuacaoDAL
    {
        static string diretorio = AppDomain.CurrentDomain.BaseDirectory;
        static string fileName = "pontuacao.dat";
        static string filePath = Path.Combine(diretorio, fileName);

        public void Salvar(PontuacaoMOD data)
        {
            // Cria um formatador binário
            BinaryFormatter formatter = new BinaryFormatter();

            // Abre um arquivo para gravação
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // Serializa os dados e os escreve no arquivo
                formatter.Serialize(stream, data);
            }   
        }
        public List<PontuacaoMOD> CarregarPontuacao()
        {
            // Cria um formatador binário
            BinaryFormatter formatter = new BinaryFormatter();

            // Abre o arquivo para leitura
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                // Desserializa os dados do arquivo e os converte de volta para um objeto PontuacaoMOD
                return (List<PontuacaoMOD>)formatter.Deserialize(stream);
            }
        }
        public List<PontuacaoMOD> CarregarPlacar()
        {
            if (File.Exists(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return (List<PontuacaoMOD>)formatter.Deserialize(stream);
                }
            }
            return new List<PontuacaoMOD>();
        }
    }
}
