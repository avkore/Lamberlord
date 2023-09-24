using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject treePrefab;
    public int numberOfTrees = 100;
    public float terrainWidth = 100f;
    public float terrainLength = 100f;

    void Start()
    {
        GenerateTrees();
    }

    void GenerateTrees()
    {
        for (int i = 0; i < numberOfTrees; i++)
        {
            float randomX = Random.Range(0f, terrainWidth);
            float randomZ = Random.Range(0f, terrainLength);
            float terrainY = 0f;

            Vector3 treePosition = new Vector3(randomX, terrainY, randomZ);
            
            Instantiate(treePrefab, treePosition, Quaternion.identity);
        }
    }
}