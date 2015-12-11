using UnityEngine;
using System.Collections;

public class Cup_Deletion : MonoBehaviour {

    public float deleteBorder = 0;
    public GameObject cup;

	// Use this for initialization
	void Start () {
        cup.transform.rotation = Random.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y <= deleteBorder)
            Destroy(cup);
	}
}
