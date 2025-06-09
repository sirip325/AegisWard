using UniRx;
using UnityEngine;

namespace AegisWard.Scripts.Player.Model
{
    public class PlayerStats : MonoBehaviour
    {
        public ReactiveProperty<float> maxMana,currentMana;

        public void Init()
        {
            currentMana.Value = maxMana.Value;
        }
    }
}
