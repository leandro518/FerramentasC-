using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeitorArquivo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome do arquivo a ser lido : ");
            var nomeArquivo = Console.ReadLine().Trim();

            var linhas = LeitordeArquivo(nomeArquivo);
            var emails = ProcuraEmails(linhas);
            GuardaEmails(emails);
        }
        // Realiza a leitura de todas as linhas dos arquivos
        static string[] LeitordeArquivo(string nomeArquivo)
        {
            return File.ReadAllLines(nomeArquivo);
        }
        // Procura emails na string
        static List<string> ProcuraEmails(string[] linhas)
        {
            List<string> emails = new List<string>();

            foreach (var item in linhas)
            {
                if (item.Contains("@"))
                {
                    var linhas2 = item.Split(' ');
                    foreach (var item2 in linhas2)
                    {
                        if (item2.Contains("@"))
                            emails.Add(item2);
                    }
                }
            }

            return emails;
        }
        // Funcao para guardar os emaiss
        static void GuardaEmails( List<string> emails)
        {
            using (StreamWriter outputFile = new StreamWriter("emails.csv"))
            {
                var separador = ";";

                for (int i = 0; i < emails.Count; i++)
                {
                    if (i == (emails.Count -1 ))
                        separador = "";

                    outputFile.WriteLine(emails[i] + separador);
                }
            }
        }
    }
}
