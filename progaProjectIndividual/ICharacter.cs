namespace progaProjectIndividual {
    public interface ICharacter {
        protected int Health { get; set; }
        protected int Damage { get; set; }

        public int Attack(ICharacter target) {
            return target.Health - Damage;
        }

        public int getDamage(ICharacter attacker) {
            return Health - attacker.Damage;
        }
    }
}
