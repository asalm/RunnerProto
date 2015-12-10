using UnityEngine;
using System.Collections;

public class OutOfBoundsReaction : MonoBehaviour {

    float objY;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        objY = this.gameObject.transform.position.y;

        if(objY < -3)
        {
            Destroy(this.gameObject);
        }
	}
}
