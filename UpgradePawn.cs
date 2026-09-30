using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Upgrade Pawn",menuName = "Inventory/Upgrade")]
public class UpgradePawn : ScriptableObject
{
    public UpgradeType upgradeType;
    public string UpgradeName;
    public int[] prices;
    public int[] values;
}



public enum UpgradeType 
{
    ShortPawn,
    LongPawn
}