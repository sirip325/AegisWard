using AegisWard.Scripts.Player.Model;
using UnityEngine;
using VContainer;

namespace AegisWard.Scripts.Abilities.Model
{
    public class ManaChecker : CastChecker
    {
        private PlayerStats _playerStats;
        
        [Inject]
        public ManaChecker(PlayerStats playerStats)
        {
            _playerStats = playerStats;
        }
        public override bool Check(IAbility ability)
        {
            if (ability.manaCost <= _playerStats.currentMana && _nextChecker != null)
            {
                Debug.Log("Will be used the next checker");
                return _nextChecker.Check(ability);
                
            }
            else if (ability.manaCost <= _playerStats.currentMana && _nextChecker == null)
            {
                Debug.Log("It is last checker");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
