using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{

    public float speed = 2f;
    public ArrayList objects;
    public GameObject player;
    public GameObject SpawnObject;
    public GameObject SpawnObject2;

    public float offset = 15f;

    private int deletionDistance = 20;
    public float spawnTime = 5f;
    private float currentTime;

    private int objectType = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = spawnTime;
        objects = new ArrayList();
        SpawnRandomObject();
    }

    // Update is called once per frame
    void Update()
    {

        speed += Time.deltaTime * 0.25f;
        if(spawnTime > 1)
            spawnTime -= Time.deltaTime * 0.0005f;
        
        timedBoxSpawn();
        moveObjects();
        checkObjects();
    }

    void SpawnRandomObject()
    {
        switch (objectType)
        {
            case 0:
                spawnIceBot();
                objectType = 1;
                break;
            case 1:
                spawnIceTop();
                objectType = 0;
                break;
            default:
                break;
        }
        

    }

    void spawnIceTop()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 pos = new Vector3(playerPos.x + offset, Random.Range(2, 6), 0);
        GameObject g = Instantiate(SpawnObject);
        g.GetComponent<ObjectScript>().terrainController = this.gameObject;
        objects.Add(g.GetComponent<ObjectScript>());
        g.transform.Translate(pos);
    }

    void spawnIceBot()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 pos = new Vector3(playerPos.x + offset, Random.Range(-2, -6), 0);
        GameObject g = Instantiate(SpawnObject2);
        g.GetComponent<ObjectScript>().terrainController = this.gameObject;
        objects.Add(g.GetComponent<ObjectScript>());
        g.transform.Translate(pos);
    }

    float relativeXPosition(Vector3 v3) {
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
        foreach(ObjectScript obj in objects)
            if(deletionDistance - obj.gameObject.transform.position.x <= 0)
                dels.Add(obj);

        foreach(ObjectScript obj in dels)
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
            SpawnRandomObject();
            currentTime = spawnTime;
        }
    }
}
