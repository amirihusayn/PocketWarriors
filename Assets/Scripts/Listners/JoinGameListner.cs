using UnityEngine;
using UnityEngine.UI;

public class JoinGameListner : ListnerPrototype
{
    // Fields
    [SerializeField] private CustomNetworkDiscovery networkDiscovery;
    [SerializeField] private string fromAddress, data;

    // Methods
    protected override void OnClickListner()
    {
        /// StartClient()
    }

    public void CreateHostInfo(CustomNetworkDiscovery networkDiscovery, string fromAddress, string data)
    {
        this.networkDiscovery = networkDiscovery;
        this.fromAddress = fromAddress;
        this.data = data;
        networkDiscovery.OnReceivedBroadcast(fromAddress , data);
    }
}
