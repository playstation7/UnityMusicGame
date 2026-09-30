using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class LevelDetail : ScriptableObject
{
    public int levelID;
    public Sprite background;
    public AudioClip audioClip;
    public string description;
    public int starsToUnlock;
    public int difficulty;
    public WeightedType[] weightedTypes;
    public int[] notesToGetStars;
}

public enum PawnTypes 
{
    ShortPawn,
    LongPawn,
    LongMultyTapPawn,
    ShortMissPawn,
    ShortBonusPawn
}



[System.Serializable]
public class WeightedType 
{
    public PawnTypes type;
    public float weight = 1f;
}
