using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Transform enabledReticle;
    public Transform disabledReticle;

    // Start is called before the first frame update
    void Start()
    {
	    Debug.Assert(instance == null);
	    instance = this;
    }

    public void SetReticleEnabled(bool enabled) 
    {
	    enabledReticle.gameObject.SetActive(enabled);
	    disabledReticle.gameObject.SetActive(!enabled);
    }
}
