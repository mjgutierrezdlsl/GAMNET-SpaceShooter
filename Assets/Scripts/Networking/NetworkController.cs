using Unity.Netcode;
using UnityEngine;

public class NetworkController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("Starting Host...");
            NetworkManager.Singleton.StartHost();
            print("Started Host");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("Starting Client...");
            NetworkManager.Singleton.StartClient();
            print("Started Client");
        }
    }
}
