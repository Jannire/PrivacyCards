using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMesaLogic : MonoBehaviour
{
    public int cardsContested = 0;
    public string nameMesa;

    public GameObject mini1;
    public GameObject mini2;
    //Aqui falta poner la logica del AI


    void Start()
    {
        cardsContested = 0;
        RevisarQueCardEs();
    }

    public void RevisarQueCardEs()
    {
        //Debug.Log("Type name is: " + transform.name.GetType());
        nameMesa = transform.parent.gameObject.name;
        //nameMesa = nameMesa[9];
        //Debug.Log("Type: "  + nameMesa.GetType());
        //int num = int.Parse(nameMesa[9]);
        switch (nameMesa[9])
        {
            case '1':
                GameManager.Instance.turno1++;
                break;
            case '2':
                GameManager.Instance.turno2++;
                break;
            case '3':
                GameManager.Instance.turno3++;
                break;
            case '4':
                GameManager.Instance.turno4++;
                break;
            default:
                Debug.Log("Algo paso mal!" + nameMesa);
                break;
        }
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        if (CardManager.Instance.IsCardSelected == true)
        {
            cardsContested++;
            CardManager.Instance.PonerCard(CardManager.Instance.selectedCard);
            RevisarQueCardEs();
            if(cardsContested == 1)
            {
                mini1.SetActive(true);
            }
            else
            {
                mini2.SetActive(true);
                EliminarCard();
            }
        }
    }

    void EliminarCard()
    {
        nameMesa = transform.parent.gameObject.name;
        switch (nameMesa[9])
        {
            case '1':
                GameManager.Instance.turno1 = 0;
                break;
            case '2':
                GameManager.Instance.turno2 = 0;
                break;
            case '3':
                GameManager.Instance.turno3 = 0;
                break;
            case '4':
                GameManager.Instance.turno4 = 0;
                break;
            default:
                Debug.Log("Algo paso mal!" + nameMesa);
                break;
        }
        //Entre muchas comillas aqui va la animación de draw new
        mini1.SetActive(false);
        mini2.SetActive(false);
    }
}
