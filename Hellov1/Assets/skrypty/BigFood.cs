using UnityEngine;
using System.Collections;

public class BigFood : MonoBehaviour {

    public GameObject bigFoodMaterial;
    public Vector3 spawnValue;
    private float startTime = 0.5F;
    public float counter = 15F;

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
            Instantiate(bigFoodMaterial, positionSpawn, Quaternion.identity);
            }
    }

    
}
