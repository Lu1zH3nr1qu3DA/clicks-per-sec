using MOD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
                    return (List<PontuacaoMOD>)formatter.Deserialize(stream);
                }
            }
            else
            {
                return new List<PontuacaoMOD>();
            }
        }
    }
}
