using UnityEngine;
using UnityEngine.UI;

namespace PocketWarriors
{
    public class HostGameListner : ListnerPrototype
    {
        // Fields________________________________________________________
        [SerializeField] private Text hostName;
        [SerializeField] private CustomNetworkDiscovery networkDiscovery;
        
        // Methods_____________________________________________________
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
}
