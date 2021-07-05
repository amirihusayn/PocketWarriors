using UnityEngine;
using UnityEngine.UI;

public class StartAsClientListner : ListnerPrototype
{
    // Fields
    [SerializeField] private CustomNetworkDiscovery networkDiscovery;

    // Methods
    protected override void OnClickListner()
    {
        networkDiscovery.ListenBradcasts();
    }
}
