using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace PocketWarriors
{
    public class JoinGameListner : ListnerPrototype
    {
        // Fields________________________________________________________
        [SerializeField] private CustomNetworkDiscovery networkDiscovery;
        [SerializeField] private string fromAddress, data;

        // Methods_____________________________________________________
        protected override void OnClickListner()
        {
            CustomNetworkManager.singleton.networkAddress = fromAddress;
            CustomNetworkManager.singleton.StartClient();
        }

        public void CreateHostInfo(CustomNetworkDiscovery networkDiscovery, string fromAddress, string data)
        {
            this.networkDiscovery = networkDiscovery;
            this.fromAddress = fromAddress;
            this.data = data;
            networkDiscovery.OnReceivedBroadcast(fromAddress , data);
        }
    }
}
