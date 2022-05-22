namespace progaProjectIndividual.Characters {
    public class Archer : Player, IObservable {
        protected override int Health { get; set; } = 100;
        protected override int Damage { get; set; } = 20;

        private List<IObserver> observers = new List<IObserver>();

        public override object UseAbility() {
            return 1;
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
