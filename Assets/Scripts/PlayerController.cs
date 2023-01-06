using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public PlayerSettings settings;
    public Transform engines;

    private float speed = 0.0f;

    private Rigidbody m_Rigidbody;

    void Start()
    {
	    m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
	    // Speed
	    if (Input.GetKey(KeyCode.Space)) {
		    speed += settings.GetAcceleration() * Time.fixedDeltaTime;
	    } else {
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
    }
}
