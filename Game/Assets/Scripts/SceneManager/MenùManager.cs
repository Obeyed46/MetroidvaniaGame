using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenùManager : MonoBehaviour {

    public Canvas InventoryMenu, StatsMenu;
    MenùManager Instance;

	// Use this for initialization
	void Start () {

        Instance = this;
        DontDestroyOnLoad(this);
        InventoryMenu.enabled = false;
        StatsMenu.enabled = false;

    }

    // Update is called once per frame
    void Update() {


        if (InventoryMenu.renderMode == RenderMode.ScreenSpaceOverlay && StatsMenu.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            if (Input.GetKeyDown(KeyCode.I) && StatsMenu.enabled == false)
            {
                InventoryMenu.enabled = true;

            }

            /*if (Input.GetKeyDown(KeyCode.I) && InventoryMenu.enabled == true)
            {
                InventoryMenu.enabled = false;


            }*/

            if (Input.GetKeyDown(KeyCode.H) && InventoryMenu.enabled == false)
            {
                StatsMenu.enabled = true;

            }

           /* if (Input.GetKeyDown(KeyCode.H) && StatsMenu.enabled == true)
            {
                StatsMenu.enabled = false;

            }*/

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                InventoryMenu.enabled = false;
                StatsMenu.enabled = false;

            }

        }

    }
}
