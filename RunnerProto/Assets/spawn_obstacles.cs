using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawn_obstacles : MonoBehaviour {


    public GameObject playerObject, platform;
    List<GameObject> treadmill = new List<GameObject>();
    int counter = 0;
    int length = 8, maxDistance = 5;
    //maxDistance ist die maximale Distanz die zurückgelegt werden darf, bis eine neue Platform erstellt wird
    float currentXPosPlayer, distance, xPosPlatform;
    float absoluteX;
	// Use this for initialization
	void Start () {

        StartCoroutine(DeleteIntances());
        currentXPosPlayer = playerObject.transform.position.x;
        absoluteX = currentXPosPlayer;
        xPosPlatform = platform.transform.position.x - length;

        treadmill.Add(platform);
    }
	
	// Update is called once per frame
	void Update () {

        distance = getDistance(); //zurückgelegte Strecke vom Player
        if (distance < 0)
            distance *= -1;
        if (distance >= maxDistance)
        {
            currentXPosPlayer = playerObject.transform.position.x;

            GameObject platformInstance = (GameObject)Instantiate(platform); // Instanz des Laufbands wird erstellt
            treadmill.Add(platformInstance); //neue Instanz wird in die Liste hinzugefügt

            platformInstance.transform.position = new Vector3(xPosPlatform, platform.transform.position.y, platform.transform.position.z);
            //oben: die erstellte Instanz wird hier neu positioniert

            xPosPlatform -= length; //neue Position um die instantiierte Platform zu positionieren
            Debug.Log(treadmill.Count);
        }

	}

    public float getDistance() // errechnet die aktuelle zurückgelegt Distanz eines Gameobjects, was vom Nutzer festgelegt wird
    {//je nachdem ob er sich rückwärts oder vorwärts bewegt, soll ein positiver Wert zurückgegeben werden, daher die Fallunterscheidung
        if (currentXPosPlayer <= playerObject.transform.position.x)
            return playerObject.transform.position.x - currentXPosPlayer;
        else
            return currentXPosPlayer - playerObject.transform.position.x;
    }



    IEnumerator DeleteIntances()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            Destroy(treadmill[counter + 1]);
            Debug.Log("Destroyed");
            counter++;
        }
    }
}
