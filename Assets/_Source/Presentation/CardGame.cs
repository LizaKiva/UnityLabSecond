using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardInstance))]
[RequireComponent(typeof(CardView))]
public class CardGame : MonoBehaviour
{
    public static CardGame instance;
    public GameObject cardPrefab;
    private Dictionary<CardInstance, CardView> cardDictionary = new Dictionary<CardInstance, CardView>();
    public List<CardAsset> initalCards = new List<CardAsset>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
        else {
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
        foreach (CardAsset asset in initalCards)
        {
            CreateCard(asset, 0);
        }
    }

    public List<CardInstance> GetCardsInLayout(int layoutId)
    {
        List<CardInstance> cardInLayout = new List<CardInstance>();

        foreach (var card in cardDictionary.Keys)
        {
            if (card.layoutId == layoutId)
            {
                cardInLayout.Add(card);
            }
        }

        return cardInLayout;
    }

    private void CreateCardView(CardInstance cardInstance)
    {
        GameObject cardGo = Instantiate(cardPrefab);
        CardView cardView = cardGo.GetComponent<CardView>();
        cardView.Init(cardInstance);
        cardDictionary.Add(cardInstance, cardView);
    }

    private void CreateCard(CardAsset cardAsset, int layoutId)
    {
        CardInstance cardInstance = new CardInstance(cardAsset);
        cardInstance.MoveToLayout(layoutId);
        CreateCardView(cardInstance);
    }

    public CardView GetCardView(CardInstance cardInstance)
    {
        if (cardDictionary.ContainsKey(cardInstance))
        {
            return cardDictionary[cardInstance];
        }

        return null;
    }
}
