using System.Collections.Generic;
using UnityEngine;

namespace _Source.Core.CardLayout {
    public class CardLayout : MonoBehaviour
    {
        public int LayoutId;
        public Vector2 Offset;
        public bool FaceUp;

        private void Update()
        {
            List<_Source.Core.CardInstance.CardInstance> cardsInLayout = _Source.Presentation.CardGame.CardGame.Instance.GetCardsInLayout(LayoutId);
            for (int i = 0; i < cardsInLayout.Count; i++)
            {
                _Source.Core.CardInstance.CardInstance cardInstance = cardsInLayout[i];
                _Source.Presentation.CardView.CardView cardObject = _Source.Presentation.CardGame.CardGame.Instance.GetCardView(cardInstance);
                if (cardObject != null)
                {
                    Transform cardTransform = cardObject.transform;
                    cardTransform.localPosition = new Vector3(i * Offset.x, i * Offset.y, 0f);
                    cardTransform.SetSiblingIndex(cardInstance.cardPosition);

                    _Source.Presentation.CardView.CardView cardView = cardObject.GetComponent<_Source.Presentation.CardView.CardView>();
                    if (cardView != null)
                    {
                        //cardView.Rotate(FaceUp);
                    }
                }
            }
        }
    }
 }
