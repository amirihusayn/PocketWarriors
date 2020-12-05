using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public struct Host 
{
    public string hostName;
    public string ipAddress;
    public int portNumber;
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
    private float timeOut;
    private Dictionary<Host,float> availableHosts;
    private MatchInfoUpdate matchInfoUpdator;

    private void Awake()
    {
        timeOut = 3f;
        matchInfoUpdator = GetComponent<MatchInfoUpdate>();
        availableHosts = new Dictionary<Host, float>();
        base.Initialize();
        StartCoroutine("RefereshAvailableHosts");
    }
    private IEnumerator RefereshAvailableHosts()
    {
        while(true)
        {
            foreach(Host thisHost in availableHosts.Keys)
                if(availableHosts[thisHost] <= Time.time)
                {
                    matchInfoUpdator.RemoveTimeOutedMatch(thisHost);
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
        Host newHost = new Host(fromAddress , NetworkManager.singleton.networkPort , data);
        if(availableHosts.ContainsKey(newHost))
            availableHosts[newHost] = Time.time + timeOut;
        else
        {
            availableHosts.Add(newHost , Time.time + timeOut);
            matchInfoUpdator.AddNewMatch(newHost , this , fromAddress , data);
        }
    }
}
