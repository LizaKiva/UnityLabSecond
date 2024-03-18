using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLayout : MonoBehaviour
{
    public int LayoutId;
    public Vector2 Offset;
    public bool FaceUp;

    private void Update()
    {
        List<CardInstance> cardsInLayout = CardGame.Instance.GetCardsInLayout(LayoutId);
        for (int i = 0; i < cardsInLayout.Count; i++)
        {
            CardInstance cardInstance = cardsInLayout[i];
            CardView cardObject = CardGame.Instance.GetCardView(cardInstance);
            if (cardObject != null)
            {
                Transform cardTransform = cardObject.transform;
                cardTransform.localPosition = new Vector3(i * Offset.x, i * Offset.y, 0f); 
                cardTransform.SetSiblingIndex(cardInstance.cardPosition); 

                CardView cardView = cardObject.GetComponent<CardView>();
                if (cardView != null)
                {
                    //cardView.Rotate(FaceUp);
                }
            }
        }
    }
}
