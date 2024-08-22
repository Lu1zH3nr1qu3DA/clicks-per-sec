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
        static string filePath;
        public PontuacaoDAL()
        {
            string diretorio = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "pontuacao.dat";
            filePath = Path.Combine(diretorio, fileName);
        }

        public void Salvar(List<PontuacaoMOD> listapontuacao)
        {
            // Cria um formatador binário
            BinaryFormatter formatter = new BinaryFormatter();

            // Abre um arquivo para gravação
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // Serializa os dados e os escreve no arquivo
                formatter.Serialize(stream, listapontuacao);
            }   
        }
        public List<PontuacaoMOD> CarregarPlacar(ref List<PontuacaoMOD> listapontuacao)
        {
            if (File.Exists(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return listapontuacao = (List<PontuacaoMOD>)formatter.Deserialize(stream);
                }
            }
            else
            {
                return listapontuacao;
            }
        }
    }
}
