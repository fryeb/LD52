using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Transform enabledReticle;
    public Transform disabledReticle;
    public TextMeshProUGUI score;

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

    public void SetScore(int score)
    {
	    this.score.text = "Score: " + score;
    }
}
