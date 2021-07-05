using UnityEngine;

public class CancelHostListner : ListnerPrototype
{
    // Fields
    [SerializeField] private CustomNetworkDiscovery networkDiscovery;

    // Methods
    protected override void OnClickListner()
    {
        networkDiscovery.ListenBradcasts();
    }
}
