using System;

namespace Memento
{
    class GameCareTaker
    {
        public GameMemento Memento { get; set; }
    }

    class GameMemento
    {
        public int Level { get; set; }
        public string ChapterName { get; set; }
    }

    class Game
    {
        public int Level { get; set; }
        public string ChapterName { get; set; }

        public override string ToString()
        {
            return $"{Level}. Level of {ChapterName} Chapter.";
        }

        //T anında nesneyi tutacak olan metod.
        public GameMemento Save()
        {
            return new GameMemento
            {
                ChapterName = this.ChapterName,
                Level = this.Level
            };
        }

        //T anındaki nesneye bizi ulaşturacak olan metod.
        public void Restore(GameMemento Memento)
        {
            this.ChapterName = Memento.ChapterName;
            this.Level = Memento.Level;
        }
    }







    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Level = 1;
            game.ChapterName = "Fight";
            Console.WriteLine(game);

            GameCareTaker gameCareTaker = new GameCareTaker();
            gameCareTaker.Memento = game.Save();

            game.Level = 2;
            game.ChapterName = "Be a Defender";
            Console.WriteLine(game);

            game.Restore(gameCareTaker.Memento);
            Console.WriteLine(game);

        }
    }
}
