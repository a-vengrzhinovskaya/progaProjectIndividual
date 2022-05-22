namespace progaProjectIndividual {
    public abstract class Character {
        public abstract int MaxHealth { get; }
        protected abstract int Health { get; set; }
        public abstract int Damage { get; set; }

        public void Attack(Character target) {
            target.Health -= Damage;
        }

        public void getDamage(Character attacker) {
            Health -= attacker.Damage;
        }

        public void Heal(int amount) {
            Health += amount;
        }

        public int GetHP() {
            return Health;
        }
    }
}