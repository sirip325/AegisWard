using System.Threading;
using System.Threading.Tasks;
using AegisWard.Scripts.Player.Model;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace AegisWard.Scripts.Abilities.Model
{
    public abstract class Ability : IAbility
    {
        public float manaCost { get; set; }
        public float damage { get; set; }
        public float duration { get; set; }
        public GameObject prefab { get; set; }
        public Transform playerTransform { get; set; }
        public float cooldown { get; set; }
        public float timer { get; set; }
        
        public PlayerStats playerStats;

        public void Initialize(AbilityContext abilityContext,PlayerStats playerStats,Transform playerTransform)
        {
            this.manaCost = abilityContext.manaCost;
            this.damage = abilityContext.damage;
            this.duration = abilityContext.duration;
            this.prefab = abilityContext.prefab;
            this.playerStats = playerStats;
            this.cooldown = abilityContext.cooldown;
            this.playerTransform = playerTransform;
        }
        public virtual void Execute()
        {
            timer = cooldown;
            StartCooldown();
        }

        private async UniTaskVoid StartCooldown()
        {
            
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                await UniTask.Yield();
            }
            await UniTask.WaitUntil(() => timer <= 0f);
            timer = 0;
            
        }
    }
}