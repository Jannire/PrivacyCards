using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
  public int indexSelectCardEnemy = 0;
  public List<string> cardsEnemy = new List<string>();
  public List<int> cardsEnemyIndex = new List<int>();

  public static EnemyLogic Instance { get; private set; }

  private void Awake()
  {
    Instance = this;
  }


  void Start()
  {
    firstCards();
  }

  public void firstCards()
  {
    int tempRand = 0;
    for (int i = 0; i < 4; i++)
    {
      tempRand = UnityEngine.Random.Range(0, 16);
      // 0 -> ataque
      // 1 -> defensa
      cardsEnemy.Add(BDCards.Instance.defensaNames[tempRand]);
      cardsEnemyIndex.Add(tempRand);

      //Debug.Log("New Card: " + cards[i].transform.GetChild(1).gameObject.GetComponent<TextMeshPro>().text);
    }
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void CheckMove()
  {
    //Por ahora
    int randito = UnityEngine.Random.Range(0, 2);
    if (cardsEnemy.Count == 1)
    {
      StartCoroutine(SacarNuevasCards()); // Saca si tiene una carta
    }
    else if (cardsEnemy.Count < 4 && randito == 1)
    {
      StartCoroutine(SacarNuevasCards()); // QUe saque de vez en cuando
    }
    else
    {
      StartCoroutine(PonerCardEnemy());
    }
  }

  IEnumerator PonerCardEnemy()
  {
    //dificultad facil
    yield return new WaitForSeconds(3);
    //Debug.Log("Enemy puso card -> " + cardsEnemy[0]);

    (int, int) apuesta = MejorPostor();
    indexSelectCardEnemy = apuesta.Item1;


    switch (apuesta.Item2)
    {
      case 1:
        GameManager.Instance.mesaCards[0].transform.GetChild(0).gameObject.GetComponent<CardMesaLogic>().CardMesaDown();
        break;
      case 2:
        GameManager.Instance.mesaCards[1].transform.GetChild(0).gameObject.GetComponent<CardMesaLogic>().CardMesaDown();
        break;
      case 3:
        GameManager.Instance.mesaCards[2].transform.GetChild(0).gameObject.GetComponent<CardMesaLogic>().CardMesaDown();
        break;
      case 4:
        GameManager.Instance.mesaCards[3].transform.GetChild(0).gameObject.GetComponent<CardMesaLogic>().CardMesaDown();
        break;
      default:
        Debug.Log("Mal en EnemyLogic");
        break;
    }
    //CardMesaDown
    cardsEnemyIndex.RemoveAt(0);
    cardsEnemy.RemoveAt(0);
    GameManager.Instance.changeTurn();
  }


  public (int, int) MejorPostor()
  {
    int mayor = -1;
    int segundoMejor = 0;
    int tempScore = 0;
    int Cual_apostarCard = -1;
    int Cual_apostarCardSegundo = 0;
    int Donde_apostarCard = -1;
    int Donde_apostarCardSegundo = 0;
    for (int i = 0; i < cardsEnemy.Count; i++)
    {
      for (int j = 0; j < 4; j++)
      {
        //Debug.Log("Mejor postro: " + GameManager.Instance.indexCardsMesa[j]);
        tempScore = BDCards.Instance.ReturningScore(GameManager.Instance.indexCardsMesa[j], cardsEnemyIndex[i]);
        if (mayor < tempScore)
        {
          segundoMejor = mayor;
          mayor = tempScore;
          Cual_apostarCardSegundo = Cual_apostarCard;
          Cual_apostarCard = cardsEnemyIndex[i];
          Donde_apostarCardSegundo = Donde_apostarCard;
          Donde_apostarCard = j;

        }
      }
    }
    //Debug.Log("Cual apostar: " + Cual_apostarCard);
    (int, int) apuestasEnemy = (Cual_apostarCard, Donde_apostarCard + 1);
    int randito = UnityEngine.Random.Range(0, 5);
    if (randito == 1 || randito == 2)
    {
      apuestasEnemy = (Cual_apostarCard, Donde_apostarCard + 1);
    }
    else if(segundoMejor == -1)
    {
      apuestasEnemy = (Cual_apostarCard, Donde_apostarCard + 1);
    }
    else
    {
      apuestasEnemy = (Cual_apostarCardSegundo, Donde_apostarCardSegundo + 1);
    }
    //Debug.Log("Score: " + mayor + "cual apuesta: " + Cual_apostarCard + "donde: " + Donde_apostarCard);
    return apuestasEnemy;
  }

  IEnumerator SacarNuevasCards()
  {
    //No tiene cards
    int tempRand = 0;
    tempRand = UnityEngine.Random.Range(0, 16);
    cardsEnemy.Add(BDCards.Instance.defensaNames[tempRand]);
    cardsEnemyIndex.Add(tempRand);

    yield return new WaitForSeconds(3);
    GameManager.Instance.changeTurn();
  }



}
