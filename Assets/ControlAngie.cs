using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAngie : MonoBehaviour {

    public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		 if(Input.GetKey(KeyCode.A))
        {
            play(true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            play(true);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            play(true);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            play(true);
        }
        else
        {
            play(false);
        }


    }


    public void play(bool isWalk)
    {
        if(isWalk)
        {
            anim.Play("Run");
        }
        else
        {

            anim.Play("Idle");
        }
        
    }
}
