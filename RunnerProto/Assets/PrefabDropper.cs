using UnityEngine;
using System.Collections;

public class PrefabDropper : MonoBehaviour {

    //Public Variables
    public float startTime; //Time til First obj Spawns
    public int freq; //Frequence of obj spawning after first one
    public GameObject prefab; //Spawning Prefab

    //Private Class Variables
    float objX;
    float objY;
    float objZ;


	// Use this for initialization
	void Start () {

        InvokeRepeating("spawn", startTime, freq); //nearly the same as startCoroutine;
    }
	
	// Update is called once per frame
	void Update () {


        objX = this.gameObject.transform.position.x;
        objY = this.gameObject.transform.position.y;
        objZ = this.gameObject.transform.position.z;
	
	}

    void spawn()
    {
        Vector3 pos = new Vector3(objX-2.5F, objY, objZ); // Spawn Coordinates
        Quaternion rota = new Quaternion(0, 0, 0, 0);
        Instantiate(prefab, pos, rota);
    }

}
