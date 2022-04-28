using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CloudDeployment : MonoBehaviour
{
    public float RespawnTime = 0f;
    public GameObject cloudPrefab;
    public float lastCloudHeight = 0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCloudWave();
    }

    private void SpawnCloudWave() {
        if (RespawnTime > 0) {
            RespawnTime -= Time.deltaTime * 4;
        } else {
            SpawnCloud();
            RespawnTime = 3f;
        }
    }

    private void SpawnCloud() {
        cloudPrefab = Instantiate(cloudPrefab);
        float yPosition = lastCloudHeight + Random.Range(-1f,1f);
        if (yPosition < -4f) yPosition = -3.9f;
        if (yPosition > 3f) yPosition = 2.9f;
        cloudPrefab.transform.position = new Vector3(12, yPosition, 0);
        lastCloudHeight = cloudPrefab.transform.position.y;
    }
}
