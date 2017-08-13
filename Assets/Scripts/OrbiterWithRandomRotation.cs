using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbiterWithRandomRotation : MonoBehaviour {

    // Orbit rotation speed vector
    private Vector3 orbitRotationSpeedVector;

    [Range(-0.25f, 0.25f)]
    public float maxOrbitRotationSpeed1;

    [Range(-0.25f, 0.25f)]
    public float maxOrbitRotationSpeed2;

    [Range(-0.25f, 0.25f)]
    public float maxOrbitRotationSpeed3;

    void Start()
    {
        orbitRotationSpeedVector = new Vector3(Random.Range(0.0f, maxOrbitRotationSpeed1),
            Random.Range(0.0f, maxOrbitRotationSpeed2),
            Random.Range(0.0f, maxOrbitRotationSpeed3));

        if (maxOrbitRotationSpeed1 < 0.0)
            orbitRotationSpeedVector.x = Random.Range(maxOrbitRotationSpeed1, 0.0f);

        if (maxOrbitRotationSpeed2 < 0.0)
            orbitRotationSpeedVector.y = Random.Range(maxOrbitRotationSpeed2, 0.0f);

        if (maxOrbitRotationSpeed3 < 0.0)
            orbitRotationSpeedVector.z = Random.Range(maxOrbitRotationSpeed3, 0.0f);
    }

    void FixedUpdate()
    {
        gameObject.transform.Rotate(orbitRotationSpeedVector * Time.deltaTime);
    }
}
