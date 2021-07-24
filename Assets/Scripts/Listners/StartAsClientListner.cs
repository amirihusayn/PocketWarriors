using UnityEngine;
using UnityEngine.UI;

namespace PocketWarriors
{
    public class StartAsClientListner : ListnerPrototype
    {
        // Fields________________________________________________________
        [SerializeField] private CustomNetworkDiscovery networkDiscovery;

        // Methods_____________________________________________________
        protected override void OnClickListner()
        {
            networkDiscovery.ListenBradcasts();
        }
    }
}
