using AegisWard.Scripts.Abilities.Model;
using AegisWard.Scripts.Player.Model;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        //Other services
        builder.RegisterComponentInHierarchy<PlayerStats>();
        builder.RegisterComponentInHierarchy<StatsUI>();
        builder.Register<StatsViewModel>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<AbilityCaster>();
        
        
        builder.RegisterEntryPoint<GameEntryPoint>();
    }
}
