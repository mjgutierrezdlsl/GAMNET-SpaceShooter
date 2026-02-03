using System;
using Unity.Netcode;
using UnityEngine;

public class PlanetListener : NetworkBehaviour
{
    private PlanetController _pc;
    private void Awake()
    {
        _pc = GetComponent<PlanetController>();
    }

    private void Start()
    {
        _pc.CurrentHealth.OnValueChanged += OnHealthChanged;
    }
    private void OnDestroy()
    {

        _pc.CurrentHealth.OnValueChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int previousValue, int newValue)
    {
        print($"Planet Health: {newValue}");
    }
}
