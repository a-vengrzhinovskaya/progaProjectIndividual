namespace progaProjectIndividual.Characters {
    public abstract class Enemy : Character {
        public abstract string Name { get; }

        public abstract void AttackPlayer(Player Player);
    }

    public class Spider : Enemy {
        public override string Name { get; } = "spider";
        public override int MaxHealth { get; protected set; } = 50;
        protected override int Health { get; set; }
        public override int Damage { get; set; } = 10;

        public Spider() {
            Health = MaxHealth;
        }

        public override void AttackPlayer(Player Player) {
            Attack(Player);
            Console.WriteLine($"The {Name} attacked you!\nYou lost {Damage}HP.");
        }
    }

    public class Skeleton : Enemy {
        public override string Name { get; } = "skeleton";
        public override int MaxHealth { get; protected set; } = 70;
        protected override int Health { get; set; }
        public override int Damage { get; set; } = 20;

        public Skeleton() {
            Health = MaxHealth;
        }

        public override void AttackPlayer(Player Player) {
            var Rand = new Random();
            var Chance = Rand.Next(0, 100);
            if (Chance >= 95) {
                Heal(Player.Damage);
                Console.WriteLine("Your attack missed!");
            } else {
                Attack(Player);
            }
            Console.WriteLine($"The {Name} attacked you!\nYou lost {Damage}HP.");
        }
    }

     public class Demon : Enemy {
        public override string Name { get; } = "demon";
        public override int MaxHealth { get; protected set; } = 60;
        protected override int Health { get; set; }
        public override int Damage { get; set; } = 15;

        public Demon() {
            Health = MaxHealth;
        }

        public override void AttackPlayer(Player Player) {
            var Rand = new Random();
            var Chance = Rand.Next(0, 100);
            if (Chance >= 90) {
                Damage = Damage * 2;
                Attack(Player);
                Console.WriteLine($"The {Name} got critical hit!\nYou lost {Damage}HP.");
                Damage = Damage / 2;
            } else {
                Attack(Player);
            }
            Console.WriteLine($"The {Name} attacked you!\nYou lost {Damage}HP.");
        }
     }

    public abstract class Factory {
        public abstract Enemy FactoryMethod();
    }

    public class SpiderFactory : Factory {
        public override Enemy FactoryMethod() {
            return new Spider();
        }
    }

    public class SkeletonFactory : Factory {
        public override Enemy FactoryMethod() {
            return new Skeleton();
        }
    }

    public class DemonFactory : Factory {
        public override Enemy FactoryMethod() {
            return new Demon();
        }
    }
}