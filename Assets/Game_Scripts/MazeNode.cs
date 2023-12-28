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
                //floor.material.color = Color.white;
                break;
            case NodeState.Current:
                //floor.material.color = Color.yellow;
                break;
            case NodeState.Completed:
                //floor.material.color = Color.blue;
                break;
        }
    }
}
