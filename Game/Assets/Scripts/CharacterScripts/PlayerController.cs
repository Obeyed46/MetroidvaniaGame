using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance;
    //Movement Variables//

    //Walk_Run
    public float MaxSpeed, RunningSpeed;
    Rigidbody2D MyRB;
    Animator MyAnim;
    public Collider2D coll;
    bool FacingRight, CanMove;

    //Jump
    bool Grounded;
    float GroundCheckRadius = 10;
    public LayerMask GroundLayer;
    public Transform GroundCheck;
    public float JumpHeight; //JumpHeight must be a very high number


    //Attacking Variables
    int noOfClicks;
    bool CanClick;
    public bool SprintRight, SprintLeft, Rolling, CanCollide;
    public float coolDown = 0.6f, Timer2, Timer3;

    



    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {

        MyRB = GetComponent<Rigidbody2D>();
        MyAnim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        FacingRight = true;
        noOfClicks = 0;
        Timer2 = 0;
        Timer2 = 0;
        CanClick = true;
        CanMove = true;
        CanCollide = true;





    }

    // Update is called once per frame
    void Update()
    {
  
        


        if (MyRB.bodyType == RigidbodyType2D.Dynamic)
        {
            if (Grounded && Input.GetKeyDown("space") || Grounded && Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                Grounded = false;
                MyRB.AddForce(new Vector2(0, JumpHeight));
                MyAnim.SetBool("IsGrounded", Grounded);

            }
         

            if (MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                SprintRight = false;
                SprintLeft = false;
                CanClick = true;
    
            }

            
       

            if (MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Run") || MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Run1"))
            {
                Timer2 = 0;
                Timer3 = 0;
            }

            if (Timer2 > 0)
            {
                Timer2 -= Time.deltaTime;
                CanClick = false;

            }

            if (Timer3 > 0)
            {
                Timer3 -= Time.deltaTime;

            }

            if (Timer2 < 0)
            {
                Timer2 = 0;
            }

            if (Timer3 < 0)
            {
                Timer3 = 0;
            }


            if(MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Run1") == false) { 

            if (Input.GetMouseButtonDown(0) && StatsSystem.Instance.CurrentStamina > 10 && Timer2 == 0 && Timer3 == 0 && CanClick|| Input.GetKeyDown(KeyCode.Joystick1Button2) && StatsSystem.Instance.CurrentStamina > 0 && Timer2 == 0 && Timer3 == 0 && CanClick)
            {
                MyAnim.SetTrigger("Attacking");
                StatsSystem.Instance.CurrentStamina -= 30;
                CanClick = false;


            }
            else if (Input.GetMouseButtonDown(0) && StatsSystem.Instance.CurrentStamina > 10 && Timer2 > 0 && Timer3 == 0|| Input.GetKeyDown(KeyCode.Joystick1Button2) && StatsSystem.Instance.CurrentStamina > 0 && Timer2 > 0 && Timer3 == 0)
            {
                MyAnim.SetTrigger("Attacking2");
                StatsSystem.Instance.CurrentStamina -= 30;
                //Timer2 = 0;
                CanClick = false;

              
            }
            else if (Input.GetMouseButtonDown(0) && StatsSystem.Instance.CurrentStamina > 10 && Timer3 > 0 && Timer2 == 0 || Input.GetKeyDown(KeyCode.Joystick1Button2) && StatsSystem.Instance.CurrentStamina > 0 && Timer3 > 0 && Timer2 == 0)
            {
                MyAnim.SetTrigger("Attacking3");
                StatsSystem.Instance.CurrentStamina -= 30;
                CanClick = true;
                
                
         
            }
            }

            if (MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Run") || MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Run1") || MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {

                if (Input.GetKeyDown(KeyCode.B) && Timer2 == 0 && Timer3 == 0 || Input.GetKeyDown(KeyCode.Joystick1Button1) && Timer2 == 0 && Timer3 == 0)
                {
                    MyAnim.SetTrigger("Rolling");

                }

            }

            if (MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Roll") || MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
            {
                CanMove = false;
            }
            else
            {
                CanMove = true;
            }

            

            if (MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
            {
                Physics2D.IgnoreLayerCollision(0, 9,true);

            }
            else
            {
                Physics2D.IgnoreLayerCollision(0, 9, false);
            }

            
        


        }
        else if (MyRB.bodyType == RigidbodyType2D.Static)
        {
            MyAnim.SetBool("IsGrounded", true);
        }



    }


    //Called every frame
    void FixedUpdate()
    {

        if (MyRB.bodyType == RigidbodyType2D.Dynamic)
        {
            MyAnim.SetBool("IsRunning", false);
            float move = Input.GetAxis("Horizontal");
            MyAnim.SetFloat("Speed", Mathf.Abs(move));

            if (CanMove)
            {
                MyRB.velocity = new Vector2(move * MaxSpeed, MyRB.velocity.y);
                if (move > 0 && !FacingRight)
                {
                    Flip();
                }
                else if (move < 0 && FacingRight)
                {
                    Flip();
                }
            }

            
            
            StatsSystem.Instance.CurrentStamina += 2;
            
            if (Input.GetKey(KeyCode.LeftShift) && move != 0 && StatsSystem.Instance.CurrentStamina > 0 || Input.GetKey(KeyCode.Joystick1Button4) && move != 0 && StatsSystem.Instance.CurrentStamina > 0)
            {

                MyRB.velocity = new Vector2(move * RunningSpeed, MyRB.velocity.y);
                MyAnim.SetBool("IsRunning", true);
                StatsSystem.Instance.CurrentStamina -= 3;

            }

            //Cheking if Grounded
            Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);

            MyAnim.SetFloat("VerticalSpeed", MyRB.velocity.y);
            MyAnim.SetBool("IsGrounded", Grounded);

            if (SprintRight)
            {
                MyRB.velocity = new Vector2(100, MyRB.velocity.y);
            }

            if (SprintLeft)
            {
                MyRB.velocity = new Vector2(-100, MyRB.velocity.y);
            }
            
            if (Rolling)
            {
                if (FacingRight)
                {
                    MyRB.velocity = new Vector2(250, MyRB.velocity.y);
                }
                else if (!FacingRight)
                {
                    MyRB.velocity = new Vector2(-250, MyRB.velocity.y);
                }
               
            }



        }

    }

    void Flip()
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

    public void StartRolling()
    {
        Rolling = true;
    }
    
    public void EndRolling()
    {
        Rolling = false;
    }

    public void Attack2()
    {
        Timer2 = coolDown;
    }

    public void Attack3()
    {
        Timer3 = coolDown;
    }

    public void Attack2End()
    {
        Timer2 = 0;
    }

    public void Attack3End()
    {
        Timer3 = 0;
    }

    public void doNotPlay()
    {
        CanClick = false;
    }

   public void EnableAttackCollision()
    {
        CanCollide = true;
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }

   

 

    



    
    

   
   
   

    
}
