using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaMoveManager : MonoBehaviour
{
    [SerializeField] [Range(5f, 10f)] float lerpTime;
    public BacteriaMovementState bacteriaState;
    Rigidbody bacteriaRigidbody;
    public float thrust = 10f;
    public int bacteriaVision = 5;

    private float nextTumbleTime;
    private float nextForwardTime;
    private float old_drag;
    private Vector3 tumbleOrientation;
    private RaycastHit hit;

    private Quaternion desiredRotation;

    // Start is called before the first frame update
    void Start()
    {
        tumbleOrientation = new Vector3(Random.Range(0, 30), Random.Range(0, 30), Random.Range(0, 30));
        nextTumbleTime = Random.Range(1.0f, 10.0f);
        bacteriaState = BacteriaMovementState.Straight;
        bacteriaRigidbody = GetComponent<Rigidbody>();
        Quaternion desiredRotation = Quaternion.Euler(Random.Range(0, 80), Random.Range(0, 80), Random.Range(0, 80));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > nextTumbleTime && bacteriaState == BacteriaMovementState.Straight)
            SetTumbleMovement();
        if (Time.time > nextForwardTime && bacteriaState == BacteriaMovementState.Roll)
            SetForwardMovement();
        ScanForFood();
        if (bacteriaState == BacteriaMovementState.Straight)
            MoveForward();
        else if (bacteriaState == BacteriaMovementState.Roll)
            Tumble();

    }

    private void ScanForFood()
    {        
        if (Physics.Raycast(transform.position, transform.up, out hit, bacteriaVision))
        {
            
            if (hit.collider.CompareTag("Food"))
            {
                //Debug.Log("FOOD");
                Debug.DrawRay(transform.position, transform.up * bacteriaVision, Color.yellow);
                SetForwardMovement();
            }
        }
    }

    private void SetForwardMovement()
    {
        bacteriaState = BacteriaMovementState.Straight;
        nextTumbleTime = Random.Range(1.0f, 10.0f) + Time.time;
    }

    private void SetTumbleMovement()
    {
        bacteriaState = BacteriaMovementState.Roll;
        nextForwardTime = Random.Range(3.0f, 7.0f) + Time.time;
    }

    private void MoveForward()
    {
        //Debug.Log("MOVING FORWARD");
        bacteriaRigidbody.angularVelocity = bacteriaRigidbody.angularVelocity/1.15f;
        bacteriaRigidbody.drag = old_drag;
        bacteriaRigidbody.AddForce(transform.up * thrust);
    }

    private void Tumble()
    {
        //Debug.Log("TUMBLING");
        old_drag = bacteriaRigidbody.drag;
        //bacteriaRigidbody.drag = Random.Range(.5f, 3f);
        bacteriaRigidbody.velocity = bacteriaRigidbody.velocity / 1.05f;
        bacteriaRigidbody.AddForce(transform.up * thrust * 8f);
        bacteriaRigidbody.AddTorque(tumbleOrientation);
        tumbleOrientation.x = tumbleOrientation.x > 360.0f ? 0 : tumbleOrientation.x + Random.Range(-6.0f, 6.0f);
        tumbleOrientation.y = tumbleOrientation.y > 360.0f ? 0 : tumbleOrientation.y + Random.Range(-6.0f, 6.0f);
        tumbleOrientation.z = tumbleOrientation.z > 360.0f ? 0 : tumbleOrientation.z + Random.Range(-6.0f, 6.0f);
    }
}
