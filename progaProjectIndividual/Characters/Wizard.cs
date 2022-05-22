namespace progaProjectIndividual.Characters {
    internal class Wizard : Player, IOriginator {
        protected override int Health { get; set; } = 80;
        protected override int Damage { get; set; } = 30;

        public override object UseAbility() {
            return 1;
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
        private object memento;

        public void SaveState(IOriginator originator) {
            memento = originator.GetMemento();
        }

        public void RestoreState(IOriginator originator) {
            originator.SetMemento(memento);
        }
    }

    public class Memento {
        public int Health { get; set; }
    }
}