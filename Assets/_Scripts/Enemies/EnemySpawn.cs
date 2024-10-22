using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private int x;
    private int y;
    private int z;
    
    
    void SpawnEnemy(GameObject enemy)
    {
        x = Random.Range(-3, 4);
        z = Random.Range(-3, 4);
        Instantiate(enemy, new Vector3(x,0,z), Quaternion.identity);
    }
}
