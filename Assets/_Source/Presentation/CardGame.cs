using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace _Source.Presentation.CardGame
{
    public class CardGame : MonoBehaviour
    {
        public static CardGame instance;
        public static GameObject cardPrefab;
        private static Dictionary<_Source.Core.CardInstance.CardInstance, _Source.Presentation.CardView.CardView> cardDictionary 
            = new Dictionary<_Source.Core.CardInstance.CardInstance, _Source.Presentation.CardView.CardView>();
        public static List<_Source.Core.CardAsset.CardAsset> initalCards = new List<_Source.Core.CardAsset.CardAsset>();

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static CardGame Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<CardGame>();
                }

                return instance;
            }
        }

        public void StartGame()
        {
            foreach (_Source.Core.CardAsset.CardAsset asset in initalCards)
            {
                CreateCard(asset, 0);
            }
        }

        public List<_Source.Core.CardInstance.CardInstance> GetCardsInLayout(int layoutId)
        {
            List<_Source.Core.CardInstance.CardInstance> cardInLayout = new List<_Source.Core.CardInstance.CardInstance>();

            foreach (var card in cardDictionary.Keys)
            {
                if (card.layoutId == layoutId)
                {
                    cardInLayout.Add(card);
                }
            }

            return cardInLayout;
        }

        private void CreateCardView(_Source.Core.CardInstance.CardInstance cardInstance)
        {
            GameObject cardGo = Instantiate(cardPrefab);
            _Source.Presentation.CardView.CardView cardView = cardGo.GetComponent<_Source.Presentation.CardView.CardView>();
            cardView.Init(cardInstance);
            cardDictionary.Add(cardInstance, cardView);
        }

        private void CreateCard(_Source.Core.CardAsset.CardAsset cardAsset, int layoutId)
        {
            _Source.Core.CardInstance.CardInstance cardInstance = new _Source.Core.CardInstance.CardInstance(cardAsset);
            cardInstance.MoveToLayout(layoutId);
            CreateCardView(cardInstance);
        }

        public _Source.Presentation.CardView.CardView GetCardView(_Source.Core.CardInstance.CardInstance cardInstance)
        {
            if (cardDictionary.ContainsKey(cardInstance))
            {
                return cardDictionary[cardInstance];
            }

            return null;
        }
    }
}