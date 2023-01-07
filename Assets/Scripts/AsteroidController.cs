using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AsteroidController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
	    m_Rigidbody = GetComponent<Rigidbody>();
	    m_Rigidbody.useGravity=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
