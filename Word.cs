using System;
using System.IO;

namespace Jogo_Da_Forca
{
    class Word // Gerencia a palavra ativa do jogo.
    {

        private const char WildCard = '*'; // Caractere a ser mostrado no lugar das letras ainda não adivinhadas.

        private Words words = new Words(); // Objeto que gerencia as palavras do jogo.

        private char[] completeWordChars; // Caracteres da palavra completa.

        private char[] partialWordChars; // Caracteres da palavra parcial, que pode conter wildcards.

        public string CompleteWord { get; private set; } // Palavra completa.

        public string PartialWord // Palavra parcial
        {
            get
            {
                return new string(partialWordChars); // Cria uma string usando o array de caracteres...
            }
        }

        public bool Finished // Indica se o jogo terminou (i.e. a palavra foi adivinhada por completo).
        {
            get
            {
                return PartialWord == CompleteWord; // Verifica se a palavra é igual á palavra completa.
            }
        }

        public Word() // Construtor
        {
            Next(); // Ao ser construído, o objeto já busca a primeira palavra.
        }

        public void Next() // Obtém uma nova palavra.
        {
            this.CompleteWord = words.Pick(); // Sorteia uma nova palavra.

            this.completeWordChars = this.CompleteWord.ToCharArray(); // Converte a palavra para um char[].

            this.partialWordChars = new char[completeWordChars.Length]; // Instancia o array de caracteres da palavra parcial, e atribui o wildcard a todas as posições.

            for(int i = 0; i < partialWordChars.Length; i++)
            {
                if (completeWordChars[i] != ' ')
                {
                    partialWordChars[i] = WildCard;
                }
                else
                {
                    partialWordChars[i] = ' ';
                }
            }
        }

        public bool Guess(char letter) // Tenta adivinhar uma letra.
        {
            bool found = false;

            letter = Char.ToUpper(letter); // Converte o caractere para maiúsculo, pois as palavras estão todas com letras maiúsculas.
            
            for (int i = 0; i < completeWordChars.Length; i++) // Procura a letra na palavra.
            {
                if (completeWordChars[i] == letter) 
                {
                    // Se a letra for encontrada, o array de caracteres da palavra parcial tem o wildcard correspondente substituído pela letra.
                    partialWordChars[i] = letter;
                    found = true;
                }
            }

            return found;
        }
    }
}
