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
        if (isSelected == true)
        {
            Debug.Log("Deseleccionar");
            isSelected = false;
            CardManager.Instance.IsCardSelected = false;
            CardManager.Instance.selectedCard = null;
        }
        else if (CardManager.Instance.IsCardSelected == true)
        {
            //MAnejar el movimiento de cartas en card Manager
            Debug.Log("Cambiar de carta");
            CardManager.Instance.selectedCard = gameObject;
        }
        else
        {
            Debug.Log("Seleccionar esta carta");
            isSelected = true;
            CardManager.Instance.IsCardSelected = true;
            CardManager.Instance.selectedCard = gameObject;
        }
    }
}
