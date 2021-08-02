using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace PocketWarriors
{
    public struct Host 
    {
        // Fields________________________________________________________
        public string hostName;
        public string ipAddress;
        public int portNumber;

        // Constructor_________________________________________________
        public Host(string fromAddress , int portNumber , string hostName)
        {
            this.hostName = hostName;
            string [] segments = fromAddress.Split(':');
            this.ipAddress = segments[3];
            this.portNumber = portNumber;
        }
    }

    public class CustomNetworkDiscovery : NetworkDiscovery
    {
        // Fields________________________________________________________
        private float timeOut;
        private Dictionary<Host, float> availableHosts;

        // Methods_____________________________________________________
        private void Awake()
        {
            timeOut = 3f;
            availableHosts = new Dictionary<Host, float>();
            DontDestroyOnLoad(gameObject);
        }

        private IEnumerator RefereshAvailableHosts()
        {
            List<Host> hosts;
            while (true)
            {
                hosts = availableHosts.Keys.ToList<Host>();
                foreach (Host thisHost in hosts)
                    if (availableHosts[thisHost] <= Time.time)
                    {
                        MatchInfoUpdate.Instance.RemoveTimeOutedMatch(thisHost);
                        availableHosts.Remove(thisHost);
                    }
                yield return new WaitForSeconds(timeOut);
            }
        }

        public void ListenBradcasts()
        {
            // StopBroadcast();
            base.Initialize();
            base.StartAsClient();
            StopAllCoroutines();
            StartCoroutine("RefereshAvailableHosts");
        }

        public void StartBroadCast()
        {
            // StopBroadcast();
            base.Initialize();
            base.StartAsServer();
        }

        public override void OnReceivedBroadcast(string fromAddress, string data)
        {
            base.OnReceivedBroadcast(fromAddress, data);
            CreateHost(fromAddress, data);
        }

        private void CreateHost(string fromAddress, string data)
        {
            Host newHost = new Host(fromAddress, NetworkManager.singleton.networkPort, data);
            if (availableHosts.ContainsKey(newHost))
                availableHosts[newHost] = Time.time + timeOut;
            else
            {
                availableHosts.Add(newHost, Time.time + timeOut);
                MatchInfoUpdate.Instance.AddNewMatch(newHost, this, fromAddress, data);
            }
        }
    }
}
