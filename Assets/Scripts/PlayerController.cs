using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public PlayerSettings settings;
    public Transform engines;

    private bool accelerating = false;
    private float speed = 0.0f;

    private Rigidbody m_Rigidbody;
    private Light[] m_Lights;
    private float[] m_LightIntensities;
    private ParticleSystem[] m_Particles;
    private AsteroidController asteroid;

    void Start()
    {
	    m_Rigidbody = GetComponent<Rigidbody>();
	    m_Lights = engines.GetComponentsInChildren<Light>();
	    m_LightIntensities = new float[m_Lights.Length];
	    for (int i = 0; i < m_Lights.Length; i++) {
		    m_LightIntensities[i] = m_Lights[i].intensity;
	    }
	    m_Particles = engines.GetComponentsInChildren<ParticleSystem>();
    }

    void Update() 
    {
	    float intensityScale = accelerating ? 1.0f : 0.0f;
	    float t = Time.deltaTime / settings.engine_cooldown;
	    for (int i = 0; i < m_Lights.Length; i++) {
		    float intensity = m_LightIntensities[i] * intensityScale;
		    m_Lights[i].intensity = Mathf.Lerp(m_Lights[i].intensity, intensity, t);
	    }
	    for (int i = 0; i < m_Particles.Length; i++) {
		    m_Particles[i].enableEmission = accelerating;
	    }
    }

    void FixedUpdate()
    {
	    // Speed
	    if (Input.GetKey(KeyCode.Space)) {
		    accelerating = true;
		    speed += settings.GetAcceleration() * Time.fixedDeltaTime;
	    } else {
		    accelerating = false;
		    speed -= settings.GetDeceleration() * Time.fixedDeltaTime;
	    }
	    speed = Mathf.Clamp(speed, 0, settings.max_speed);

	    m_Rigidbody.MovePosition(transform.position + transform.forward * speed);

	    // Direction
	    Vector3 euler = new Vector3(0, 0, 0);
	    if (Input.GetKey(KeyCode.W)) {
		    euler.x -= 360.0f / settings.pitch_time;
	    }
	    if (Input.GetKey(KeyCode.A)) {
		    euler.y -= 360.0f / settings.yaw_time;
	    }
	    if (Input.GetKey(KeyCode.S)) {
		    euler.x += 360.0f / settings.pitch_time;
	    }
	    if (Input.GetKey(KeyCode.D)) {
		    euler.y += 360.0f / settings.yaw_time;
	    }
	    if (Input.GetKey(KeyCode.Q)) {
		    euler.z += 360.0f / settings.roll_time;
	    }
	    if (Input.GetKey(KeyCode.E)) {
		    euler.z -= 360.0f / settings.roll_time;
	    }
	    Quaternion delta_direction = Quaternion.Euler(euler * Time.fixedDeltaTime);
	    m_Rigidbody.MoveRotation(m_Rigidbody.rotation * delta_direction);


	    // Rotate Engines
	    float revs_per_second = settings.max_revs * speed/settings.max_speed;
	    float delta_degrees = revs_per_second * Time.fixedDeltaTime * 360;
	    engines.Rotate(new Vector3(delta_degrees, 0, 0));

	    
	    // Check for tractor target
	    // TODO: Ignore self
	    if (!Input.GetKey(KeyCode.R)) {
		    asteroid = null;
	    }

	    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
	    RaycastHit hit;
	    bool did_hit = Physics.Raycast(ray, out hit);
	    if (did_hit) {
		    AsteroidController hitAsteroid = hit.collider.GetComponent<AsteroidController>();
		    // TODO: Tell user that if the object isn't tractable
		    // TODO: Tell user that they can't pull more than one asteroid at a time (or enable multiple asteroids at a time?)
		    // TODO: Tell user to hold R to use tractor beam
		    UIController.instance.SetReticleEnabled(did_hit);
		    if (hitAsteroid && Input.GetKey(KeyCode.R) && !asteroid) {
			    asteroid = hitAsteroid;
		    }
	    } else {
		    UIController.instance.SetReticleEnabled(false);
	    }

	    // Pull Asteroid towards self
	    if (asteroid) {
		    Vector3 offset = transform.position - asteroid.transform.position;
		    asteroid.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(offset) * settings.tractorBeamForce);
	    }
    }
}
