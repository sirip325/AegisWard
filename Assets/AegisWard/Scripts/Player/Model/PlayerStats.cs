using UnityEngine;

namespace AegisWard.Scripts.Player.Model
{
    public class PlayerStats : MonoBehaviour
    {
        public float maxMana,currentMana;

        public void Init()
        {
            currentMana = maxMana;
        }
    }
}
