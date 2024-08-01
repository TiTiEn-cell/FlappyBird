using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    //Public variables
    //Private variables
    [SerializeField] private GameObject prefabsSpawn;
    [SerializeField] private float timeSpawn;
    [SerializeField] private float spawnHeight;

    private Vector3 spawnPosition;
    private float timer;
    //Protected variables

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeSpawn)
        {
            timer = 0;
            SpawnPipe();
        }
        
    }

    void SpawnPipe()
    {
        spawnPosition = new Vector3(transform.position.x, Random.Range(-spawnHeight, spawnHeight), transform.position.z); ;
        GameObject pipe = Instantiate(prefabsSpawn, spawnPosition, Quaternion.identity);

        Destroy(pipe, 10f);
    }
}
