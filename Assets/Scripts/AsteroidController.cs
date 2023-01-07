using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AsteroidController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    public int value = 10;

    // Start is called before the first frame update
    void Start()
    {
	    m_Rigidbody = GetComponent<Rigidbody>();
	    m_Rigidbody.useGravity=false;
    }
}
