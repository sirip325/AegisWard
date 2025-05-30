namespace AegisWard.Scripts.Abilities.Model
{
    
    public interface IAbility
    {
        float manaCost { get; set; }
        float damage { get; set; }
        float duration { get; set; }
        
        void Execute();
    }
}
