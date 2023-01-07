using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTarget;
    public float followStrength = 1.0f;
    public float turnStrength = 1.0f;
    private Vector3 offset;

    void FixedUpdate()
    {
	    // Position
	    transform.position = Vector3.Lerp(transform.position, followTarget.position, Time.fixedDeltaTime * followStrength);

	    // Direction
	    transform.rotation = Quaternion.Slerp(transform.rotation, followTarget.rotation, Time.fixedDeltaTime * turnStrength);
    }
}
