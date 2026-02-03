using Core;
using UnityEngine;

namespace Samples
{
    public class VariableReferenceSample : MonoBehaviour
    {
        [SerializeField] VariableReference<int> intVariable;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                intVariable.Value++;
            }
        }
    }
}