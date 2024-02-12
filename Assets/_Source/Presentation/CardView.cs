using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardInstance))]
public class CardView : MonoBehaviour
{
    private CardInstance cardInstance; 

    public void Init(CardInstance cardInstance)
    {
        this.cardInstance = cardInstance;
    }
}
