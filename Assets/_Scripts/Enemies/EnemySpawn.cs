using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private int x;
    private int z;
    
    
    public void SpawnEnemy(GameObject enemy)
    {
        x = Random.Range(-3, 4);
        z = Random.Range(-3, 4);
        Instantiate(enemy, transform.position + new Vector3(x, 0, z), Quaternion.identity);
    }
}
