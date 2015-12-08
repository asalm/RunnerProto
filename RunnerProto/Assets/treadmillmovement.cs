using UnityEngine;
using System.Collections;

public class treadmillmovement : MonoBehaviour {


    public float speed = 3.0f;
    public bool backwards = true;
    public bool x = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x - speed*Time.deltaTime, transform.position.y, transform.position.z);       	
	}

    void onTriggerEnter(Collision c)
    {
        Debug.Log(name + " triggered");
    }
    void OnCollisionEnter(Collision c)
    {
        Debug.Log(name + " collided");
    }
}
