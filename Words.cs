using System;
using System.IO;

namespace Jogo_Da_Forca
{
    class Words // Gerencia as palavras que fazem parte do jogo.
    {
        /* FIELDS */

        // Nome do arquivo onde estão as palavras (as palavras devem estar uma em cada linha).
        private const string FileName = "C:\\Users\\AntonioRodri\\source\\repos\\Jogo_Da_Forca\\words.txt"; 

        private Random random = new Random(); // Gera um número randomico.

        private string[] words; // Array com as palavras que fazem parte do jogo.

        /* CONSTRUTOR */

        public Words()
        {
            ReadWords(); // Lê as palavras do arquivo.
        }

        private void ReadWords()
        {
            this.words = File.ReadAllLines(FileName); // Lê as palavras para dentro de um array.

            for(int i = 0; i < words.Length; i++) // Converte todas as letras das palavras para minúsculas.
            {
                words[i] = words[i].ToUpper();
            }
        }

        public string Pick() // Sorteia uma nova palavra
        {
            int index = random.Next(words.Length); // Gera um número entre 0 e o tamanho do array de palavras.
            return words[index];
        }

    }
}
