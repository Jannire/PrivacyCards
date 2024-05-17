using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
  public List<string> cardsEnemy = new List<string>();

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
      tempRand = UnityEngine.Random.Range(0, 2);
      // 0 -> ataque
      // 1 -> defensa
      if (tempRand == 0)
      {
        cardsEnemy.Add(BDCards.Instance.ataquesNames[i]);
      }
      else
      {
        cardsEnemy.Add(BDCards.Instance.defensaNames[i]);
      }
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
    if (cardsEnemy.Count == 1)
    {
      StartCoroutine(SacarNuevasCards());
    }
    else
    {
      StartCoroutine(PonerCardEnemy());
    }
  }

  IEnumerator PonerCardEnemy()
  {
    //dificultad facil
    yield return new WaitForSeconds(5);
    //Debug.Log("Enemy puso card -> " + cardsEnemy[0]);
    cardsEnemy.RemoveAt(0);
    int tempRand = 0;
    tempRand = UnityEngine.Random.Range(1, 5);
    //Debug.Log("EnemyLogic card random: " + tempRand);
    switch (tempRand)
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
    GameManager.Instance.changeTurn();
  }

  IEnumerator  SacarNuevasCards()
  {
    //No tiene cards
    int tempRand = 0;
    tempRand = UnityEngine.Random.Range(0, 2);

    if (tempRand == 0)
    {
      cardsEnemy.Add(BDCards.Instance.ataquesNames[0]); // Por ahora igual tener que arreglar lo de spawncards y cardsBD
    }
    else
    {
      cardsEnemy.Add(BDCards.Instance.defensaNames[0]);
    }
    yield return new WaitForSeconds(5);
    GameManager.Instance.changeTurn();
  }



}
