using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLogic : MonoBehaviour
{
    public bool isSelected;

    void Start()
    {

    }


    void Update()
    {

    }

    void OnMouseDown()
    {
        //Debug.Log("Estado: " + isSelected);
        //Debug.Log("Carta: " + transform.parent.gameObject);
        if (transform.parent.gameObject.name.Contains("Card"))
        {
            Debug.Log("Este script --> " + transform.parent.gameObject);
            Debug.Log("En Cardmanager -->" + CardManager.Instance.selectedCard);
            if (CardManager.Instance.selectedCard == transform.parent.gameObject)
            {
                //Debug.Log("Deseleccionar");
                isSelected = false;
                CardManager.Instance.BajartodasCards();
                CardManager.Instance.IsCardSelected = false;
                CardManager.Instance.selectedCard = null;
            }
            else if (CardManager.Instance.IsCardSelected == true)
            {
                //Manejar el movimiento de cartas en card Manager
                //Debug.Log("Cambiar de carta");
                CardManager.Instance.BajartodasCards();
                CardManager.Instance.selectedCard = transform.parent.gameObject;
                CardManager.Instance.SelectingACard(transform.parent.gameObject);
            }
            else
            {
                //Debug.Log("Seleccionar esta carta");
                isSelected = true;
                CardManager.Instance.IsCardSelected = true;
                CardManager.Instance.selectedCard = transform.parent.gameObject;
                CardManager.Instance.SelectingACard(transform.parent.gameObject);
            }

        }
    }
}
