using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour {
 
    //General
    public Rigidbody2D MyRB;
    public Animator Anim;
    
    //Instance
    public static Character Instance;

    //Sprites
    public SpriteRenderer HeadSprite, ChestSprite,ChestSprite1,ChestSprite2, HandsSprite1,HandsSprite2, LegsSprite1,LegsSprite2,LegsSprite3, Weapon1Sprite, Weapon2Sprite, Accessory1Sprite, Accessory2Sprite;
    public SpriteRenderer Hair;

    //Colliders
    public BoxCollider2D weaponCollider;
    public BoxCollider2D playerCollider;
    public BoxCollider2D shieldCollider;

    //Effects
    public GameObject bloodEffect, shieldHitEffect;


    public static string PlayerName { get; set; }
    public static int PlayerLevel { get; set; }
    public static BaseClass PlayerClass { get; set; }

    public static int Health { get; set; }
    public static int Stamina { get; set; }
    public static int Mana { get; set; }
    public static int Strength { get; set; }
    public static int Skill { get; set; }
    public static int Knowledge { get; set; }


    //Comes before Start
    void Awake()
    {
        

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    // Use this for initialization
    void Start () {
        MyRB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        Physics2D.IgnoreLayerCollision(8, 10);
    }
		
	


    //On changing scene
    private void OnLevelWasLoaded(int Index)
    {
        switch (Index)
        {
            case 0:
                break;
            case 1:
                MyRB.transform.position = new Vector2(-132, 39);
                break;
            case 2:
                MyRB.bodyType = RigidbodyType2D.Dynamic;
                break;
            default:
                break;


        }
    }

    
        
           
    


    






}
