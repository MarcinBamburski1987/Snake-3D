using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            Destroy(GetComponent<MeshRenderer>(),3f);
        }
    }

    
}
