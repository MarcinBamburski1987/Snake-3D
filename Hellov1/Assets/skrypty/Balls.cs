using UnityEngine;
using System.Collections;

public class Balls : MonoBehaviour {

    public GameObject food;
    public Vector3 spawnValue;
    private float startTime = 0.0F;
    public float counter = 10F;

	void Start () {
            
	}

    void Update()
    {
        randomPosition();
    }

    void randomPosition()
    {
        Vector3 positionSpawn = new Vector3(Random.Range(-spawnValue.x,spawnValue.x),spawnValue.y, Random.Range(-spawnValue.z, spawnValue.z));
            if(Time.time > startTime)
            {
            startTime = Time.time + counter;
            Instantiate(food, positionSpawn, Quaternion.identity);
            }
    }

    
}
