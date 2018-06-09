using UnityEngine;
using System;


public class EquipmentPanel : MonoBehaviour {

    public static EquipmentPanel Instance;
    
    [SerializeField] Transform EquipSlotsParent;
    public EquipmentSlot[] EquipSlots;

    public EquippableItem KnightHelmet;


    public event Action<Item> OnItemRightClickedEvent;

    private void Start()
    {
        Instance = this;
        /*for (int i = 0; i < EquipSlots.Length; i++)
        {
            EquipSlots[i].OnRightClickEvent += OnItemRightClickedEvent;

        }*/
    }

    //Called every frame
    void Update()
    {
       /* for (int i = 0; i < EquipSlots.Length; i++)
        {
            EquipSlots[i].OnRightClickEvent += OnItemRightClickedEvent;

        }*/

       /*f (EquipSlots[1].Item.DisableHair == true)
        {
            Character.Instance.Hair.enabled = false;
        }*/
      
    }


    private void OnValidate()
    {
        EquipSlots = EquipSlotsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public bool AddEquipItem(EquippableItem EquipItem, out EquippableItem PreviousItem)
    {
        for (int i = 0; i < EquipSlots.Length; i++)
        {
            if (EquipSlots[i].EquipmentType == EquipItem.EquipmentType)
            {
                PreviousItem = (EquippableItem)EquipSlots[i].Item;
                EquipSlots[i].Item = EquipItem;
                return true;
            }
            
        }
        PreviousItem = null;
        return false;
    }

    public bool RemoveEquipItem(EquippableItem EquipItem)
    {
        for (int i = 0; i < EquipSlots.Length; i++)
        {
            if (EquipSlots[i].Item == EquipItem)
            {
                EquipSlots[i].Item = null;
                return true;
            }

        }
        return false;
    }
}
