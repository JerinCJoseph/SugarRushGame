using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarGlobFallingController : MonoBehaviour
{
   /* [SerializeField] private GameObject sugarGlobP;
    private float fallSpeed = 5f;  //[SerializeField]
    private float spawnAreaWidth = 18f;  //[SerializeField]

    private GameObject currentSugarGlob;

    // Start is called before the first frame update
     void Start()
    {
       // SpawnSugarGlob();
    }

    void SpawnSugarGlob()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnAreaWidth, spawnAreaWidth), 25f, 0f);   
        currentSugarGlob = Instantiate(sugarGlobP, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = currentSugarGlob.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * fallSpeed;
        }
    }

    public void RespawnSugarGlob()
    {
        //Destroy(currentSugarGlob);
        SpawnSugarGlob();
    }*/
}