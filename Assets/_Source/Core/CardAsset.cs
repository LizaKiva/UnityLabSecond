using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card Asset", menuName = "Card Game/Card Asset")]
public class CardAsset : ScriptableObject
{
    public string cardName;
    public Color cardColor;
    public Sprite cardSprite;
}