using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaReproducer : MonoBehaviour
{
    public Bacteria bacteriaPrefab;
 

    private GameObject bacteriaContainer;

    void Start()
    {
        bacteriaContainer = GameObject.Find("BacteriaContent");
        Bacteria childBacteriaObject = Instantiate(bacteriaPrefab);
        childBacteriaObject.transform.parent = bacteriaContainer.transform;
    }

    public void Reproduce(Vector3 position)
    {
        bacteriaContainer = GameObject.Find("BacteriaContent");
        Bacteria childBacteriaObject = Instantiate(bacteriaPrefab);
        position.x += 0.1f;
        childBacteriaObject.transform.position = position;
        childBacteriaObject.transform.parent = bacteriaContainer.transform;
    }
}
