using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState
{
    Available,
    Current,
    Completed
}

public class MazeNode : MonoBehaviour
{
    [SerializeField] GameObject[] walls;
    [SerializeField] MeshRenderer floor;

    public void RemoveWall(int wallToRemove)
    {
        walls[wallToRemove].gameObject.SetActive(false);
    }

     // Add a method to check if the node has any walls
     public bool HasAnyWall()
    {
        foreach (var wall in walls)
        {
            if (wall.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    public void SetState(NodeState state)
    {
        switch (state)
        {
            case NodeState.Available:
                print("No need.");
                //floor.material.color = Color.white;
                break;
            case NodeState.Current:
                print("No need.");
                //floor.material.color = Color.yellow;
                break;
            case NodeState.Completed:
                print("No need.");
                //floor.material.color = Color.blue;
                break;
        }
    }
}
