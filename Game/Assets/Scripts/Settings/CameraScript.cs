using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Instance
    public static CameraScript Instance;

    //Player transform
    public Transform playerTransform;

    Vector3 Velocity = Vector3.zero;

    //time
    public float smoothTime = 0.10f;

    //Shake Variables
    public float shakeTimer, shakeAmount;

    //Comes before start
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //Called every frame
    void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(playerTransform.position.x, playerTransform.position.y + 70, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref Velocity, smoothTime);
    }

    //Called every frame
    void Update()
    {
        if(shakeTimer >= 0)
        {
            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
            shakeTimer -= Time.deltaTime;
        }
        
    }


    /////METHODS/////

    public void CameraShake(float shakePWR, float shakeDUR)
    {
        shakeAmount = shakePWR;
        shakeTimer = shakeDUR;
    }
}
