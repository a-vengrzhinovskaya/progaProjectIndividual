namespace progaProjectIndividual {
    public interface IPlayer: ICharacter {
        protected Skill Ability { get; set; }

        protected void useAbility();
    }
}
