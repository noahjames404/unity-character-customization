using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CharacterBody")]
public class CharacterBody : ScriptableObject
{
    public PartsList Armor;
    public PartsList Body;
    public PartsList Boot;
    public PartsList Eyes;
    public PartsList Gloves;
    public PartsList Hair;
    public PartsList Top;
    public PartsList Bottom;
    public PartsList Accessory;
}
