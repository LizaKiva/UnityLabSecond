using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Core.CardInstance
{
    public class CardInstance : MonoBehaviour
    {
        public _Source.Core.CardAsset.CardAsset cardAsset;
        public int layoutId;
        public int cardPosition;

        public CardInstance(_Source.Core.CardAsset.CardAsset cardAsset)
        {
            this.cardAsset = cardAsset;
        }

        public void MoveToLayout(int newLayout)
        {
            layoutId = newLayout;
        }
    }
}
