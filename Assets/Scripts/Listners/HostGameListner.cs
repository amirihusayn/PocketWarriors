using UnityEngine;
using UnityEngine.UI;

public class HostGameListner : ListnerPrototype
{
    // Fields
    [SerializeField] private Text hostName;
    [SerializeField] private CustomNetworkDiscovery networkDiscovery;
    
    // Methods
    protected override void OnClickListner()
    {
        networkDiscovery.broadcastData = hostName.text.ToString();
        networkDiscovery.StartBroadCast();
        CustomNetworkManager.singleton.StartHost();
    }
}
