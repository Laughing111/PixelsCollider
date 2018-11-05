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
            play(1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            play(4);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            play(3);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            play(1);
        }
         else if(Input.GetKey(KeyCode.F))
        {
            play(5);
        }
        else
        {
            play(2);
        }


    }


    public void play(int isWalk)
    {
        if(isWalk==1)
        {
            anim.Play("Run");
        }
        else if(isWalk==2)
        {

            anim.Play("Idle");
        }
        else if(isWalk==3)
        {
            anim.Play("Jump");
        }
        else if(isWalk==4)
        {
            anim.Play("Flinch");
        }
        else if(isWalk==5)
        {
            anim.Play("Death");
        }
        
    }
}
