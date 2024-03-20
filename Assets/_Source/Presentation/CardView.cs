using _Source.Core.CardInstance;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Presentation.CardView
{
    public class CardView : MonoBehaviour
    {
        public _Source.Core.CardInstance.CardInstance cardInstance;
        
        private SpriteRenderer _spriteRenderer;

        public void Init(_Source.Core.CardInstance.CardInstance cardInstance)
        {
            this.cardInstance = cardInstance;

            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.size = new Vector2(1, 1);
            _spriteRenderer.sortingOrder = cardInstance.cardPosition + 1;
        }

        public void Rotate(bool faceUp)
        {
            if (!faceUp)
            {
                _spriteRenderer.sprite = cardInstance.cardAsset.backSprite;
                _spriteRenderer.size = new Vector2(1, 1);
                _spriteRenderer.sortingOrder = cardInstance.cardPosition + 1;
            }
            else
            {
                _spriteRenderer.sprite = cardInstance.cardAsset.cardSprite;
                _spriteRenderer.size = new Vector2(1, 1);
                _spriteRenderer.sortingOrder = cardInstance.cardPosition + 1;
            }
        }

        public void PlayCard(int targetLayout)
        {
            this.cardInstance.MoveToLayout(targetLayout);
            CardGame.CardGame.Instance.StartTurn();
        }


        public void OnMouseDown()
        {
            if (this.cardInstance.layoutId == 3 || this.cardInstance.layoutId == 4)
            {
                PlayCard(1);
            } else if (this.cardInstance.layoutId == 1)
            {
                PlayCard(2);
            }
        }

    }
}
