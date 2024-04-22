using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnCards : MonoBehaviour
{

    //Se va a tener que cambiar si son más de 4 cards
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;

    public GameObject cardT;
    public GameObject temp;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //Draw card --- COMO HACER QUE SE DESLIZEN
        if (CardManager.Instance.mazoCards < 4)
        {
            Debug.Log("Sacar nueva card");
            switch (CardManager.Instance.mazoCards)
            {
                case 0:
                    cardT = card4;
                    break;
                case 1:
                    cardT = card3;
                    break;
                case 2:
                    cardT = card2;
                    break;
                case 3:
                    cardT = card1;
                    break;
                default:
                    Debug.Log("????");
                    break;
            }
            CardManager.Instance.selectedCard = null;
            CardManager.Instance.IsCardSelected = false;
            CardManager.Instance.BajartodasCards();
            CardManager.Instance.mazoCards++;
            spawnCard(cardT);
        }
        else
        {
            Debug.Log("No puedes sacar más cards");
        }
    }

    void spawnCard(GameObject card)
    {
        card.SetActive(true);
        CardManager.Instance.OrganizarBaraja();
        temp = card.transform.GetChild(1).GetChild(0).gameObject;
        //Debug.Log("Temp: " + temp);
        //Debug.Log("--> " + gameObject.name.GetType());
        
        if(gameObject.name == "Defensa")
        {
            temp.GetComponent<TextMeshPro>().text = CardManager.Instance.Controllar_baraja_defensa();
        }
        else
        {
            temp.GetComponent<TextMeshPro>().text = CardManager.Instance.Controllar_baraja_ataque();
        }
        //= Controllar_baraja_defensa
    }
}
