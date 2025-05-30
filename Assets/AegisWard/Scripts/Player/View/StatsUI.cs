using System;
using UnityEngine;
using UnityEngine.UIElements;

public class StatsUI : MonoBehaviour
{
    private VisualElement root;
    private ProgressBar _progressBar;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }
    
    private void Start()
    {
        _progressBar = root.Q<ProgressBar>("ManaBar");
    }

    private void Update()
    {
        TestBar();
    }
    public void TestBar()
    {
        if (_progressBar != null)
        {
            _progressBar.value = Mathf.Clamp(_progressBar.value + Time.deltaTime, 0, 100);
        }
    }
}
