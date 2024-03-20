using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Core.CardInstance
{
    public class CardInstance : ScriptableObject
    {
        public _Source.Core.CardAsset.CardAsset cardAsset;
        public int layoutId;
        public int cardPosition;

        private int id;

        public void Init(_Source.Core.CardAsset.CardAsset cardAssetVal, int idVal)
        {
            cardAsset = cardAssetVal;
            id = idVal;
        }

        public void MoveToLayout(int newLayout)
        {
            int oldLayout = layoutId;
            cardPosition = _Source.Presentation.CardGame.CardGame.Instance.GetCardsInLayout(newLayout).Count;
            layoutId = newLayout;

            _Source.Presentation.CardGame.CardGame.Instance.RecalculateLayout(layoutId);
            _Source.Presentation.CardGame.CardGame.Instance.RecalculateLayout(oldLayout);
        }
    }
}
