﻿using UnityEngine;
using System.Collections;

public class OnCollisionBehaviour : MonoBehaviour {

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("#Collision");
            //Destroy(this.gameObject);
        }
    }
}