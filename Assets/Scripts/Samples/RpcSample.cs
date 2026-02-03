using Unity.Netcode;
using UnityEngine;

namespace Samples
{
    public class RpcSample :NetworkBehaviour
    {
        private int _pingCount; 
        
        [Rpc(SendTo.Server)]
        public void PingRpc(int pingCount)
        {
            print($"PING: {_pingCount}");
            PongRpc(pingCount,"PONG!");
        }

        [Rpc(SendTo.NotServer)]
        private void PongRpc(int pingCount, string message)
        {
            print($"Received pong from server for ping {pingCount} and message: {message}"); 
        }

        private void Update()
        {
            if (IsClient && Input.GetKeyDown(KeyCode.P))
            {
                PingRpc(_pingCount);
                _pingCount++;
            }
        }
    }
}