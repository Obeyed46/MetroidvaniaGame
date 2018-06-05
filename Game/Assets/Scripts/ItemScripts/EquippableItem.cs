using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Head,
    Chest,
    Hands,
    Legs,
    Weapon1,
    Weapon2,
    Accessory1,
    Accessory2,
}

[CreateAssetMenu]
public class EquippableItem : Item {

    public int PhysicDEF, FireDEF, EletricDEF, MagicDEF, PoisonDEF, PhysicDamage, FireDamage, EletricDamage, MagicDamage, PoisonDamage, Weight;
    [Space]
    public EquipmentType EquipmentType;
    [Space]
    public Sprite Sprite1, Sprite2, Sprite3;
    [Space]
    public int AnimLayer;

}
