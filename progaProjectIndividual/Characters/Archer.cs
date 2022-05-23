namespace progaProjectIndividual.Characters {
    public class Archer : Player, IObservable {
        public override int MaxHealth { get; protected set; } = 100;
        protected override int Health { get; set; }
        public override int Damage { get; set; } = 20;

        private List<IObserver> observers = new List<IObserver>();

        public Archer() {
            Health = MaxHealth;
        }

        public override void UseAbility(Player Player, Enemy Enemy) {
            
        }

        public void AddObserver(IObserver observer) {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer) {
            observers.Remove(observer);
        }

        public void NotifyObservers() {
            foreach (IObserver observer in observers) {
                observer.Update();
            }
        }
    }

    public interface IObservable {
        public void AddObserver(IObserver observer);
        public void RemoveObserver(IObserver observer);
        public void NotifyObservers();
    }

    public interface IObserver {
        void Update();
    }
    class ConcreteObserver : IObserver {
        public void Update() {

        }
    }
}
