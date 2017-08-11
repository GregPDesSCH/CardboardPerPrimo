using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbiterWithRandomRotation : MonoBehaviour {

    // Orbit rotation speed vector
    private Vector3 orbitRotationSpeedVector;

    [Range(0.0f, 0.25f)]
    public float maxOrbitRotationSpeed1;

    [Range(0.0f, 0.25f)]
    public float maxOrbitRotationSpeed2;

    [Range(0.0f, 0.25f)]
    public float maxOrbitRotationSpeed3;

    void Start()
    {
        orbitRotationSpeedVector = new Vector3(Random.Range(0.0f, maxOrbitRotationSpeed1),
            Random.Range(0.0f, maxOrbitRotationSpeed2),
            Random.Range(0.0f, maxOrbitRotationSpeed3));
    }

    void FixedUpdate()
    {
        gameObject.transform.Rotate(orbitRotationSpeedVector * Time.deltaTime);
    }
}
