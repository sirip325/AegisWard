using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth_UI : MonoBehaviour
{
    public Transform pivot;
    public GameObject healthBar;

    private void Update()
    {
        if(pivot !=null && Camera.main != null)
            pivot.LookAt(Camera.main.transform);
    }

    public void SetHealth(GameObject bar,float value, float maxValue)
    {
        var image = bar.GetComponentsInChildren<Image>().First(x => x.type == Image.Type.Filled);
        image.fillAmount = value / maxValue;
    }
}
