using AegisWard.Scripts.Abilities.Model;
using AegisWard.Scripts.Player.Model;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]private Meat meatSO;
    protected override void Configure(IContainerBuilder builder)
    {
        //Other services
        builder.RegisterComponentInHierarchy<PlayerStats>();
        builder.RegisterComponentInHierarchy<StatsUI>();
        builder.Register<StatsViewModel>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<AbilityCaster>();
        builder.RegisterComponentInHierarchy<AbilityBarUI>();
        builder.RegisterComponentInHierarchy<AbilityBarChanger>();
        builder.RegisterComponentInHierarchy<ShopUI>();
        builder.RegisterComponentInHierarchy<PlayerHealth>();
        builder.RegisterInstance(meatSO).As<ItemContext>();
        builder.RegisterComponentInHierarchy<InventoryUI>();
        builder.RegisterComponentInHierarchy<Inventory>();
        
        
        builder.RegisterEntryPoint<GameEntryPoint>();
    }
}
