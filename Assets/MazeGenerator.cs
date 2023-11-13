using System.Collections;
using System.Collections.Generic;
using System.Linq; // Add this using directive
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] MazeNode nodePrefab;
    [SerializeField] GameObject playerObjectPrefab; // Add your PlayerObject prefab here
    [SerializeField] Vector2Int mazeSize;
    [SerializeField] float nodeSize;

    private void Start()
    {
        GenerateMazeInstant(mazeSize);
        SpawnPlayerObject(); // Call the new method to spawn the PlayerObject
        //StartCoroutine(GenerateMaze(mazeSize));
    }

    void GenerateMazeInstant(Vector2Int size)
    {
        List<MazeNode> nodes = new List<MazeNode>();

        // Create nodes
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3 nodePos = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f));
                MazeNode newNode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                nodes.Add(newNode);
            }
        }

        // Add a random opening in the outer border
        int openingSide = Random.Range(1, 5); // Randomly choose a side (1: right, 2: left, 3: top, 4: bottom)

        switch (openingSide)
        {
            case 1:
                // Right side
                int openingY = Random.Range(0, size.y);
                nodes[openingY].RemoveWall(1);
                break;
            case 2:
                // Left side
                openingY = Random.Range(0, size.y);
                nodes[(size.x - 1) * size.y + openingY].RemoveWall(0);
                break;
            case 3:
                // Top side
                int openingX = Random.Range(0, size.x);
                nodes[openingX * size.y].RemoveWall(3);
                break;
            case 4:
                // Bottom side
                openingX = Random.Range(0, size.x);
                nodes[(openingX + 1) * size.y - 1].RemoveWall(2);
                break;
        }

        List<MazeNode> currentPath = new List<MazeNode>();
        List<MazeNode> completedNodes = new List<MazeNode>();

        // Choose starting node
        currentPath.Add(nodes[Random.Range(0, nodes.Count)]);
        currentPath[0].SetState(NodeState.Current);

        while (completedNodes.Count < nodes.Count)
        {
            // Check nodes next to the current node
            List<int> possibleNextNodes = new List<int>();
            List<int> possibleDirections = new List<int>();

            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;

            if (currentNodeX < size.x - 1)
            {
                // Check node to the right of the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex + size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + size.y]))
                {
                    possibleDirections.Add(1);
                    possibleNextNodes.Add(currentNodeIndex + size.y);
                }
            }
            if (currentNodeX > 0)
            {
                // Check node to the left of the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex - size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - size.y]))
                {
                    possibleDirections.Add(2);
                    possibleNextNodes.Add(currentNodeIndex - size.y);
                }
            }
            if (currentNodeY < size.y - 1)
            {
                // Check node above the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex + 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + 1]))
                {
                    possibleDirections.Add(3);
                    possibleNextNodes.Add(currentNodeIndex + 1);
                }
            }
            if (currentNodeY > 0)
            {
                // Check node below the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex - 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - 1]))
                {
                    possibleDirections.Add(4);
                    possibleNextNodes.Add(currentNodeIndex - 1);
                }
            }

            // Choose next node
            if (possibleDirections.Count > 0)
            {
                int chosenDirection = Random.Range(0, possibleDirections.Count);
                MazeNode chosenNode = nodes[possibleNextNodes[chosenDirection]];

                switch (possibleDirections[chosenDirection])
                {
                    case 1:
                        chosenNode.RemoveWall(1);
                        currentPath[currentPath.Count - 1].RemoveWall(0);
                        break;
                    case 2:
                        chosenNode.RemoveWall(0);
                        currentPath[currentPath.Count - 1].RemoveWall(1);
                        break;
                    case 3:
                        chosenNode.RemoveWall(3);
                        currentPath[currentPath.Count - 1].RemoveWall(2);
                        break;
                    case 4:
                        chosenNode.RemoveWall(2);
                        currentPath[currentPath.Count - 1].RemoveWall(3);
                        break;
                }

                currentPath.Add(chosenNode);
                chosenNode.SetState(NodeState.Current);
            }
            else
            {
                completedNodes.Add(currentPath[currentPath.Count - 1]);

                currentPath[currentPath.Count - 1].SetState(NodeState.Completed);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }

     void SpawnPlayerObject()
    {
        // Instantiate the PlayerObject prefab at a random position within the maze
        Vector3 playerObjectPosition = GetRandomMazePosition();
        Instantiate(playerObjectPrefab, playerObjectPosition, Quaternion.identity);
    }

     Vector3 GetRandomMazePosition()
    {
        MazeNode[] allNodes = transform.GetComponentsInChildren<MazeNode>();
        List<MazeNode> openNodes = new List<MazeNode>();

        foreach (var node in allNodes)
        {
            if (!node.HasAnyWall())
            {
                openNodes.Add(node);
            }
        }

        if (openNodes.Count > 0)
        {
            MazeNode randomNode = openNodes[Random.Range(0, openNodes.Count)];
            return randomNode.transform.position;
        }
        else
        {
            Debug.LogError("No open nodes found for object spawn!");
            return Vector3.zero;
        }
    }
}
