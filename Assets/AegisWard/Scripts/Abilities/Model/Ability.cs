namespace AegisWard.Scripts.Abilities.Model
{
    public abstract class Ability : IAbility
    {
        public float manaCost { get; set; }
        public float damage { get; set; }
        public float duration { get; set; }

        public virtual void Execute()
        {
            
        }
    }
}