using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Card
{
    public GameObject cardObject; 
    public bool isActive; 

    public Card(GameObject obj, bool active)
    {
        cardObject = obj;
        isActive = active;
    }

    public void UpdateCardVisual()
    {
        Image cardImage = cardObject.GetComponent<Image>();
        if (isActive)
            cardImage.color = Color.white;
        else
            cardImage.color = Color.gray;

    }
}

public class Books : MonoBehaviour
{
    [SerializeField] List<Card> books = new();

    private void Update()
    {
        foreach (var card in books)
        {          
            card.UpdateCardVisual();
        }
    }
}

