using UnityEngine;
using System.Collections;

public class FoodDestroy : MonoBehaviour {

    public GameObject foodDes;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(foodDes,3f);
	}
}
