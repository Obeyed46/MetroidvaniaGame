using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel EquipPanel;

    public static InventoryManager Instance;

    public EquippableItem[] KnightItems;

    private void Start()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        EquipPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
    }

    void Awake()
    {
        Instance = this;
    }



    public void SetKnightItems()
    {
        for(int i = 0; i < KnightItems.Length; i++)
        {
            EquipFromInventory(KnightItems[i]);
        }
    }

    public void EquipFromInventory(Item Item)
    {
        if (Item is EquippableItem)
        {
            Equip((EquippableItem)Item);
        }

    }

    public void UnequipFromEquipPanel(Item item)
    {
        if (item is EquippableItem)
        {
            Unequip((EquippableItem)item);
        }

    }


    public void Equip(EquippableItem EquipItem)
    {
        if (inventory.RemoveItem(EquipItem))
        {
            
            EquippableItem previousItem;
            if (EquipPanel.AddEquipItem(EquipItem, out previousItem))
            {
                switch (EquipItem.EquipmentType)
                {
                    case EquipmentType.Head:
                        Character.Instance.HeadSprite.sprite = EquipItem.Icon;
                        if(EquipItem.DisableHair == true)
                        {
                            Character.Instance.Hair.enabled = false;
                        }
                        break;
                    case EquipmentType.Chest:
                        Character.Instance.ChestSprite.sprite = EquipItem.Sprite1;
                        Character.Instance.ChestSprite1.sprite = EquipItem.Sprite2;
                        Character.Instance.ChestSprite2.sprite = EquipItem.Sprite3;
                        break;
                    case EquipmentType.Hands:
                        Character.Instance.HandsSprite1.sprite = EquipItem.Sprite1;
                        Character.Instance.HandsSprite2.sprite = EquipItem.Sprite2;
                        break;
                    case EquipmentType.Weapon1:
                        Character.Instance.Weapon1Sprite.sprite = EquipItem.Icon;
                        CreatePlayer.Instance.Weapon1Dam = EquipItem.PhysicDamage + EquipItem.FireDamage + EquipItem.EletricDamage + EquipItem.PoisonDamage;
                        break;
                    case EquipmentType.Legs:
                        Character.Instance.LegsSprite1.sprite = EquipItem.Sprite1;
                        Character.Instance.LegsSprite2.sprite = EquipItem.Sprite2;
                        Character.Instance.LegsSprite3.sprite = EquipItem.Sprite3;
                        break;
                }
                if(EquipItem.AnimLayer != 0)
                {
                    Character.Instance.Anim.SetLayerWeight(EquipItem.AnimLayer, 1.0f);

                }
                CreatePlayer.Instance.PhysicDEF += EquipItem.PhysicDEF;
                CreatePlayer.Instance.FireDEF += EquipItem.FireDEF;
                CreatePlayer.Instance.EletricDEF += EquipItem.EletricDEF;     //Adding new item's values
                CreatePlayer.Instance.PoisonDEF += EquipItem.PoisonDEF;
                CreatePlayer.Instance.Weight += EquipItem.Weight;
                //CreatePlayer.Instance.UpdateUI();
                if (previousItem != null)
                {
                    CreatePlayer.Instance.PhysicDEF -= previousItem.PhysicDEF;
                    CreatePlayer.Instance.FireDEF -= previousItem.FireDEF;
                    CreatePlayer.Instance.EletricDEF -= previousItem.EletricDEF;      //Removing previous item's values
                    CreatePlayer.Instance.PoisonDEF -= previousItem.PoisonDEF;
                    CreatePlayer.Instance.Weight -= previousItem.Weight;
                    if(previousItem.AnimLayer != 0)
                    {
                        Character.Instance.Anim.SetLayerWeight(previousItem.AnimLayer, 0.0f);
                    }
                    inventory.AddItem(previousItem);
                    

                }
                CreatePlayer.Instance.UpdateUI();

            }
            else
            {
                inventory.AddItem(previousItem);
            }
        }


    }

    public void Unequip(EquippableItem equipItem)
    {

        if(!inventory.IsFull() && EquipPanel.RemoveEquipItem(equipItem))
        {
            switch (equipItem.EquipmentType)
            {
                case EquipmentType.Weapon1:
                    CreatePlayer.Instance.SetHandDamage();
                    Character.Instance.Weapon1Sprite.sprite = null;
                    break;
                case EquipmentType.Head:
                    Character.Instance.Hair.enabled = true;
                    Character.Instance.HeadSprite.sprite = null;
                    Character.Instance.Anim.SetLayerWeight(1, 0.0f);
                    if (equipItem.DisableHair == false)
                    {
                        Character.Instance.Hair.enabled = true;
                    }
                    break;
                case EquipmentType.Chest:
                    Character.Instance.ChestSprite.sprite = null;
                    Character.Instance.ChestSprite1.sprite = null;
                    Character.Instance.ChestSprite2.sprite = null;
                    break;
                case EquipmentType.Legs:
                    Character.Instance.LegsSprite1.sprite = null;
                    Character.Instance.LegsSprite2.sprite = null;
                    Character.Instance.LegsSprite3.sprite = null;
                    break;
                case EquipmentType.Hands:
                    Character.Instance.HandsSprite1.sprite = null;
                    Character.Instance.HandsSprite2.sprite = null;
                    break;
                default:
                    break;



            }
            if (equipItem.AnimLayer != 0)
            {
                Character.Instance.Anim.SetLayerWeight(equipItem.AnimLayer, 0.0f);

            }
            CreatePlayer.Instance.PhysicDEF -= equipItem.PhysicDEF;
            CreatePlayer.Instance.FireDEF -= equipItem.FireDEF;
            CreatePlayer.Instance.EletricDEF -= equipItem.EletricDEF;
            CreatePlayer.Instance.PoisonDEF -= equipItem.PoisonDEF;
            CreatePlayer.Instance.Weight -= equipItem.Weight;
            CreatePlayer.Instance.UpdateUI();
            inventory.AddItem(equipItem);

        }

    }

}
