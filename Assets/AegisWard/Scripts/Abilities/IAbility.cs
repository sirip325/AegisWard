using UnityEngine;

namespace AegisWard.Scripts.Abilities
{
    public interface IAbility
    {
        void Execute(AbilityContext context);
    }
}
