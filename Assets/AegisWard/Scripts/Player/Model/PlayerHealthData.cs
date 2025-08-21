using UnityEngine;

public class PlayerHealthData
{
    
    public Health _health;

    public PlayerHealthData(float maxHP)
    {
        _health = new Health(maxHP);
    }
}
