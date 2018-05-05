using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenù : MonoBehaviour {

    public Canvas inventory;
    InventoryMenù Instance;

	// Use this for initialization
	void Start () {
        Instance = this;
        DontDestroyOnLoad(this);
	}
	

    private void OnLevelWasLoaded(int level)
    {
        if (level == 2)
        {
            inventory.renderMode = RenderMode.ScreenSpaceOverlay;
        }
    }
}
