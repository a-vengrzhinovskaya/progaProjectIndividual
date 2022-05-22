namespace progaProjectIndividual {
    public abstract class Character {
        protected abstract int Health { get; set; }
        protected abstract int Damage { get; set; }

        public void Attack(Character target) {
            target.Health -= Damage;
        }

        public void getDamage(Character attacker) {
            Health -= attacker.Damage;
        }

        public void Heal(int amount) {
            Health += amount;
        }
    }
}