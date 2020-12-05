using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchInfoUpdate : MonoBehaviour
{
    [SerializeField] private GameObject match;
    [SerializeField] private GameObject panel;
    private Dictionary<Host,GameObject> matchDic;
    private Stack<GameObject> disabledMatcheList;
    public Dictionary<Host, GameObject> MatchDic { get => matchDic; set => matchDic = value; }

    private void Awake()
    {
        matchDic = new Dictionary<Host, GameObject>();
        disabledMatcheList = new Stack<GameObject>();
    }
    public void AddNewMatch(Host host , CustomNetworkDiscovery netDiscovery , string formAddress , string data)
    {
        GameObject newMatch;
        if(disabledMatcheList.Count == 0)
            newMatch = Instantiate(match , Vector3.zero , Quaternion.identity , panel.GetComponent<RectTransform>());  
        else
            newMatch = disabledMatcheList.Pop();
        newMatch.GetComponentInChildren<Text>().text = host.hostName;
        newMatch.GetComponent<JoinGame>().AddRelatedHostListner(netDiscovery , formAddress , data);
        newMatch.SetActive(true);
        matchDic.Add(host , match);
    }
    public void RemoveTimeOutedMatch(Host Host)
    {
        GameObject targetMatch = matchDic[Host];
        targetMatch.SetActive(false);
        targetMatch.GetComponent<JoinGame>().RemoveListners();
        disabledMatcheList.Push(targetMatch);
        matchDic.Remove(Host);
    }
}
