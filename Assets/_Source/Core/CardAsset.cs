using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Core.CardAsset
{
    [CreateAssetMenu(fileName = "NewCardAsset", menuName = "CardAsset")]
    public class CardAsset : ScriptableObject
    {
        public string cardName;
        public Color cardColor;
        public Sprite cardSprite;
        public Sprite backSprite;

        public CardAsset(string cardName, Color cardColor, Sprite cardSprite, Sprite backSprite)
        {
            this.cardName = cardName;
            this.cardColor = cardColor;
            this.cardSprite = cardSprite;
            this.backSprite = backSprite;
        }
    }
}
