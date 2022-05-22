namespace progaProjectIndividual {
    public abstract class Room {
        public abstract void GetRoomEffect(CollectibleCoin coins, Player player);
    }

    public class CoinRoom : Room {
        public override void GetRoomEffect(CollectibleCoin coins, Player player) {
            Console.WriteLine("\nYou found a rare coin!\n");
            coins.ChangeAmount();
            Console.WriteLine($"\nHP: {player.GetHP()}/{player.MaxHealth}");
        }
    }

    public class HealRoom : Room {
        public override void GetRoomEffect(CollectibleCoin coins, Player player) {
            Console.WriteLine("\nYour HP restored by 20.\n");
            if (player.GetHP() < player.MaxHealth) {
                player.Heal(20);
            }
            Console.WriteLine($"\nHP: {player.GetHP()}/{player.MaxHealth}");
        }
    }

    public class EnemyRoom : Room {
        //TODO: сюда запихать всех врагов
        //private List<Enemy> Enemies = new List<Enemy> 

        public override void GetRoomEffect(CollectibleCoin coins, Player player) {
            Console.WriteLine("It's enemy rooooom!!\n");
            Console.WriteLine($"\nHP: {player.GetHP()}/{player.MaxHealth}");
        }
    }
}
