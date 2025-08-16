using System;
using UnityEngine;

namespace AegisWard.Scripts.Abilities.Model
{
    [CreateAssetMenu(fileName = "New Ability Context", menuName = "Ability Context")]
    public class AbilityContext : ScriptableObject
    {
        public string abilityName;
        
        public GameObject prefab;
        public Sprite sprite;
        public float damage;
        public float manaCost;
        public Transform playerTransform;
        public float cooldown;
        public float duration;
    }
}