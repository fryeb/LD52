using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
	    Debug.Assert(instance == null);
	    instance = this;
    }

    public void AddScore(int score)
    {
	    this.score += score;
    }

    // Update is called once per frame
    void Update()
    {
	    UIController.instance.SetScore(this.score);
    }
}
