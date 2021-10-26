using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNode : MonoBehaviour
{
    public int nodeId;
    public NodeInformation.Node node;
    public List<TargetNode> walkableNodes = new List<TargetNode>();
    public EventObject.NodeEvent nodeEvent { get; private set; }


    public void OnMouseDown()
    {
        if (!NodeManager.instance.IsNodeValid(this))
            return;

        NodeManager.instance.MoveToThisNode(this);
        nodeEvent = NodeManager.instance.nodeInfo.FindNode(nodeId).GetRandomEvent();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Player.instance.canMove = false;
            Player.instance.agent.isStopped = true;
        }
        else
            return;

        UIManager.instance.OpenMenu(UIManager.menuType.NodeMenu);
    }
}