using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNode : MonoBehaviour
{
    public int nodeId;
    public NodeInformation.Node node;
    public EventObject.NodeEvent nodeEvent { get; private set; }

    public void OnMouseDown()
    {
        if(Player.instance.canMove == true)
            Player.instance?.MovePlayer(this);

        UIManager.instance.currentNode = this;
        nodeEvent = UIManager.instance.nodeInfo.FindNode(nodeId).GetRandomEvent();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
            Player.instance.canMove = false;

        UIManager.instance.OpenMenu(UIManager.menuType.NodeMenu);
    }
}