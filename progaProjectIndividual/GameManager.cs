using System.Collections.Generic;
using System.Threading;
using progaProjectIndividual.Characters;

namespace progaProjectIndividual {

    public sealed class GameManager {
        private const int WaitingTime = 800;
        private static GameManager Instance;
        private Player Player;
        private CollectibleCoin Coins;
        private List<String> Paths = new List<String> {
                "You are walking along a forest road.\nSuddenly it diverges into two paths.\nWhich one will you choose?\n",
                "You have entered an ancient castle.\nWalking through its huge corridors, you come across two doors.\nWhich one will you choose?\n",
                "Once you get to the creepy graveyard, you see a tombstone that reads:\n<To the right, you become rich. To the left, you die.>\n",
                "You see a mysterious old man pointing to the left.\nListening to him or not is up to you.\n",
                "In the distance you can see a tower.\nThere are two ways to it: to the right through the catacombs or to the left through the thorns."
        };

        public static GameManager GetInstance {
            get {
                if (Instance == null) {
                    Instance = new GameManager();
                }
                return Instance;
            }
        }

        public void Start() {
            var CoinsData = new FileStream("C:/Users/aveng/source/repos/progaProjectIndividual/progaProjectIndividual/coins_data.bin", FileMode.OpenOrCreate, FileAccess.Read);
            if (CoinsData.Length != 0) {
                Coins.Deserialize(CoinsData);
                CoinsData.Close();
            }

            var NotSet = true;

            while(NotSet) {
                //TODO: добавить описание
                Console.WriteLine("Choose your character class:\n");
                Console.WriteLine("Warrion");
                Console.WriteLine("Wizard");
                Console.WriteLine("Archer");
                Console.WriteLine("\nType 0 for Warrior, 1 for Wizard, 2 for Archer");

                switch (Console.ReadLine()) {
                    case "0": {
                            Console.Clear();
                            Console.WriteLine("Starting new game as Warrior...\n");
                            Thread.Sleep(WaitingTime);
                            Player = new Warrior();
                            NotSet = false;
                            break;
                    }
                    case "1": {
                            Console.Clear();
                            Console.WriteLine("Starting new game as Wizard...\n");
                            Thread.Sleep(WaitingTime);
                            Player = new Wizard();
                            NotSet = false;
                            break;
                    }
                    case "2": {
                            Console.Clear();
                            Console.WriteLine("Starting new game as Archer...\n");
                            Thread.Sleep(WaitingTime);
                            Player = new Archer();
                            NotSet = false;
                            break;
                    }
                    default: {
                            Console.Clear();
                            break;
                    }
                }
            }
        }

        public void Move() {
            var rand = new Random();
            var CurrentPathIndex = rand.Next(0, Paths.Count - 1);
            var CurrentPath = Paths[CurrentPathIndex];
            Paths.Remove(CurrentPath);


            var NotSet = true;

            while(NotSet) {
                Console.WriteLine(CurrentPath);
                Console.WriteLine("\nRIGHT 0           LEFT 1");

                switch (Console.ReadLine()) {
                    case "0": {
                            Console.Clear();
                            Console.WriteLine("You went to the right...\n");
                            Thread.Sleep(WaitingTime);
                            NextRoom();
                            NotSet = false;
                            break;
                    }
                    case "1": {
                            Console.Clear();
                            Console.WriteLine("You went to the left...\n");
                            Thread.Sleep(WaitingTime);
                            NextRoom();
                            NotSet = false;
                            break;
                    }
                    default: {
                            Console.Clear();
                            break;
                    }
                }
            }
        }

        private void NextRoom() {
            //TODO: генерация следующей комнаты

        }
    }
}