using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public float speed = 2f;
    //public ArrayList objects;
    public GameObject player;
    public GameObject Projectile1;
    public GameObject Projectile2;
    public GameObject Projectile3;

    public float offset = 15f;

    private int deletionDistance = 11;
    public float spawnTime = 0.5f;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = spawnTime;
        //objects = new ArrayList();
        SpawnRandomObject();
    }

    // Update is called once per frame
    void Update()
    {
        timedBoxSpawn();
    }

    void ManipuliteSpawnTime()
    {
        spawnTime = (float)Random.Range(20, 50)/100;
    }

    void SpawnRandomBox()
    {
        ManipuliteSpawnTime();
        GameObject g = Instantiate(Projectile1);
        //Vector3 playerPos = player.transform.position;
        Vector3 pos = new Vector3(13, Random.Range(-10, 10), 0);
        g.transform.position = pos;
        //g.GetComponent<ObjectScript>().terrainController = this.gameObject;
        //objects.Add(g.GetComponent<ObjectScript>());

    }
    void SpawnSlow()
    {
        GameObject g = Instantiate(Projectile1);
        Vector3 pos = new Vector3(13, Random.Range(-10, 10), 0);
        g.transform.position = pos;
    }
    void SpawnMedium()
    {
        GameObject g = Instantiate(Projectile2);
        Vector3 pos = new Vector3(13, Random.Range(-10, 10), 0);
        g.transform.position = pos;
    }
    void SpawnFast()
    {
        GameObject g = Instantiate(Projectile3);
        Vector3 pos = new Vector3(13, Random.Range(-10, 10), 0);
        g.transform.position = pos;
    }
    void SpawnRandomObject()
    {
        ManipuliteSpawnTime();
        int random = Random.Range(0, 10);
        if (random <= 5) { SpawnSlow(); }
        else if (random <= 8) { SpawnMedium(); }
        else { SpawnFast(); }

    }


    /*float relativeXPosition(Vector3 v3)
    {
        return player.transform.position.x - v3.x;
    }*/

    void timedBoxSpawn()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            SpawnRandomObject();
            currentTime = spawnTime;
        }
    }
}
