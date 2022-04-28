using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public GameObject terrainController = null;
    private bool started = false;
    public bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float movement = speed * Time.deltaTime;
        //transform.Translate(movement);
        if (!started)
        {
            terrainController.GetComponent<TerrainController>().objects.Add(this);
            started = true;
        }
        
    }

    public void move(Vector3 movement)
    {
        if (stop)
        {
            terrainController.GetComponent<TerrainController>().objects.Remove(this);
            return;
        }
        transform.Translate(movement);
    }

}
