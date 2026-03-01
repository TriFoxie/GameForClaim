using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject deer;
    public GameObject car;
    
    public void SpawnObstacle(string obstacleName)
    {
        Debug.Log("Spawning obstacle: " + obstacleName);
        
        int spawnX = Random.Range(-40, 40);
        int spawnY = Random.Range(-40, 40);

        GameObject spawnObject;
        
        switch (obstacleName.ToLower())
        {
            case "deer": spawnObject = deer; break;
            case "car": spawnObject = car; break;
            default : spawnObject = new GameObject();
                Debug.Log("Invalid obstacle name.");
                break;
        }
        Instantiate(spawnObject, new Vector3(spawnX, 0, spawnY), Quaternion.identity);
    }
}
