using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public float speed = 2f;
    public ArrayList objects;
    public GameObject player;
    public GameObject Rock;

    public float offset = 15f;

    private int deletionDistance = 20;
    public float spawnTime = 5f;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = spawnTime;
        objects = new ArrayList();
        SpawnRandomBox();
    }

    // Update is called once per frame
    void Update()
    {
        timedBoxSpawn();
    }

    void SpawnRandomBox()
    {
        GameObject g = Instantiate(Rock);
        Vector3 playerPos = player.transform.position;
        Vector3 pos = new Vector3(playerPos.x + offset, Random.Range(1, 5), 0);
        g.transform.Translate(pos);
        g.GetComponent<ObjectScript>().terrainController = this.gameObject;
        objects.Add(g.GetComponent<ObjectScript>());

    }

    float relativeXPosition(Vector3 v3)
    {
        return player.transform.position.x - v3.x;
    }

    void timedBoxSpawn()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            SpawnRandomBox();
            currentTime = spawnTime;
        }
    }
}
