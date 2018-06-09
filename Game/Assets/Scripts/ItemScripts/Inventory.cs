using System;
using System.Collections.Generic;
using UnityEngine;



public class Inventory : MonoBehaviour {

    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    public ItemSlot[] itemSlots;

    public event Action<Item> OnItemRightClickedEvent;

    public static Inventory Instance;
    
    private void Update()
    {
        /*for(int i=0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnRightClickEvent += OnItemRightClickedEvent;

        }*/

       
        
    }

    private void Start()
    {
        /*for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnRightClickEvent += OnItemRightClickedEvent;

        }*/
    }

    private void Awake()
    {
        Instance = this;
    }

    private void OnValidate()
    {
        if (itemsParent != null)
        {
           itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        int i = 0;
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];

        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;

        }
    }

    public bool AddItem(Item item)
    {
        if (IsFull())
        {
            return false;
        }
        else
        {
            items.Add(item);
            UpdateUI();
            return true;
        }
    }

    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            UpdateUI();
            return true;
        }
        return false;

    }

    public bool IsFull()
    {
        return items.Count >= itemSlots.Length;

    }
}
