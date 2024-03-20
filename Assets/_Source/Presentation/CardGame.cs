using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

namespace _Source.Presentation.CardGame
{
    public class CardGame : MonoBehaviour
    {
        public int HandCapacity;
        private static System.Random Random = new System.Random();
        private static CardGame instance;
        public GameObject cardPrefab;
        private static Dictionary<_Source.Core.CardInstance.CardInstance, _Source.Presentation.CardView.CardView> cardDictionary 
            = new Dictionary<_Source.Core.CardInstance.CardInstance, _Source.Presentation.CardView.CardView>();
        public List<_Source.Core.CardAsset.CardAsset> initalCards;

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

        public void Start()
        {
            StartGame();
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
            int id = 0;
            foreach (_Source.Core.CardAsset.CardAsset asset in initalCards)
            {
                CreateCard(asset, 0, id++);
            }

            ShuffleLayout(0);
            StartTurn();
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
            _Source.Presentation.CardView.CardView cardView = cardGo.GetComponent<CardView.CardView>();
            cardView.Init(cardInstance);
            cardDictionary.Add(cardInstance, cardView);
        }

        private void CreateCard(_Source.Core.CardAsset.CardAsset cardAsset, int layoutId, int cardId)
        {
            _Source.Core.CardInstance.CardInstance cardInstance = ScriptableObject.CreateInstance<Core.CardInstance.CardInstance>();
            cardInstance.Init(cardAsset, cardId);
            cardInstance.MoveToLayout(layoutId);
            cardInstance.cardPosition = cardId;

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

        public void RecalculateLayout(int layoutId)
        {
            List<_Source.Core.CardInstance.CardInstance> cards = GetCardsInLayout(layoutId);
            SortedList<int, _Source.Core.CardInstance.CardInstance> positions = new SortedList<int, _Source.Core.CardInstance.CardInstance>();
            foreach (var card in cards)
            {
                positions.Add(card.cardPosition, card);
            }

            int id = 0;
            foreach (var cardInfo in positions)
            {
                cardInfo.Value.cardPosition = id++;
            }
        }

        public void ShuffleLayout(int layoutId)
        {
            List<_Source.Core.CardInstance.CardInstance> cards = GetCardsInLayout(layoutId);
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                _Source.Core.CardInstance.CardInstance value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }

            int id = 0;
            foreach (var card in cards)
            {
                card.cardPosition = id++;
            }
        }

        public void StartTurn()
        {
            List<_Source.Core.CardInstance.CardInstance> deck = GetCardsInLayout(0);
            SortedList<int, _Source.Core.CardInstance.CardInstance> sortedDeck = new SortedList<int, _Source.Core.CardInstance.CardInstance>();
            foreach (var card in deck)
            {
                sortedDeck.Add(-card.cardPosition, card);
            }

            int id = 0;
            for (int handId = 3; handId <= 4; ++handId)
            {
                while (id < sortedDeck.Count && GetCardsInLayout(handId).Count < HandCapacity)
                {
                    sortedDeck.Values[id++].MoveToLayout(handId);
                }

                RecalculateLayout(handId);
            }

            RecalculateLayout(0);
        }
    }
}