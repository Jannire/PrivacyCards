using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardLogic : MonoBehaviour
{
    public bool isSelected;

    void OnMouseDown()
    {
        if (GameManager.Instance.humanTurn == true)
        {
            
            //Debug.Log("Estado: " + isSelected);
            //Debug.Log("Carta: " + transform.parent.gameObject);
            if (transform.parent.gameObject.name.Contains("Card"))
            {
                //Debug.Log("Este script --> " + transform.parent.gameObject);
                //Debug.Log("En Cardmanager -->" + CardManager.Instance.selectedCard);
                if (CardManager.Instance.selectedCard == transform.parent.gameObject)
                {
                    //Debug.Log("Deseleccionar");
                    isSelected = false;
                    CardManager.Instance.BajartodasCards();
                    CardManager.Instance.IsCardSelected = false;
                    CardManager.Instance.selectedCard = null;
                    CardManager.Instance.indexSelectedCard = -1;
                }
                else if (CardManager.Instance.IsCardSelected == true)
                {
                    //Debug.Log("Cambiar de carta");
                    CardManager.Instance.BajartodasCards();
                    CardManager.Instance.selectedCard = transform.parent.gameObject;
                    CardManager.Instance.SelectingACard(transform.parent.gameObject);
                    CardManager.Instance.indexSelectedCard = WhatCard();
                    PreviewLogic.Instance.SelectedPreview();
                }
                else
                {
                    //Debug.Log("Seleccionar esta carta");
                    isSelected = true;
                    CardManager.Instance.IsCardSelected = true;
                    CardManager.Instance.selectedCard = transform.parent.gameObject;
                    CardManager.Instance.SelectingACard(transform.parent.gameObject);
                    CardManager.Instance.indexSelectedCard = WhatCard();
                    PreviewLogic.Instance.SelectedPreview();
                }
                
            }
        }
        else
        {
            Debug.Log("NO ES TU TURNO!");
        }
    }

    public int WhatCard()
    {
        for (int i = 0; i < BDCards.Instance.defensaNames.Count; i++)
        {
            if(BDCards.Instance.defensaNames[i] == CardManager.Instance.selectedCard.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>().text)
            {
                return i;
            }
            
        }
        return -1;
    }

}
