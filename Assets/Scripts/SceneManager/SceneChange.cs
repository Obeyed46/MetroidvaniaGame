using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour {

    public void ChangeScene(int index)
    {
        switch (index)
        {
            case 0:
                SceneManager.LoadScene("SelectingStartingClass");
                break;
            case 1:
                SceneManager.LoadScene("Tutorial");
                break;
            default:
                break;


        }



    }
      

   
}
