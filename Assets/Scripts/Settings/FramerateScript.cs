using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateScript : MonoBehaviour {

    FramerateScript Instance;

    //Comes before start
    void Awake()
    {
        Application.targetFrameRate = 300;
    }

    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

}
