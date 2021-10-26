using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "NodeSpecs")]
public class NodeInformation : ScriptableObject
{
    [System.Serializable]
    public class Node
    {
        public int id;
        public string text;
        public Sprite image;
        public EventObject eventObj;
        public EventObject specialEventObj;
        public float eventChance;

        public EventObject.NodeEvent GetRandomEvent()
        {
            bool doRandomEvent = (eventChance > Random.Range(0, 100));

            if(doRandomEvent != true || specialEventObj == null)
                return eventObj.eventList[Random.Range(0, eventObj.eventList.Count)];

            return specialEventObj.eventList[Random.Range(0, specialEventObj.eventList.Count)];
        }
    }

    public List<Node> nodes = new List<Node>();

    public Node FindNode(int i)
    {
        foreach(Node node in nodes)
        {
            if (node.id == i)
            {
                return node;
            }
        }
        return null;
    }
}
