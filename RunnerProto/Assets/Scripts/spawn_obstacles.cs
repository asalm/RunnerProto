using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawn_obstacles : MonoBehaviour {

    public GameObject playerObject;
    public GameObject platform;
    public float freq = 2.0f;
    Queue<GameObject> treadmill = new Queue<GameObject>(); //Das Verhalten des Laufband ist einer Queue ähnlich:
    //Hinten werden Objekte rangehängt und die ersten Objekte werden gelöscht ----> FIFO
    int length = 16, maxDistance = 7;
    //maxDistance ist die maximale Distanz die zurückgelegt werden darf, bis eine neue Platform erstellt wird
    float currentXPosPlayer, distance, xPosPlatform;
    static float absoluteX;
    static float speedBorder = 20.0f, deltaSpeed = 0.5f;
	// Use this for initialization
	void Start () {
        InvokeRepeating("deleteInstances", 10, 5); //nearly the same as startCoroutine;
        currentXPosPlayer = playerObject.transform.position.x;
        absoluteX = currentXPosPlayer;
        xPosPlatform = platform.transform.position.x - length;
    }
	
	// Update is called once per frame
	void Update () {

        if(getTotalDistance() >= speedBorder) //die Geschwindigkeit ist abhängig von der zurückgelegten Strecke, sie wird erhöht je länger der Spieler läuft
        {
            treadmillmovement.setSpeed(deltaSpeed);
            speedBorder += speedBorder;
        }
        distance = getDistance(); //zurückgelegte Strecke vom Player
        if (distance < 0)
            distance *= -1;
        if (distance >= maxDistance)
        {
            currentXPosPlayer = playerObject.transform.position.x;
            GameObject platformInstance = new GameObject();
            platformInstance = (GameObject)Instantiate(platform); // Instanz des Laufbands wird erstellt
            

            platformInstance.transform.position = new Vector3(xPosPlatform, platform.transform.position.y, platform.transform.position.z);
            //oben: die erstellte Instanz wird hier neu positioniert

            xPosPlatform -= length; //neue Position um die instantiierte Platform zu positionieren
          
            treadmill.Enqueue(platformInstance); //neue Instanz wird in die Liste hinzugefügt
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


    public float getTotalDistance()
    {
        if(absoluteX > playerObject.transform.position.x)
            return absoluteX - playerObject.transform.position.x;
        else
            return playerObject.transform.position.x  - absoluteX;
    }

    void deleteInstances()
    {
        Debug.Log("destroyed");
        Destroy(treadmill.Dequeue());
    }

    public static float getSpeedBorder()
    {
        return speedBorder;
    }
}
