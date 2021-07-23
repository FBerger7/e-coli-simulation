using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaMoveManager : MonoBehaviour
{
    private BacteriaMovementState bacteriaState;
    Rigidbody bacteriaRigidbody;
    public float thrust = 5f;
    private float old_drag;

    // Start is called before the first frame update
    void Start()
    {
        bacteriaState = BacteriaMovementState.Straight;
        bacteriaRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.Range(0.0f, 1.0f) * (Time.time % 6) > 5)
        {
            //Debug.Log("ROLL");
            old_drag = bacteriaRigidbody.drag;
            BacteriaRollMovement();
        }
        else
        {
            //Debug.Log("STRAIGHT");
            bacteriaRigidbody.drag = old_drag;
            BacteriaStraightMovement();
        }
    }

    private void BacteriaStraightMovement()
    {
        bacteriaRigidbody.AddRelativeForce(Vector3.forward * thrust);
    }

    private void BacteriaRollMovement()
    {
        bacteriaRigidbody.drag = Random.Range(.5f, 3f);
        bacteriaRigidbody.AddTorque(Random.Range(0, 30), Random.Range(0, 30), Random.Range(0, 30));
    }
}
