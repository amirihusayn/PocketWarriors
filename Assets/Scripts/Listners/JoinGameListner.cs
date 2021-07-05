using UnityEngine;
using UnityEngine.UI;

public class JoinGameListner : ListnerPrototype
{
    // Fields
    [SerializeField] private CustomNetworkDiscovery networkDiscovery;
    [SerializeField] private string fromAddress, data;

    // Methods
    protected override void Awake()
    {
        button = GetComponent<Button>();
    }

    protected override void OnClickListner()
    {
        networkDiscovery.OnReceivedBroadcast(fromAddress , data); 
        /// then StartClient()
    }

    public void AddRelatedHostListner(CustomNetworkDiscovery networkDiscovery, string fromAddress, string data)
    {
        this.networkDiscovery = networkDiscovery;
        this.fromAddress = fromAddress;
        this.data = data;
        OnClickListner();
        // button.onClick.AddListener(delegate { OnClickListner();} );
    }

    public void RemoveListners()
    {
        button.onClick.RemoveAllListeners();
    }
}
