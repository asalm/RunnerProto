using UnityEngine;
using System.Collections;

public class OnCollisionBehaviour : MonoBehaviour {

    public ParticleSystem poof;
    public Animation walk;
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
            //Debug.Log("#Collision");
            poof.Play();
        }

        if(poof.IsAlive())
        {
            poof.Stop();
        }
    }
}
