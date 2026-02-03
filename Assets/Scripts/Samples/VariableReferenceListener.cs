using UnityEngine;
using Core;
using System;

namespace Samples
{
    public class VariableReferenceListener : MonoBehaviour
    {
        [SerializeField] VariableReference<int> _intReference;

        private void Awake()
        {
            _intReference.OnValueChanged += OnIntValueChanged;
        }
        private void OnDestroy()
        {

            _intReference.OnValueChanged -= OnIntValueChanged;
        }
        private void Update()
        {
            print(_intReference.Value);
        }

        private void OnIntValueChanged(int prev, int current)
        {
            print($"Prev: {prev} | Current: {current}");
        }
    }
}