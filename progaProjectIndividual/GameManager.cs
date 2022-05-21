namespace progaProjectIndividual {

    public sealed class GameManager {
        private static GameManager Instance;
        private IPlayer player;

        public static GameManager GetInstance {
            get {
                if (Instance == null) {
                    Instance = new GameManager();
                }
                return Instance;
            }
        }

        public void Start() {
            //TODO: выбор персонажа
        }

        private void View() {
            //TODO: отображение
        }

        private void getInput() {
            //TODO: 
        }
    }
}