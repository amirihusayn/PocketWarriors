using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HostGame : MonoBehaviour
{
    [SerializeField] private Button hostGameButton;
    [SerializeField] private Text hostName;
    [SerializeField] private Button cancelButton;
    [SerializeField] private CustomNetworkDiscovery networkDiscovery;
        
    private void OnEnable() 
    {
        hostGameButton.onClick.AddListener(delegate { 
            networkDiscovery.broadcastData = hostName.text.ToString();
            networkDiscovery.StartBroadCast(); });
        cancelButton.onClick.AddListener(delegate { networkDiscovery.ListenBradcasts(); });
    }
    private void OnDisable() 
    {
        hostGameButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();  
    }
}
