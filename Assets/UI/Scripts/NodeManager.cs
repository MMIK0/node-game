using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    public static NodeManager instance;
    public TargetNode currentNode;
    public NodeInformation nodeInfo;
    public TargetNode startingNode;
    [Header("Rarity Info")]
    public ItemInformation.Item currentItem;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Debug.Log("Killing Duplicate Manager");
            Destroy(gameObject);
            return;
        }
        Debug.Log(instance);

        currentNode = startingNode;
    }

    public void MoveToThisNode(TargetNode node)
    {
        Player.instance?.MovePlayer(node);
        currentNode = node;
        //UIManager.instance.currentNode = node;
    }

    public string GetEventText()
    {
        TargetNode node = currentNode;
        if (node.nodeEvent.eventAction.action.eventText != null)
            return null;

        return node.nodeEvent.eventAction.action.eventText;
    }

    public string GetNodeText()
    {
        NodeInformation.Node node = nodeInfo.FindNode(currentNode.nodeId);
        if (currentNode.nodeId != 0)
            return node.text;
        else
            return null;
    }

    public Sprite GetNodeImage()
    {
        NodeInformation.Node node = nodeInfo.FindNode(currentNode.nodeId);
        if (currentNode.nodeId != 0)
            return node.image;
        else
            return null;
    }

    public void TurnCurrentNodeOff()
    {
        currentNode.GetComponent<CapsuleCollider>().enabled = false;
    }

    public bool IsNodeValid(TargetNode node)
    {
        if (currentNode.walkableNodes.Contains(node))
            return true;

        return false;
    }
}
