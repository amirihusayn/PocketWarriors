using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinGame : MonoBehaviour
{
    [SerializeField] private Button joinButton;

    public void AddRelatedHostListner(CustomNetworkDiscovery netDiscovery , string fromAddress , string data)
    {
        joinButton.onClick.AddListener(delegate { 
            netDiscovery.OnReceivedBroadcast(fromAddress , data); 
            /// then StartClient()
            });
    }
    public void RemoveListners()
    {
        joinButton.onClick.RemoveAllListeners();
    }
}
