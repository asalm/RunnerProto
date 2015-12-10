using UnityEngine;
using System.Collections;

public class RandomMovementBehaviour : MonoBehaviour {

    public Rigidbody body;
    Transform obj;
    Vector3 velo;
    float switchDir = 0.2f;
    float curTime = 0;

    public float minValue, maxValue; //maxValue muss die Breite der Platform sein, eine getter Methode wäre gut

	// Use this for initialization
	void Start () {
        SetVel();
	}
	
    void SetVel()
    {
        if(Random.value > .5)
        {
            velo.z = 0.5f * Random.value;
        }
        else
        {
            velo.z = -0.5f * Random.value;
        }
    }
	// Update is called once per frame
	void Update () {
	    if (curTime < switchDir)
        {
            curTime += 1 * Time.deltaTime;
        }
        else
        {
            SetVel();
            if (Random.value > .5)
            {
                switchDir += Random.value;
            }
            else
            {
                switchDir -= Random.value;
            }
            if(switchDir < 1)
            {
                switchDir = 1 + Random.value;
            }
            curTime = 0;
        }
	}

    void FixedUpdate()
    {
        body.velocity = velo;
    }
}
