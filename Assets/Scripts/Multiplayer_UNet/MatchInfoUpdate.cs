using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchInfoUpdate : singleton<MatchInfoUpdate>
{
    // Fields
    [SerializeField] private GameObject match;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject scrollView;
    private Dictionary<Host,GameObject> matchDic;
    private Stack<GameObject> disabledMatcheList;

    // Properties
    public Dictionary<Host, GameObject> MatchDic { get => matchDic; set => matchDic = value; }

    // Methods
    protected override void Awake()
    {
        base.Awake();
        matchDic = new Dictionary<Host, GameObject>();
        disabledMatcheList = new Stack<GameObject>();
        SetScrollViewActivation();
    }

    public void AddNewMatch(Host host , CustomNetworkDiscovery netDiscovery , string formAddress , string data)
    {
        GameObject newMatch;
        if(disabledMatcheList.Count == 0)
            newMatch = Instantiate(match , Vector3.zero , Quaternion.identity , panel.GetComponent<RectTransform>());  
        else
            newMatch = disabledMatcheList.Pop();
        newMatch.GetComponentInChildren<Text>().text = host.hostName;
        newMatch.GetComponentInChildren<JoinGameListner>().CreateHostInfo(netDiscovery , formAddress , data);
        newMatch.SetActive(true);
        matchDic.Add(host , match);
        SetScrollViewActivation();
    }

    public void RemoveTimeOutedMatch(Host Host)
    {
        GameObject targetMatch = matchDic[Host];
        targetMatch.SetActive(false);
        disabledMatcheList.Push(targetMatch);
        matchDic.Remove(Host);
        SetScrollViewActivation();
    }

    private void SetScrollViewActivation()
    {
        if(matchDic.Count > 0)
            scrollView.SetActive(true);
        else
            scrollView.SetActive(false);
    }
}
