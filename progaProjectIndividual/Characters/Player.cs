using progaProjectIndividual.Characters;

namespace progaProjectIndividual {
    public abstract class Player: Character {
        public bool AbilityUsed { get; set; } = false;

        public abstract void UseAbility(Player Player, Enemy Enemy, Caretaker Caretaker);
    }
}