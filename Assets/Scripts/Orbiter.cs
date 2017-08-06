using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    // Orbit rotation speed
    public Vector3 orbitRotationSpeed = new Vector3();

	void FixedUpdate () {
        gameObject.transform.Rotate(orbitRotationSpeed * Time.deltaTime);
	}
}
