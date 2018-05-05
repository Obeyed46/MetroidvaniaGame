using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairPanelScript : MonoBehaviour
{
    
    public SpriteRenderer Hair, SelectedHair, SelectedHairColor;
    public SpriteRenderer[] HairSpritesCL;
    public Sprite[] HairSprites;
    public Color[] Colors;
    public int WColorH, WHair;




    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       for (int i = 0; i < HairSprites.Length; i++)
        {
            if (i==WHair)
            {
                Hair.sprite = HairSprites[i];
                SelectedHair.sprite = HairSprites[i];
            }
        }
       
       for (int i=0; i < Colors.Length; i++)
        {
            if (i == WColorH)
            {
                Hair.color = Colors[i];
                SelectedHair.color = Colors[i];
                SelectedHairColor.color = Colors[i];
                for (int j=0; j < HairSpritesCL.Length; j++)
                {
                    HairSpritesCL[j].color = Colors[i];
                }

            }
        }
    }

  public void ChangeHairType(int Index)
    {
        if (Index < HairSprites.Length)
        {
            WHair = Index;
        }
    }

  public void ChangeHairColor(int Index)
    {
        if (Index < Colors.Length)
        {
            WColorH = Index;
            
        }
    }
}
