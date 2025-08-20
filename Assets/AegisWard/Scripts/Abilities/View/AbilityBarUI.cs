using UnityEngine;
using UnityEngine.UIElements;

public class AbilityBarUI : MonoBehaviour
{
    private AbilitySlot[] abilitySlots = new AbilitySlot[9];

    [SerializeField]private Sprite icon;
    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        for (int i = 0; i < 9; i++)
        {
            var slotRoot = root.Q<VisualElement>($"AbilitySlot{i+1}");
            abilitySlots[i] = new AbilitySlot(slotRoot);
        }
    }

    public void SetSlotIcon(int index, Sprite sprite)
    {
        if(index < 0 || index >= abilitySlots.Length)return;
        abilitySlots[index].SetIcon(sprite);
    }

    public void SetSlotCooldown(int index,float cooldown)
    {
        if(index < 0 || index >= abilitySlots.Length)return;
        abilitySlots[index].SetCooldown(cooldown);
    }
}
