using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    //Player transform
    public Transform playerTransform;

    Vector3 Velocity = Vector3.zero;

    //time
    public float smoothTime = 0.10f;

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

}
