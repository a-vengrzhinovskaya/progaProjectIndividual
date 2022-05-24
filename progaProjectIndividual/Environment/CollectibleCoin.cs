using System.Runtime.Serialization.Formatters.Binary;

namespace progaProjectIndividual {
    [Serializable]
    public class CollectibleCoin {
        private const int MaxCoinsAmount = 10;
        private int CurrentCoinIndex = 0;
        public bool[] Coins { get; set; } = new bool[MaxCoinsAmount];

        public void ChangeAmount() {
            Coins[CurrentCoinIndex] = true;
            ++CurrentCoinIndex;
        }

        public int GetAmountCollected() {
            var Amount = 0;
            foreach (var Coin in Coins) {
                if (Coin != false) {
                    ++Amount;
                }
            }
            return Amount;
        }

        public void Serialize(FileStream file) {
            var Formatter = new BinaryFormatter();
            Formatter.Serialize(file, this);
            file.Close();
        }

        public void Deserialize(FileStream file) {
            var Formatter = new BinaryFormatter();
            var Deserialized = (CollectibleCoin)Formatter.Deserialize(file);
            CurrentCoinIndex = Deserialized.CurrentCoinIndex;
            Coins = Deserialized.Coins;
            file.Close();
        }
    }
}
