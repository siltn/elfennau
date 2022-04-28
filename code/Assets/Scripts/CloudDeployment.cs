using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDeployment : MonoBehaviour
{
    public GameObject cloud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject tmpObj = Instantiate(cloud);

        tmpObj.transform.position = new Vector3(10,2,transform.position.z); 
    }
}