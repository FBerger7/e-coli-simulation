using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BacteriaManager : MonoBehaviour
{
    public float spawnRate;
    public BacteriaReproducer bacteriaMother;

    private float spawnProbability;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnProbability += 0.01f;
        float a = Random.Range(1.0f, 100.0f);
        if (a < spawnProbability)
        {
            //Debug.Log("SPAWN");
            spawnProbability = 0.0f;
            // ---------------------- SPAWN ----------------------
            bacteriaMother.reproduce();

            // ------------- SET VARIABLES FOR CHILD -------------
            //childBacteriaObject.GetComponent<BacteriaManager>().energy = 100;

            // -------------------- UPDATE UI --------------------
            UIManager.globalBacteriaCount++;                      
        }
       
    }
}
