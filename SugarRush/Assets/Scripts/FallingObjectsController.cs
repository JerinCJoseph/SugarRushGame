using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectsController : MonoBehaviour
{
    [SerializeField] private float waitTime;  
    [SerializeField] private GameObject fallingObjects;
    [SerializeField] private GameObject[] fallingSpecialObjects;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("OnObjectsFall", 1f, waitTime);
        InvokeRepeating("OnSpecialObjectsFall", 10f, 15f);
    }

    void OnObjectsFall() 
    {
        Instantiate(fallingObjects, new Vector3(Random.Range(-18, 18), 25, 0), Quaternion.identity);

    }

    void OnSpecialObjectsFall() //powerup desserts
    {
        for (int i = 0; i < fallingSpecialObjects.Length; i++)
        {
            Instantiate(fallingSpecialObjects[i], new Vector3(Random.Range(-18, 18), 25, 0), Quaternion.identity);
        }
    }
}
