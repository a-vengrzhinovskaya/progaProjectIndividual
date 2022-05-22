using System.Xml.Serialization;

namespace progaProjectIndividual {
    [Serializable]
    public class CollectibleCoin {
        private const int CoinsAmount = 10;
        private int CurrentCoinIndex = 0;
        public bool[] Coins { get; private set; } = new bool[CoinsAmount];

        public void ChangeAmount() {
            Coins[CurrentCoinIndex] = true;
            ++CurrentCoinIndex;
        }

        public void Serialize(FileStream file) {
            var Formatter = new XmlSerializer(this.GetType());
            Formatter.Serialize(file, this);
            file.Close();
        }

        public void Deserialize(FileStream file) {
            var Formatter = new XmlSerializer(this.GetType());
            var Deserialized = (CollectibleCoin)Formatter.Deserialize(file);
            CurrentCoinIndex = Deserialized.CurrentCoinIndex;
            Coins = Deserialized.Coins;
            file.Close();
        }
    }
}
