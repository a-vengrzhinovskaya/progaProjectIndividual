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
            Console.WriteLine($"\nHP: {Player.GetHP()}/{Player.MaxHealth}");
        }
    }

    public class EnemyRoom : Room {
        //TODO: сюда запихать всех врагов
        //private List<Enemy> Enemies = new List<Enemy> 

        public override void GetRoomEffect(CollectibleCoin Coins, Player Player) {
            Console.WriteLine("It's enemy rooooom!!\n");
            Console.WriteLine($"\nHP: {Player.GetHP()}/{Player.MaxHealth}");
        }

        private void Fight(Player Player, Enemy Enemy) {

        }
    }
}
