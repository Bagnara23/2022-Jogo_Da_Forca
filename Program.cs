using System;

namespace Jogo_Da_Forca
{
    class Program
    {
        static void Main()
        {
            // Inicia jogo
            Game game = new Game(3); // 3 - É o numero de chances que o jogador tem.
            game.Play();
        }
    }
}