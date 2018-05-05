using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingSkinColour : MonoBehaviour {

    public GameObject SkinPanel, HairPanel, EyesPanel;
    public SpriteRenderer[] BodyParts;
    public int WColor;
    public SpriteRenderer SelectedButton;
    public Color[] colors;
    

    // Use this for initialization
    void Start () {
        SkinPanel.SetActive(false);
        HairPanel.SetActive(false);
        EyesPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < colors.Length; i++)
        {
            if (i == WColor)
            {
                SelectedButton.color = colors[i];
                for (int j=0;j< BodyParts.Length; j++)
                {
                    BodyParts[j].color = colors[i];
                }
            }
        }
        }


    public void ChangePanel(int index)
    {
        switch (index)
        {
            case 0:
                SkinPanel.SetActive(true);
                HairPanel.SetActive(false);
                EyesPanel.SetActive(false);
                break;
            case 1:
                SkinPanel.SetActive(false);
                HairPanel.SetActive(true);
                EyesPanel.SetActive(false);
                break;
            case 2:
                SkinPanel.SetActive(false);
                HairPanel.SetActive(false);
                EyesPanel.SetActive(true);
                break;
            default:
                SkinPanel.SetActive(false);
                HairPanel.SetActive(false);
                EyesPanel.SetActive(false);
                break;

        }
    }

    public void ChangeColor(int index)
    {
        WColor = index;
    }
}
