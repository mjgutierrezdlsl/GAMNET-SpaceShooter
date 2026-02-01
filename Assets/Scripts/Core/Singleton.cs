using Unity.Netcode;
using UnityEngine;

namespace Core
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }
        [SerializeField] private bool isPersistent;

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            } 
        
            Instance = this as T;
        }
    }

    public abstract class NetworkSingleton<T> :  NetworkBehaviour where T : NetworkBehaviour
    {
        public static T Instance { get; private set; }
        [SerializeField] private bool isPersistent;

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            } 
        
            Instance = this as T;
        }
    }
}
