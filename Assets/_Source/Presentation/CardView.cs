using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CardInstance))]
public class CardView : MonoBehaviour
{
    public CardInstance cardInstance;

    public void Init(CardInstance instance)
    {
        this.cardInstance = instance;
    }

}
