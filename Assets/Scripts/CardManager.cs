using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    int tempRand = 0;
    for (int i = 0; i < cards.Count; i++)
    {
      tempRand = UnityEngine.Random.Range(0, 2);
      // 0 -> ataque
      // 1 -> defensa
      if (tempRand == 0)
      {
        ataque.Add("A");
        //Debug.Log("Text attack: " + BDCards.Instance.ataquesNames);
        cards[i].transform.GetChild(1).gameObject.GetComponent<TextMeshPro>().text = BDCards.Instance.ataquesNames[i];
      }
      else
      {
        defensa.Add("D");
        //Debug.Log("Text defense: " + BDCards.Instance.defensaNames);
        cards[i].transform.GetChild(1).gameObject.GetComponent<TextMeshPro>().text = BDCards.Instance.defensaNames[i];
      }
      //Debug.Log("New Card: " + cards[i].transform.GetChild(1).gameObject.GetComponent<TextMeshPro>().text);
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
      //Debug.Log("Selected: " + selectedCard);
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
    //Debug.Log("Se ha puesto la carta: " + card);
    //Quitar el card
    card.SetActive(false);
    mazoCards--;
    CardManager.Instance.selectedCard = null;
    CardManager.Instance.IsCardSelected = false;
    OrganizarBaraja();

    //GameManager.Instance.changeTurn();
  }

  public void OrganizarBaraja()
  {
    List<GameObject> currentActive = new List<GameObject>();
    currentActive = BuscarCardsActivas();
    string combinedString = string.Join(",", currentActive);
    //Debug.Log("Activas " + "(" + mazoCards + "//"+ currentActive.Count + "): " + combinedString);

    if (mazoCards == 0)
    {
      Debug.Log("No cards on deck");
    }
    else
    {
      for (int i = 0; i < mazoCards; i++)
      {
        //Debug.Log("i: " + i + "/" + currentActive.Count);
        currentActive[i].transform.position = poss[i];
      }
    }
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

  public List<GameObject> BuscarCardsNOActivas()
  {
    List<GameObject> currentNONActiveCards = new List<GameObject>();
    foreach (GameObject cad in cards)
    {
      if (!cad.activeSelf)
      {
        currentNONActiveCards.Add(cad);
      }
    }
    return currentNONActiveCards;
  }

  public string Controllar_baraja_defensa()
  {
    //Debug.Log("Next is: " + BDCards.Instance.defensaNames[contDefensa]);
    contDefensa++;
    return BDCards.Instance.defensaNames[contDefensa];
  }

  public string Controllar_baraja_ataque()
  {
    //Debug.Log("Next is: " + BDCards.Instance.ataquesNames[contAtaque]);
    contAtaque++;
    return BDCards.Instance.ataquesNames[contAtaque];
  }
}
