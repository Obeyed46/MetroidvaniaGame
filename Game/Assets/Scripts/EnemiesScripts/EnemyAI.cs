using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {


    //Generic variables
    public Animator Anim;
    public Rigidbody2D Rb;
    public Transform target;   //Player transform


    //Movement variables
    public bool FacingRight;
    bool SprintRight, SprintLeft;

	// Use this for initialization
	void Start () {

        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        FacingRight = true;

	}
	


	// Update is called once per frame
	void Update () {

        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            SprintLeft = false;
            SprintRight = false;
        }

	}
    

    //Called every frame
    void FixedUpdate()
    {
        if (SprintRight)
        {
            Rb.velocity = new Vector2(140, Rb.velocity.y);
        }

        if (SprintLeft)
        {
            Rb.velocity = new Vector2(-140, Rb.velocity.y);
        }
    }





    ///////METHODS////////
    
    
    public void Flip()
    {
        FacingRight = !FacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }



    public void AttackSprint()
    {
        if (FacingRight)
        {
            SprintRight = true;
        }
        else if (!FacingRight)
        {
            SprintLeft = true;

        }

    }


    public void EndAttackSprint()
    {
        if (FacingRight)
        {
            SprintRight = false;
        }
        else if (!FacingRight)
        {
            SprintLeft = false;

        }


    }
}
