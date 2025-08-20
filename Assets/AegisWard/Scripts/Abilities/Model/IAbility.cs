using UniRx;
using UnityEngine;

namespace AegisWard.Scripts.Abilities.Model
{
    
    public interface IAbility
    {
        float manaCost { get; set; }
        float damage { get; set; }
        float duration { get; set; }
        GameObject prefab { get; set; }
        Transform playerTransform { get; set; }
        float cooldown { get; set; }
        ReactiveProperty<float> timer { get; set; }
        
        void Execute();
    }
}
