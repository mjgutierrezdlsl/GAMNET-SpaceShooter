using System;
using UnityEngine;

namespace Core
{
    public abstract class VariableReference<T> : ScriptableObject
    {
        [SerializeField] private T _value;
        public T Value
        {
            get => _value;
            set
            {
                var prev = _value;
                _value = value;
                OnValueChanged?.Invoke(prev, _value);
            }
        }
        public event Action<T, T> OnValueChanged;
    }
}