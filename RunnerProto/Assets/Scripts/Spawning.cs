using UnityEngine;
using System.Collections;
using UnityEditor;

namespace RunnerProto
{
    public class Spawning : MonoBehaviour
    {
        public float startTime = 0, frequency = 1.0f;
        float x,y,z;
        // Use this for initialization
        void Start()
        {
            x = 1;
            InvokeRepeating("spawn", startTime, frequency);
        }

        // Update is called once per frame
        void Update()
        {
            x = transform.position.x;
            y = transform.position.y;
            z = transform.position.z;
        }

        void spawn()
        {
            Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Napf.prefab", typeof(GameObject));
            GameObject clone = Instantiate(prefab, new Vector3(x,y,z), (Quaternion) Random.rotation) as GameObject;
        }
    }
}
