using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WormholeController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
	    m_Rigidbody = GetComponent<Rigidbody>();
	    m_Rigidbody.isKinematic = true;
	    m_Rigidbody.useGravity = false;
    }

    void OnCollisionEnter(Collision collision)
    {
	    // TODO: Player should die if they hit the wormhole

	    AsteroidController asteroid = collision.gameObject.GetComponent<AsteroidController>();
	    if (asteroid)
	    {
		    GameManager.instance.AddScore(asteroid.value);
		    Destroy(asteroid.gameObject);
	    }
    }
}
