using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler {

    [SerializeField] Image image;
    public Text NumbOfItems;

    private Item _item;

    public event Action<Item> OnRightClickEvent;

    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                image.enabled = false;
            }
            else
            { 
                image.sprite = _item.Icon;
                image.enabled = true;
            }
        }

    }

    void Start()
    {
        NumbOfItems = GetComponentInChildren<Text>();
    }

    void FixedUpdate()
    {
        if(_item is ConsumableItem)
        {
            NumbOfItems.enabled = true;
            ConsumableItem help;
            help = (ConsumableItem)_item;
            NumbOfItems.text = help.numbOfItems.ToString();
            if(help.numbOfItems == 0)
            {
                _item = null;
            }
        }
        else
        {
            NumbOfItems.enabled = false;
        }

        if (_item == null)
        {
            image.enabled = false;
        }
        else
        {
            image.enabled = true;
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if(Item != null && OnRightClickEvent != null)
            {
                OnRightClickEvent(Item);

            }

        }
    }

    protected virtual void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }
    

}
