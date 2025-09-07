using AegisWard.Scripts.Player.Model;
using UnityEngine;
using VContainer;

namespace AegisWard.Scripts.Abilities.Model
{
    public class FireBallAbility : Ability
    {
        public override void Execute()
        { 
            base.Execute();
            
            var obj = Object.Instantiate(prefab, playerTransform.position + playerTransform.forward, playerTransform.rotation);
            obj.GetComponent<FireBallObj>().SetDamage(damage);
            Rigidbody rb = obj.AddComponent<Rigidbody>().GetComponent<Rigidbody>();
            

            playerStats.currentMana.Value -= manaCost;
            
            rb.linearVelocity = Camera.main.transform.forward * 50f;
            
        }
    }
}
