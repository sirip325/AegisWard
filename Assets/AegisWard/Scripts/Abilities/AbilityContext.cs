using UnityEngine;

namespace AegisWard.Scripts.Abilities
{
    public class AbilityContext
    {
        public GameObject Caster { get; set; }
        public GameObject Target { get; set; }
        
        public Vector3 TargetPosition { get; set; }
        
        public float ManaCost { get; set; }
        public float Damage { get; set; }
        public float Duration { get; set; }

        public AbilityContext(GameObject caster,
                              GameObject target,
                              Vector3 targetPosition,
                              float damage,
                              float duration,
                              float manaCost)
        {
            Caster = caster;
            Target = target;
            TargetPosition = targetPosition;
            Damage = damage;
            Duration = duration;
            ManaCost = manaCost;
        }
    }
}