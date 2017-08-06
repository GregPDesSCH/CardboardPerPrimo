using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbiterWithParticles : MonoBehaviour {

    // Orbit rotation speed
    public Vector3 orbitRotationSpeed = new Vector3();

    // Particle system to instantiate
    public ParticleSystem orbitParticles;

    // Refresh time between particle system instances
    private float timeElapsedSinceLastInstance = 0.00f;

    // Constants
    private const float INTERVAL_LENGTH_BETWEEN_PARTICLE_INSTANCES = 2.50f;

    void Start()
    {
        Instantiate(orbitParticles, gameObject.transform.position, gameObject.transform.rotation);
    }

    void FixedUpdate()
    {
        gameObject.transform.Rotate(orbitRotationSpeed * Time.deltaTime);
        timeElapsedSinceLastInstance += Time.deltaTime;

        if (timeElapsedSinceLastInstance >= INTERVAL_LENGTH_BETWEEN_PARTICLE_INSTANCES)
        {
            Instantiate(orbitParticles, gameObject.transform.position, gameObject.transform.rotation);
            timeElapsedSinceLastInstance = 0.0f;
        }
    }
}
