using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
  public GameObject card1;
  public GameObject card2;
  public GameObject card3;
  public GameObject card4;

  public int mazoCards;

  public GameObject selectedCard;
  public bool IsCardSelected;

  private Vector3 posIni1 = new Vector3(0f, 0f, 0f);
  private Vector3 posIni2 = new Vector3(0f, 0f, 0f);
  private Vector3 posIni3 = new Vector3(0f, 0f, 0f);
  private Vector3 posIni4 = new Vector3(0f, 0f, 0f);

  public List<Vector3> poss = new List<Vector3>();
  public List<GameObject> cards = new List<GameObject>();

  public List<string> ataque = new List<string>();
  public List<string> defensa = new List<string>();
  public int contAtaque;
  public int contDefensa;
  //private GameObject[] cards = { card1, card2, card3, card4 };

  public static CardManager Instance { get; private set; }

  private void Awake()
  {
    Instance = this;
  }

  void Start()
  {
    IsCardSelected = false;
    posIniCards();
    mazoCards = 4;
    contAtaque = 0;
    contDefensa = 0;
  }

  // Update is called once per frame
  void Update()
  {


  }

  public void posIniCards()
  {
    posIni1 = card1.transform.position;
    posIni2 = card2.transform.position;
    posIni3 = card3.transform.position;
    posIni4 = card4.transform.position;

    poss.Add(posIni1);
    poss.Add(posIni2);
    poss.Add(posIni3);
    poss.Add(posIni4);

    cards.Add(card1);
    cards.Add(card2);
    cards.Add(card3);
    cards.Add(card4);

    for (int i = 0; i < 15; i++)
    {
      ataque.Add("A");
      defensa.Add("D");
    }
  }

  public void SelectingACard(GameObject card)
  {
    //posIni = card.transform.position;
    //BajartodasCards();
    if (cards.Contains(card))
    {
      card.transform.position = (card.transform.position + Vector3.up);
      //card.transform.Translate(0,3,0);
      Debug.Log("Selected: " + selectedCard);
      //card.transform.position.x = posIni.x + 5;
      //Debug.Log("Pos: " + card.transform.position.x);
    }
  }

  public void BajartodasCards()
  {
    if (IsCardSelected)
    {
      selectedCard.transform.position = (selectedCard.transform.position + Vector3.down);
    }
    /*for (int i = 0; i < 4; i++)
    {
      cards[i].transform.position = (cards[i].transform.position + Vector3.down);
    }*/
  }

  public void PonerCard(GameObject card)
  {
    Debug.Log("Se ha puesto la carta: " + card);
    //Quitar el card
    card.SetActive(false);
    mazoCards--;
    CardManager.Instance.selectedCard = null;
    CardManager.Instance.IsCardSelected = false;
    OrganizarBaraja();
  }

  public void OrganizarBaraja()
  {
    List<GameObject> currentActive = new List<GameObject>();
    currentActive = BuscarCardsActivas();
    string combinedString = string.Join(",", currentActive);
    Debug.Log("Activas " + "(" + mazoCards + "): " + combinedString);

    if (mazoCards == 0)
    {
      Debug.Log("No cards on deck");
    }
    else
    {
      for (int i = 0; i < mazoCards; i++)
      {
        currentActive[i].transform.position = poss[i];
      }
    }
    /*
    switch (mazoCards)
    {
      case 0:
        Debug.Log("No cards on deck");
        break;
      case 1:
        currentActive[0].transform.position = poss[0];
        break;
      case 2:
        
      default:
        Debug.Log("AAAAAa");
        break;
    }*/
  }

  public List<GameObject> BuscarCardsActivas()
  {
    List<GameObject> currentActiveCards = new List<GameObject>();
    foreach (GameObject cad in cards)
    {
      if (cad.activeSelf)
      {
        currentActiveCards.Add(cad);
      }
    }
    return currentActiveCards;
  }

  public string Controllar_baraja_defensa()
  {
    Debug.Log("Next is: " + defensa[contDefensa]);
    contDefensa++;
    return defensa[contDefensa];
  }

  public string Controllar_baraja_ataque()
  {
    Debug.Log("Next is: " + ataque[contAtaque]);
    contAtaque++;
    return ataque[contAtaque];
  }
}
