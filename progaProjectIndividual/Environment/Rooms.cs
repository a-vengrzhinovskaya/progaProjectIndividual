using progaProjectIndividual.Characters;

namespace progaProjectIndividual {
    public abstract class Room {
        public abstract void GetRoomEffect(CollectibleCoin coins, Player Player);
    }

    public class CoinRoom : Room {
        public override void GetRoomEffect(CollectibleCoin Coins, Player Player) {
            Console.WriteLine("\nYou found a rare coin!\n");
            Coins.ChangeAmount();
            Console.WriteLine($"\nHP: {Player.GetHP()}/{Player.MaxHealth}");
        }
    }

    public class HealRoom : Room {
        public override void GetRoomEffect(CollectibleCoin Coins, Player Player) {
            Console.WriteLine("\nYour HP restored by 20.\n");
            if (Player.GetHP() < Player.MaxHealth) {
                Player.Heal(20);
            }
            if (Player.GetHP() > Player.MaxHealth) {
                Player.SetHP(Player.MaxHealth);
            }
            Console.WriteLine($"\nHP: {Player.GetHP()}/{Player.MaxHealth}");
        }
    }

    public class EnemyRoom : Room {
        private List<Factory> Enemies = new List<Factory> { new SpiderFactory(), new SkeletonFactory(), new DemonFactory() };

        public override void GetRoomEffect(CollectibleCoin Coins, Player Player) {
            var Rand = new Random();
            var Enemy = Enemies[Rand.Next(0, Enemies.Count - 1)].FactoryMethod();
            Console.WriteLine($"You encountered a {Enemy.Name}!");
            if (!Player.AbilityUsed) {
                Console.WriteLine("\nATTACK 0           USE ABILITY 1\n");
            } else {
                Console.WriteLine("\nATTACK 0");
            }

            Fight(Player, Enemy);
        }

        private void Fight(Player Player, Enemy Enemy) {
            var Caretaker = new Caretaker();
            if (!Player.AbilityUsed && Player is Wizard) {
                Caretaker.SaveState((Wizard)Player);
            }
            while (Enemy.GetHP() > 0) {
                if (!Player.AbilityUsed) {
                    var Option = Console.ReadLine();
                    if (Option == "0") {
                        Player.Attack(Enemy);
                        Console.WriteLine($"You attacked {Enemy.Name}!");
                    } else if (Option == "1") {
                        Player.UseAbility(Player, Enemy, Caretaker);
                        Console.WriteLine($"You used your ability on {Enemy.Name}.");
                        Console.WriteLine($"The {Enemy.Name} skips its turn.");
                        Console.WriteLine($"\nyour HP: {Player.GetHP()}/{Player.MaxHealth}");
                        if (Enemy.GetHP() > 0) {
                            Console.WriteLine($"\n{Enemy.Name} HP: {Enemy.GetHP()}/{Enemy.MaxHealth}");
                        } else {
                            Console.WriteLine($"\nYou defeated the {Enemy.Name}!");
                            Console.WriteLine($"\nyour HP: {Player.GetHP()}/{Player.MaxHealth}");
                        }
                        Player.AbilityUsed = true;
                        continue;
                    }
                } else {
                    var Option = Console.ReadLine();
                    if (Option == "0") {
                        Player.Attack(Enemy);
                        Console.WriteLine($"You attacked {Enemy.Name}!");
                    }
                }
                
                if (Enemy.GetHP() >= 0) {
                    Console.WriteLine($"The {Enemy.Name} attacked you!");
                    Enemy.Attack(Player);
                } else {
                    Console.WriteLine($"\nYou defeated the {Enemy.Name}!");
                    Console.WriteLine($"your HP: {Player.GetHP()}/{Player.MaxHealth}");
                    break;
                }
                
                if (Player.GetHP() <= 0) {
                    throw new Exception();
                }

                Console.WriteLine($"\nyour HP: {Player.GetHP()}/{Player.MaxHealth}");
                Console.WriteLine($"\n{Enemy.Name} HP: {Enemy.GetHP()}/{Enemy.MaxHealth}");
            }
        }
    }
}