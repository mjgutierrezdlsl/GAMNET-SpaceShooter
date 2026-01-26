using Unity.Netcode;
using UnityEngine;

public class NetworkController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("Starting host...");
            NetworkManager.Singleton.StartHost();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("Starting client...");
            NetworkManager.Singleton.StartClient();
        }
    }
}
