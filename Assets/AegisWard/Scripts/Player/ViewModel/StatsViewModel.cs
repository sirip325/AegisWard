using UnityEngine;
using VContainer;

public class StatsViewModel
{
    private StatsUI _statsUI;

    [Inject]
    public StatsViewModel(StatsUI statsUI)
    {
        _statsUI = statsUI;
    }
}
