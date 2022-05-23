namespace progaProjectIndividual.Characters {
    public abstract class WarriorPrototype : Player {
        public override int MaxHealth { get; protected set; } = 90;
        protected override int Health { get; set; }
        public override int Damage { get; set; } = 25;

        public WarriorPrototype() {
            Health = MaxHealth;
        }
    }

    public class Warrior: WarriorPrototype, ICloneable {
        public object Clone() {
            var clone = new Warrior();

            clone.MaxHealth = MaxHealth / 2;
            clone.Health = Health / 2;
            clone.Damage = Damage / 2;

            return clone;
        }

        public override void UseAbility(Player Player, Enemy Enemy, Caretaker Caretaker) {
            Console.WriteLine("You created your clone!");
            Console.WriteLine("You can attack now.");
            var WarriorClone = (Warrior)Clone();

            while (WarriorClone.GetHP() > 0) {
                var Option = Console.ReadLine();
                if (Option == "0") {
                    Player.Attack(Enemy);
                    Console.WriteLine($"You attacked {Enemy.Name}!");
                }
                Console.WriteLine($"The {Enemy.Name} attacked your clone!");
                Enemy.Attack(WarriorClone);

                if (WarriorClone.GetHP() >= 0) {
                    Console.WriteLine($"\nclone HP: {WarriorClone.GetHP()}/{WarriorClone.MaxHealth}");
                }
                if (Enemy.GetHP() >= 0) {
                    Console.WriteLine($"\n{Enemy.Name} HP: {Enemy.GetHP()}/{Enemy.MaxHealth}");
                    Console.WriteLine($"\nyour HP: {Player.GetHP()}/{Player.MaxHealth}");
                }
            }

            Console.WriteLine("Clone was destroyed.\n");
        }
    }
}
