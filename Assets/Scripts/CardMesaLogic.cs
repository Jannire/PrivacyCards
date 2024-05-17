using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardMesaLogic : MonoBehaviour
{
    public int cardsContested = 0;
    public int cardsContestedEnemy = 0;
    public string nameMesa;
    //public string tex;

    public GameObject mini1;
    public GameObject mini2;

    public GameObject mini1AI;
    public GameObject mini2AI;

    public GameObject scoreAI;
    public GameObject scoreHuman;
    public GameObject TextoCard;

    public GameObject bol1;
    public GameObject bol2;
    public GameObject bol3;
    public GameObject bol4;

    public List<GameObject> objTurns = new List<GameObject>();

    public bool indicadorFT;
    //Aqui falta poner la logica del AI


    void Start()
    {
        cardsContested = 0;
        int tempRand = 0;
        int ran = 0;
        tempRand = UnityEngine.Random.Range(0, 2);
        Transform parentTransform = transform.parent;
        Transform siblingTransform = parentTransform.Find("Text");
        TextoCard = siblingTransform.gameObject;

        if (tempRand == 0) //defensa
        {
            ran = UnityEngine.Random.Range(0, BDCards.Instance.defensaNames.Count);
            TextoCard.GetComponent<TextMeshPro>().text = BDCards.Instance.defensaNames[ran];
            //Debug.Log("TexMesa: " + TextoCard.GetComponent<TextMeshPro>().text);
        }
        else //ataque
        {
            ran = UnityEngine.Random.Range(0, BDCards.Instance.ataquesNames.Count);
            TextoCard.GetComponent<TextMeshPro>().text = BDCards.Instance.ataquesNames[ran];
            ///Debug.Log("TexMesa: " + TextoCard.GetComponent<TextMeshPro>().text);
        }

        if (TextoCard.GetComponent<TextMeshPro>().text.Length > 80)
        {
            TextoCard.GetComponent<TextMeshPro>().fontSize = 2;
        }
        else if (TextoCard.GetComponent<TextMeshPro>().text.Length > 30)
        {
            TextoCard.GetComponent<TextMeshPro>().fontSize = 3;
        }
        else
        {
            TextoCard.GetComponent<TextMeshPro>().fontSize = 4;
        }

        RevisarQueCardEs();

        objTurns.Add(bol1);
        objTurns.Add(bol2);
        objTurns.Add(bol3);
        objTurns.Add(bol4);
    }

    public void RevisarQueCardEs()
    {
        //Debug.Log("Type name is: " + transform.name.GetType());
        nameMesa = transform.parent.gameObject.name;
        //nameMesa = nameMesa[9];
        //Debug.Log("Type: "  + nameMesa.GetType());
        //int num = int.Parse(nameMesa[9]);

    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        CardMesaDown();
    }

    public void CardMesaDown()
    {
        if (!GameManager.Instance.humanTurn) /////////////////////////////////// Turno de IA
        {
            cardsContestedEnemy++;
            if (cardsContestedEnemy == 1)
            {
                mini1AI.SetActive(true);
            }
            else
            {
                mini2AI.SetActive(true);
            }
            firstTime();
        }

        if (CardManager.Instance.IsCardSelected == true)
        {
            cardsContested++;
            CardManager.Instance.PonerCard(CardManager.Instance.selectedCard);
            RevisarQueCardEs();
            if (cardsContested == 1)
            {
                mini1.SetActive(true);
            }
            else
            {
                mini2.SetActive(true);
                //Cambiar de sitio
            }
            firstTime();
            GameManager.Instance.changeTurn();
        }


    }

    IEnumerator DiscardCard()
    {
        yield return new WaitForSeconds(5);
        nameMesa = transform.parent.gameObject.name;

        //Entre muchas comillas aqui va la animación de draw new
        mini1.SetActive(false);
        mini2.SetActive(false);

        mini1AI.SetActive(false);
        mini2AI.SetActive(false);
    }

    public void EliminarCard()
    {
        StartCoroutine(DiscardCard());
    }

    public void firstTime()
    {
        int num = nameMesa[9] - '0';
        if (GameManager.Instance.turnos[num - 1] == 0)
        {
            //Debug.Log("Primera vez en este card");
            indicadorFT = true;
            GameManager.Instance.turnos[num - 1]++;
            TurnUp(0);
        }
        else
        {
            indicadorFT = false;
        }
    }

    public void TurnUp(int index)
    {
        Debug.Log("Index: " + index);
        objTurns[index].SetActive(false);
    }

    public void ResetTurns()
    {
        for (int i = 0; i < 4; i++)
        {
            objTurns[i].SetActive(true);
        }
    }
}
