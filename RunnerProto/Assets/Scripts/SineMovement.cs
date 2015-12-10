using UnityEngine;
using System.Collections;

public class SineMovement : MonoBehaviour {


    public float speed = 3.0f;
    float rad = 0.0f;
    public float amplitude = 0.001f, PI_Divider = 32.0f;
    float d, startZ;
    //die Amplitude bestimmt den Ausschlag der SinusCurve, und der PI_Divider ist dafür da, dass die Sinuskurve langsamer durchlaufen wird
    //PI_Divider example: 1 Bogenmaß / 32 -> 1/32 Bogenmaß -> sin(1/32) ist kleiner als sin(1)
    // Use this for initialization
    void Start () {
        startZ = transform.position.z;
        d = PI_Divider;
        InvokeRepeating("setDivider", 0, 2);
    }
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z + amplitude*Mathf.Sin(rad));
        rad += Mathf.PI/ PI_Divider;
	}

    private void setDivider() //für ein zufälligeres Verhalten der Sinuskurve. KLappt aber noch nicht so wirklich...
    {       
        PI_Divider = Random.value * d;
        Debug.Log("aufgerufen!" + PI_Divider);
        transform.position = new Vector3(transform.position.x, transform.position.y, startZ);
    }
}
