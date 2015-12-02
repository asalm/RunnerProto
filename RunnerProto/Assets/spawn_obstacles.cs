using UnityEngine;
using System.Collections;

public class spawn_obstacles : MonoBehaviour {


    public GameObject playerObject, platform;
    int length = 8;
    float x, distance, xPlatform;
	// Use this for initialization
	void Start () {
        x = playerObject.transform.position.x;
        xPlatform = platform.transform.position.x - length;
    }
	
	// Update is called once per frame
	void Update () {

        distance = getDistance();
        if (distance < 0)
            distance *= -1;
        if (distance >= 5)
        {
            x = playerObject.transform.position.x;
            GameObject platformInstance = Instantiate(platform);
            platformInstance.transform.position = new Vector3(xPlatform, platform.transform.position.y, platform.transform.position.z);
            xPlatform -= length;
            Debug.Log("instantiiert");
        }

	}

    public float getDistance() // errechnet die aktuelle zurückgelegt Distanz eines Gameobjects, was vom Nutzer festgelegt wird
    {
        if (x <= playerObject.transform.position.x)
            return playerObject.transform.position.x - x;
        else
            return x - playerObject.transform.position.x;
    }
}
