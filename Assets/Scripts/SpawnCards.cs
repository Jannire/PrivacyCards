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
            List<GameObject> currentActiveNON = new List<GameObject>();
            currentActiveNON = CardManager.Instance.BuscarCardsNOActivas();

            CardManager.Instance.selectedCard = null;
            CardManager.Instance.IsCardSelected = false;
            CardManager.Instance.BajartodasCards();
            CardManager.Instance.mazoCards++;
            
            spawnCard(currentActiveNON[0]);
            GameManager.Instance.changeTurn();
        }
        else
        {
            Debug.Log("No puedes sacar más cards");
        }
    }

    void spawnCard(GameObject card)
    {
        card.SetActive(true);
        Debug.Log("Temp: " + card);
        CardManager.Instance.OrganizarBaraja();
        temp = card.transform.GetChild(1).gameObject;
        
        if(gameObject.name == "Defensa")
        {
            temp.GetComponent<TextMeshPro>().text = CardManager.Instance.Controllar_baraja_defensa();
        }/*
        else
        {
            temp.GetComponent<TextMeshPro>().text = CardManager.Instance.Controllar_baraja_ataque();
        }*/
        //= Controllar_baraja_defensa
    }
}
