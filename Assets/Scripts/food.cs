using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{

    public float foodValue = 1;
    public bool randomFoodAmount = false;

    // Start is called before the first frame update
    void Start()
    {
        if (randomFoodAmount)
            foodValue = Random.Range(0.5f, 1.0f);
        var col = gameObject.GetComponent<Renderer>().material.color;
        col.a = foodValue;
    }

    private void OnTriggerEnter(Collider other)
    {        
        foodValue -= 0.1f;
        var col = gameObject.GetComponent<MeshRenderer>().material.color;
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(col.r, col.g, col.b, foodValue);
        if (col.a < 0)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
