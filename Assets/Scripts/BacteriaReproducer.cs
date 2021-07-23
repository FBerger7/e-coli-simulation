using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaReproducer : MonoBehaviour
{
    public Bacteria bacteriaPrefab;
    //public BacteriaStats bacteriaStats;
    //public GameObject bacteriaContainer; 

    private GameObject bacteriaContainer;

    void Start()
    {
        bacteriaContainer = GameObject.Find("BacteriaContent");
        Bacteria childBacteriaObject = Instantiate(bacteriaPrefab);
        childBacteriaObject.transform.parent = bacteriaContainer.transform;
    }

    public void reproduce()
    {
        bacteriaContainer = GameObject.Find("BacteriaContent");
        //BacteriaManager childBacteriaObject = new BacteriaManager(100);
        Bacteria childBacteriaObject = Instantiate(bacteriaPrefab);
        childBacteriaObject.GetComponent<Bacteria>().SetEnergy(100);
        //childBacteriaObject.AddComponent<BacteriaStats>();        
        childBacteriaObject.transform.parent = bacteriaContainer.transform;
        //childBacteriaObject.transform.parent = bacteriaContainer.transform;
    }
}
