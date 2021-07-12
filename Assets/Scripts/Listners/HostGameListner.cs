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
        networkDiscovery.broadcastData = GetBroadcastData();
        networkDiscovery.StartBroadCast();
        CustomNetworkManager.singleton.StartHost();
    }

    private string GetBroadcastData()
    {
        if(hostName.text.ToString() != string.Empty)
            return hostName.text.ToString();
        else
            return "NoName Host !";
    }
}
