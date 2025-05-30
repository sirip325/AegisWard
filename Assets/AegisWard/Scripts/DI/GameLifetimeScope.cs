using AegisWard.Scripts.Player.Model;
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
        
        builder.RegisterEntryPoint<GameEntryPoint>();
    }
}
