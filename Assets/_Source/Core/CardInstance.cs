using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardAsset))]
public class CardInstance : MonoBehaviour
{
    public CardAsset cardAsset;
    public int layoutId;
    public int cardPosition;

    public CardInstance(CardAsset cardAsset)
    {
        this.cardAsset = cardAsset;
    }

    public void MoveToLayout(int newLayout)
    {
        layoutId = newLayout;
    }
}
