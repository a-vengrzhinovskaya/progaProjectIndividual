namespace progaProjectIndividual.Characters {
    internal class Wizard : Player, IOriginator {
        public override int MaxHealth { get; protected set; } = 80;
        protected override int Health { get; set; }
        public override int Damage { get; set; } = 30;

        public Wizard() {
            Health = MaxHealth;
        }

        public override void UseAbility(Player Player, Enemy Enemy, Caretaker Caretaker) {
            Console.WriteLine("You restored your HP!");
            Caretaker.RestoreState((Wizard)Player);
        }

        object IOriginator.GetMemento() {

            return new Memento { Health = this.Health };
        }

        void IOriginator.SetMemento(object memento) {

            if (memento is Memento) {

                var mem = (Memento)memento;
                Health = mem.Health;
            }
        }
    }

    public interface IOriginator {
        object GetMemento();
        void SetMemento(object memento);
    }

    public class Caretaker {
        private object Мemento;

        public void SaveState(IOriginator Оriginator) {
            Мemento = Оriginator.GetMemento();
        }

        public void RestoreState(IOriginator Оriginator) {
            Оriginator.SetMemento(Мemento);
        }
    }

    public class Memento {
        public int Health { get; set; }
    }
}