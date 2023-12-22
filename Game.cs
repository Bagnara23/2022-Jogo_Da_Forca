using System;
using System.Collections.Generic;

namespace Jogo_Da_Forca
{
    class Game // Representa o jogo.
    {

        private int maxErrors; // Indica o número máximo de erros que o jogador pode ter antes do jogo terminar.

        public Game(int maxErrors) // Construtor
        {
            this.maxErrors = maxErrors;
        }

        public void Play() // Jogar
        {
            Word w = new Word(); // Cria o objeto que vai gerenciar a palavra ativa do jogo.

            while(1 == 1)
            {
                Console.WriteLine("-- Jogo da Forca --\n");
                Console.WriteLine("Você pode errar no máximo {0} vezes! \n", maxErrors);

                int errors = 0; // Variável para controlar os erros do jogador.

                ISet<char> triedLetters = new HashSet<char>(); // Set para armazenar as letras já tentadas (para evitar que o jogador as tente novamente).

                // O jogo fica ativo enquanto a palavra não for encontrada por completo e enquantoo jogador não atingir o número máximo de erros.
                while(!w.Finished && errors < maxErrors)
                {
                    Console.WriteLine(w.PartialWord);

                    Console.WriteLine("\nDigite uma letra: "); // Solicita a letra ao jogador.
                    string letter = Console.ReadLine();

                    if (String.IsNullOrWhiteSpace(letter)) // Se o jogador não digitar nada, solicitar novamente.
                    {
                        continue;
                    }
                    
                    if (triedLetters.Contains(letter[0])) // Verifica se o jogador já não tentou essa letra.
                    {
                        // Se ja tentou, solicita novamente.
                        Console.WriteLine("\nA letra {0} já foi tentada!\n", letter[0]);
                        continue;
                    }
                    else
                    {
                        // Se não tentou, adiciona a letra no set de letras ja inseridas.
                        triedLetters.Add(letter[0]);
                    }

                    bool found = w.Guess(letter[0]); // Procura a letra na palavra.


                    if (found) 
                    {
                        Console.WriteLine("\nParabéns! A letra {0} foi encontrada!", letter[0]); // Se encontrou, mostre essa mensagem.
                    }
                    else
                    {
                        errors++; // Incrementa +1 ao numero de erros ocorridos.
                        Console.WriteLine("\nSinto muito, a letra {0} não existe na palavra. \nVocê errou ({1}) vez(es)", letter[0], errors); // Se não encontrou, mostre essa mensagem.
                    }

                    Console.WriteLine();
                }

                if (errors < maxErrors) // Se o loop terminou, foi porque o jogador ganhou ou perdeu.
                {
                    // Se o número máximo de erros não foi atingido, o jogador ganhou.
                    Console.WriteLine("\nVocê adivinhou a palavra: {0}.", w.CompleteWord);
                    Console.WriteLine("\nVocê deseja jogar mais uma vez? (S/N)\n");

                }
                else
                {
                    // Se o número máximo de erros foi atingido, o jogador perdeu.
                    Console.WriteLine("\nVocê não adivinhou a palavra: {0}", w.CompleteWord);
                    Console.WriteLine("\nVocê deseja jogar mais uma vez? (S/N)\n");
                }

                string playAgain = Console.ReadLine(); // Aguarda a opção selecionada pelo jogador.

                if (playAgain.Length > 0 && (playAgain[0] == 's' || playAgain[0] == 'S')) // Jogador deseja jogar novamente.
                {
                    Console.WriteLine("\nOk, vamos jogar novamente!"); // Jogar novamente.

                    w.Next(); // Vai para a próxima palavra.

                    Console.Clear(); // Limpa o console.
                }
                else
                {
                    // Caso o usuario digite alguma outra coisa diferente de 's' ou 'S'...
                    Console.WriteLine("\nIsso é tudo pessoal!");
                    break;
                }
            }
        }
    }
}
