using UnityEngine;
using UniRx;
using VContainer;

public class AbilityBarChanger : MonoBehaviour
{
    [Inject]
    private AbilityCaster caster;
    [Inject]
    private AbilityBarUI abilityBarUI;

    private void Start()
    {
        for(int i = 0; i < caster.Abilities.Count; i++)
        {
            int index = i;
            caster.Abilities[i].timer.Subscribe(value => SetSlotCooldown(index,value)).AddTo(this);
        }
    }

    private void SetSlotCooldown(int index,float cooldown)
    {
        abilityBarUI.SetSlotCooldown(index,cooldown);
    }
}
