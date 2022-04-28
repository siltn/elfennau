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
        moveObjects();
        checkObjects();
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

    void moveObjects()
    {
        float movement = speed * Time.deltaTime;
        foreach (ObjectScript obj in objects)
        {
            obj.move(new Vector3(-movement, 0, 0));
        }
    }

    void checkObjects()
    {
        ArrayList dels = new ArrayList();
        foreach (ObjectScript obj in objects)
        {
            if (deletionDistance - obj.gameObject.transform.position.x <= 0)
            {
                dels.Add(obj);
            }
        }

        foreach (ObjectScript obj in dels)
        {
            objects.Remove(obj);
            Destroy(obj.gameObject);
        }
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
