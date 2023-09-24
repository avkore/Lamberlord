using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    [SerializeField] private  GameObject treePrefab;
    [SerializeField] private  int numberOfTrees = 100;
    [SerializeField] private  float terrainWidth = 100f;
    [SerializeField] private  float terrainLength = 100f;

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