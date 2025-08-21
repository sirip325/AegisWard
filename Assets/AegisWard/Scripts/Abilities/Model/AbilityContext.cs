using System;
using UnityEngine;

namespace AegisWard.Scripts.Abilities.Model
{
    [CreateAssetMenu(fileName = "New Ability Context", menuName = "Ability Context")]
    public class AbilityContext : ScriptableObject
    {
        public string abilityName;
        
        public GameObject prefab;
        public float damage;
        public float manaCost;
        public float cooldown;
        public float duration;
        public Sprite icon;
    }
}