namespace progaProjectIndividual.Characters {
    public class Warrior : Player {
        protected override int Health { get; set; } = 90;
        protected override int Damage { get; set; } = 25;

        //private delegate WarriorClone Ability();
        //private Ability Skill = MakeClone;

        private WarriorClone MakeClone() {
            var clone = new WarriorClone();

            return (WarriorClone)clone.Clone();
        }

        public override object UseAbility() {
            return 1;
        }
    }

    public class WarriorClone: Warrior, ICloneable {
        public object Clone() {
            var clone = new WarriorClone();

            clone.Health = Health / 2;
            clone.Damage = Damage / 2;

            return clone;
        }
    }
}
