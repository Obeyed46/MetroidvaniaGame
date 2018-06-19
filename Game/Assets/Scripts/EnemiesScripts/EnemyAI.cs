using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {


    //Generic variables
    public Animator Anim;
    public Rigidbody2D Rb;
    public Transform target;//Player transform
    public Collider2D coll;
    public GameObject enemy;

    //HealthBars variables
    public SpriteRenderer emptyBar, fullBar, yellowBar;
    
    //Movement variables
    public float AggroDistance, AttackDistance, speed;
    public bool FacingRight;
    bool SprintRight, SprintLeft, CanFlip, Chase;
    
    //Attacking variables
    public float timer, timer2, coolDown = 0.7f;      //Timer = AttackDelay, Timer2 = delay between attack and run
    public int NumbOfPatterns; //Number attacks of the mob
    public Collider2D weaponColl;

    //Stats
    public int MaxHealth, CurrentHealth, Poise, PhysicDEF, FireDEF, EletricDEF, MagicDEF, PoisonDEF;  //DEF stats
    public int PhysicDamage, FireDamage, EletricDamage, MagicDamage, PoisonDamage; //Offensive stats

	// Use this for initialization
	void Start () {

        Anim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        FacingRight = false;
        CanFlip = true;
        Chase = true;
        CurrentHealth = MaxHealth;
        emptyBar.enabled = false;
        fullBar.enabled = false;
        yellowBar.enabled = false;
        timer = 0;
        timer2 = 0;

	}
	


	// Update is called once per frame
	void Update ()
    {
        
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") || Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {
            Chase = false;
            Anim.SetBool("Attacking", false);
            Anim.SetBool("Attacking2", false);
            Anim.SetBool("Attacking3", false);
            CanFlip = false;
        }
        else
        {
            Chase = true;
            CanFlip = true;
        }


        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            SprintLeft = false;
            SprintRight = false;
            Anim.SetBool("Attacking", false);
            Anim.SetBool("Attacking2", false);
            Anim.SetBool("Attacking3", false);
            Rb.velocity = new Vector2(0, 0);
        }


        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if(timer < 0)
        {
            timer = 0;
        }

        if(timer2 > 0)
        {
            timer2 -= Time.deltaTime;
        }

        if(timer2 < 0)
        {
            timer2 = 0;
        }


        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
        }

        if(CurrentHealth < MaxHealth)
        {
            emptyBar.enabled = true;
            fullBar.enabled = true;
            yellowBar.enabled = true;
        }

        if(yellowBar.transform.localScale.x > fullBar.transform.localScale.x)
        {
            yellowBar.transform.localScale = new Vector3(yellowBar.transform.localScale.x - 0.003f, yellowBar.transform.localScale.y, yellowBar.transform.localScale.z);
        }

        if(fullBar.transform.localScale.x < 0)
        {
            fullBar.transform.localScale = new Vector3(0, fullBar.transform.localScale.y, fullBar.transform.localScale.z);
            yellowBar.transform.localScale = new Vector3(0, yellowBar.transform.localScale.y, yellowBar.transform.localScale.z);
        }

        if(CurrentHealth <= 0)
        {
            Destroy(enemy);
        }
	}
    

    //Called every frame
    void FixedUpdate()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < AggroDistance && Vector2.Distance(transform.position, target.position) > AttackDistance && Chase && timer2 == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
                Anim.SetFloat("speed", 1);
            }
            else if (Vector2.Distance(transform.position, target.position) < 50)
            {
                Anim.SetFloat("speed", 0);
                if (timer == 0)
                {
                    Attack();
                }
            }

            if (transform.position.x > target.position.x && FacingRight && CanFlip)
            {
                Flip();
            }

            if (transform.position.x < target.position.x && !FacingRight && CanFlip)
            {
                Flip();
            }
        }
        else if(target == null)
        {
            Chase = false;
            Anim.SetBool("Attacking", false);
            Anim.SetBool("Attacking2", false);
            Anim.SetBool("Attacking3", false);
            CanFlip = false;
            SprintLeft = false;
            SprintRight = false;
            Rb.velocity = new Vector2(0, 0);
        }

        if (SprintRight)
        {
            Rb.velocity = new Vector2(330, Rb.velocity.y);
        }
        else if (SprintLeft)
        {
            Rb.velocity = new Vector2(-330, Rb.velocity.y);
        }
        else
        {
            Rb.velocity = new Vector2(0, Rb.velocity.y);
        }

        if (Physics2D.IsTouching(Character.Instance.weaponCollider, coll) && PlayerController.Instance.CanCollide)
        {
            Physics2D.IgnoreLayerCollision(9, 10, true);
            TakeDamage();
        }

        if(Physics2D.IsTouching(weaponColl, Character.Instance.playerCollider))
        {
            Physics2D.IgnoreLayerCollision(0, 11, true);
            StatsSystem.Instance.TakeDamage(PhysicDamage);
        }

    }





    ///////METHODS////////
    
    
    public void Attack()
    {
        int randInt = new int();
        randInt = Random.Range(1, NumbOfPatterns + 1);
        switch (randInt)
        {
              case 1:
                  Anim.SetBool("Attacking", true);
                  break;
              case 2:
                  Anim.SetBool("Attacking2", true);
                  break;
              case 3:
                  Anim.SetBool("Attacking3", true);
                  break; 
              default:
                  break;
        }
            
        Chase = false;
    }

    public void TakeDamage()
    {
        EquippableItem PlayerWeapon;
        PlayerWeapon = new EquippableItem();
        if(EquipmentPanel.Instance.EquipSlots[4].Item != null && EquipmentPanel.Instance.EquipSlots[4].Item is EquippableItem)
        {
            PlayerWeapon = (EquippableItem)EquipmentPanel.Instance.EquipSlots[4].Item;
            CurrentHealth -= PlayerWeapon.PhysicDamage;
        }
        else
        {
            CurrentHealth -= CreatePlayer.Instance.Weapon1Dam;
        }

        float wDam = PlayerWeapon.PhysicDamage, MaxHeatlh = MaxHealth;
        fullBar.transform.localScale = new Vector3(fullBar.transform.localScale.x - (wDam / MaxHealth), fullBar.transform.localScale.y, fullBar.transform.localScale.z);



    }

    public void Flip()
    {
        FacingRight = !FacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }

    public void AttackDelay()
    {
        timer = coolDown;

    }

    public void RunDelayAfterAttack()
    {
        timer2 = 0.5f;
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

    public void EnableAttackCollision()
    {
        Physics2D.IgnoreLayerCollision(0, 11, false);
    }
}
