using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesPanelScript : MonoBehaviour {

    public SpriteRenderer EyesType, Pupil, SelectedEyesType, SelectedColor;
    public SpriteRenderer[] Pupils;
    public Sprite[] EyesTypes;
    public Color[] Colors;
    public int WColor, WEyesType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        for (int i=0; i < EyesTypes.Length; i++)
        {
            if (i == WEyesType)
            {
                EyesType.sprite = EyesTypes[i];
                SelectedEyesType.sprite = EyesTypes[i];            }
        }

        for (int i=0; i < Colors.Length; i++)
        {
            if (i == WColor)
            {
                Pupil.color = Colors[i];
                SelectedColor.color = Colors[i];
                for (int j=0; j < Pupils.Length; j++)
                {
                    Pupils[j].color = Colors[i];
                }

            }
        }
	}

    public void ChangeEyesType(int index)
    {
        if (index < EyesTypes.Length)
        {
            WEyesType = index;
        }
    }

    public void ChangePupilColor(int Index)
    {
        if (Index < Colors.Length)
        {
            WColor = Index; 
        }
    }
}
