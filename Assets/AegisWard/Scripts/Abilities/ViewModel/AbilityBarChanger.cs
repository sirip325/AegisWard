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
            SetSlotIcon(index,caster.Abilities[i].icon);
        }
    }

    private void SetSlotCooldown(int index,float cooldown)
    {
        abilityBarUI.SetSlotCooldown(index,cooldown);
    }

    private void SetSlotIcon(int index, Sprite icon)
    {
        abilityBarUI.SetSlotIcon(index,icon);
    }
}
