using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopHatStickFigure : MonoBehaviour
{
    // Constants
    private enum MovementMode { FORWARD, BACKWARD };

    private const float maximumLegInwardsAngle = 10.0f;
    private const float maximumLegOutwardsAngle = 50.0f;
    private const float maximumArmInwardsAngle = 10.0f;
    private const float maximumArmOutwardsAngle = 60.0f;


    public GameObject leftArmJoint;
    public GameObject rightArmJoint;
    public GameObject leftLegJoint;
    public GameObject rightLegJoint;
    public GameObject topHat;

    private MovementMode leftArmMovementMode;
    private MovementMode rightArmMovementMode;
    private MovementMode leftLegMovementMode;
    private MovementMode rightLegMovementMode;

    public float topHatRotationSpeed = 5.0f; // default: 5° / second
    public float leftArmRotationSpeed = 10f; // default: 10° / second
    public float rightArmRotationSpeed = 10f; // default: 10° / second
    public float leftLegRotationSpeed = 10f; // default: 10° / second
    public float rightLegRotationSpeed = 10f; // default: 10° / second

    private float leftArmCurrentAngle = 0.0f;
    private float rightArmCurrentAngle = 0.0f;
    private float leftLegCurrentAngle = 0.0f;
    private float rightLegCurrentAngle = 0.0f;

    // Use this for initialization
    void Start ()
    {
        if (Random.value <= 0.5)
            leftArmMovementMode = MovementMode.FORWARD;
        else
            leftArmMovementMode = MovementMode.BACKWARD;

        if (Random.value <= 0.5)
            rightArmMovementMode = MovementMode.FORWARD;
        else
            rightArmMovementMode = MovementMode.BACKWARD;

        if (Random.value <= 0.5)
            leftLegMovementMode = MovementMode.FORWARD;
        else
            leftLegMovementMode = MovementMode.BACKWARD;

        if (Random.value <= 0.5)
            rightLegMovementMode = MovementMode.FORWARD;
        else
            rightLegMovementMode = MovementMode.BACKWARD;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        /* Top Hat */
        topHat.transform.Rotate(Vector3.up, topHatRotationSpeed * Time.deltaTime);


        /* Arms */
        // Left arm
        leftArmCurrentAngle += (leftArmMovementMode == MovementMode.FORWARD) ? leftArmRotationSpeed * Time.deltaTime :
            -leftArmRotationSpeed * Time.deltaTime;
        leftArmJoint.transform.Rotate(Vector3.forward, (leftArmMovementMode == MovementMode.FORWARD) ? 
            leftArmRotationSpeed * Time.deltaTime : -leftArmRotationSpeed * Time.deltaTime);

        if (leftArmMovementMode == MovementMode.FORWARD && leftArmCurrentAngle >= maximumArmOutwardsAngle)
                leftArmMovementMode = MovementMode.BACKWARD;
        else if (leftArmMovementMode == MovementMode.BACKWARD && leftArmCurrentAngle <= -maximumArmInwardsAngle)
                leftArmMovementMode = MovementMode.FORWARD;

        // Right arm
        rightArmCurrentAngle += (rightArmMovementMode == MovementMode.FORWARD) ? rightArmRotationSpeed * Time.deltaTime :
            -rightArmRotationSpeed * Time.deltaTime;
        rightArmJoint.transform.Rotate(Vector3.forward, (rightArmMovementMode == MovementMode.FORWARD) ?
            rightArmRotationSpeed * Time.deltaTime : -rightArmRotationSpeed * Time.deltaTime);

        if (rightArmMovementMode == MovementMode.BACKWARD && rightArmCurrentAngle <= -maximumArmOutwardsAngle)
            rightArmMovementMode = MovementMode.FORWARD;
        else if (rightArmMovementMode == MovementMode.FORWARD && rightArmCurrentAngle >= maximumArmInwardsAngle)
            rightArmMovementMode = MovementMode.BACKWARD;




        /* Legs */
        // Left leg
        leftLegCurrentAngle += (leftLegMovementMode == MovementMode.FORWARD) ? leftLegRotationSpeed * Time.deltaTime :
            -leftLegRotationSpeed * Time.deltaTime;
        leftLegJoint.transform.Rotate(Vector3.forward, (leftLegMovementMode == MovementMode.FORWARD) ?
            leftLegRotationSpeed * Time.deltaTime : -leftLegRotationSpeed * Time.deltaTime);

        if (leftLegMovementMode == MovementMode.FORWARD && leftLegCurrentAngle >= maximumLegInwardsAngle)
            leftLegMovementMode = MovementMode.BACKWARD;
        else if (leftLegMovementMode == MovementMode.BACKWARD && leftLegCurrentAngle <= -maximumLegOutwardsAngle)
            leftLegMovementMode = MovementMode.FORWARD;


        // Right leg
        rightLegCurrentAngle += (rightLegMovementMode == MovementMode.FORWARD) ? rightLegRotationSpeed * Time.deltaTime :
            -rightLegRotationSpeed * Time.deltaTime;
        rightLegJoint.transform.Rotate(Vector3.forward, (rightLegMovementMode == MovementMode.FORWARD) ?
            rightLegRotationSpeed * Time.deltaTime : -rightLegRotationSpeed * Time.deltaTime);

        if (rightLegMovementMode == MovementMode.BACKWARD && rightLegCurrentAngle <= -maximumLegInwardsAngle)
            rightLegMovementMode = MovementMode.FORWARD;
        else if (rightLegMovementMode == MovementMode.FORWARD && rightLegCurrentAngle >= maximumLegOutwardsAngle)
            rightLegMovementMode = MovementMode.BACKWARD;

    }

}
