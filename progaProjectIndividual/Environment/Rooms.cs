namespace progaProjectIndividual {
    public abstract class Room {
        protected CollectibleCoin Coins { get; set; }
        protected Player Player { get; set; }

        public Room(CollectibleCoin coins, Player player) {
            coins = Coins;
            player = Player;
        }

        public abstract void GetRoomEffect();
    }

    public class CoinRoom : Room {
        public CoinRoom(CollectibleCoin coins, Player player) : base(coins, player) { }

        public override void GetRoomEffect() {
            Coins.ChangeAmount();
        }
    }

    public class HealRoom : Room {
        public HealRoom(CollectibleCoin coins, Player player) : base(coins, player) { }

        public override void GetRoomEffect() {
            Player.Heal(20);
        }
    }

    public class EnemyRoom : Room {
        //TODO: сюда запихать всех врагов
        //private List<Enemy> Enemies = new List<Enemy> 

        public EnemyRoom(CollectibleCoin coins, Player player) : base(coins, player) { }

        public override void GetRoomEffect() {
            Console.WriteLine("It's enemy rooooom!!");
        }
    }
}
