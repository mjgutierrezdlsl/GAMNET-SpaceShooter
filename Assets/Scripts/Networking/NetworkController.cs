using Unity.Netcode;
using UnityEngine;

public class NetworkController : MonoBehaviour
{
    private bool _isInitialized = false;
    // Update is called once per frame
    void Update()
    {
        if (_isInitialized) return;
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("Starting Host...");
            NetworkManager.Singleton.StartHost();
            _isInitialized = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("Starting Client...");
            NetworkManager.Singleton.StartClient();
            _isInitialized = true;
        }
    }
}
