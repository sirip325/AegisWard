using AegisWard.Scripts.Player.Model;
using UnityEngine;
using VContainer;

namespace AegisWard.Scripts.Abilities.Model
{
    public class FireBall : Ability
    {
        
        
        public override void Execute()
        { 
            base.Execute();
            
            var obj = Object.Instantiate(prefab, playerTransform.position, playerTransform.rotation);
            Rigidbody rb = obj.AddComponent<Rigidbody>().GetComponent<Rigidbody>();

            playerStats.currentMana.Value -= manaCost;
            
            rb.linearVelocity = Camera.main.transform.forward * 100f;
            
        }
    }
}
