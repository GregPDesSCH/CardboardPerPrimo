using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimoRotatingCube : MonoBehaviour
{
    // Rotation vector (around its own pivot at the center)
    public Vector3 rotationSpeed = new Vector3(0.0f, 0.0f, 0.0f);

    [Range(-10.0f, 0.0f)]
    public float minimumRotationSpeedValue = -5.0f;
    [Range(0.0f, 10.0f)]
    public float maximumRotationSpeedValue = 5.0f;

    public bool rotationIsRandom = false;

	// Use this for initialization
	void Start ()
    {
        if (rotationIsRandom)
            rotationSpeed.Set(Random.Range(minimumRotationSpeedValue, maximumRotationSpeedValue), 
                Random.Range(minimumRotationSpeedValue, maximumRotationSpeedValue), 
                Random.Range(minimumRotationSpeedValue, maximumRotationSpeedValue));
    }
	
	void FixedUpdate ()
    {
        gameObject.transform.Rotate(rotationSpeed * Time.deltaTime);
	}
}
