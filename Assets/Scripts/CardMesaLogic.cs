using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

using System.Text;

public class CardMesaLogic : MonoBehaviour
{
    public int cardsContested = 0;
    public int cardsContestedEnemy = 0;
    public string nameMesa;
    public int indexCard;
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

        Transform parentTransform = transform.parent;
        Transform siblingTransform = parentTransform.Find("Text");
        TextoCard = siblingTransform.gameObject;

        indexCard = UnityEngine.Random.Range(0, BDCards.Instance.ataquesNames.Count);
        TextoCard.GetComponent<TextMeshPro>().text = BDCards.Instance.ataquesNames[indexCard];
        gameObject.transform.GetComponent<SpriteRenderer>().color = new Color32(224, 58, 54, 235);
        //Debug.Log("Ataque: " + transform.parent);

        #region old code
        /*
        if (tempRand == 0) //defensa
        {
            ran = UnityEngine.Random.Range(0, BDCards.Instance.defensaNames.Count);
            TextoCard.GetComponent<TextMeshPro>().text = BDCards.Instance.defensaNames[ran];
            gameObject.transform.GetComponent<SpriteRenderer>().color = new Color32( 66, 224, 54, 235 );
            Debug.Log("Defensa: " + transform.parent);
            //cards[i].transform.GetChild(0)
            //Debug.Log("TexMesa: " + TextoCard.GetComponent<TextMeshPro>().text);
        }
        else //ataque
        {
            
            ///Debug.Log("TexMesa: " + TextoCard.GetComponent<TextMeshPro>().text);
        }*/
        #endregion

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
        int num = nameMesa[9] - '0';
        //Debug.Log("indexCard: " + indexCard);
        GameManager.Instance.indexCardsMesa[num - 1] = indexCard;
        //nameMesa = nameMesa[9];
        //Debug.Log("Type: "  + nameMesa.GetType());
        //int num = int.Parse(nameMesa[9]);

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
            RevisarPuntaje(scoreAI);
        }

        if (CardManager.Instance.IsCardSelected == true)
        {
            cardsContested++;
            RevisarPuntaje(scoreHuman);
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

    public void RevisarPuntaje(GameObject player)
    {
        //Debug.Log("Score: " + player.GetComponent<TextMeshPro>().text);
        int newScore = 0;
        int masScore = 0;
        //Debug.Log("HumanTurn: " + GameManager.Instance.humanTurn);
        if (GameManager.Instance.humanTurn)
        {
            masScore = BDCards.Instance.ReturningScore(indexCard, CardManager.Instance.indexSelectedCard);
            BDCards.Instance.defensaPoints[CardManager.Instance.indexSelectedCard][indexCard] = masScore;
            
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < BDCards.Instance.defensaPoints.Count; i++)
            {
                for (int j = 0; j < BDCards.Instance.defensaPoints[i].Count; j++)
                {
                    sb.Append(BDCards.Instance.defensaPoints[i][j]);
                    if (j < BDCards.Instance.defensaPoints[i].Count - 1)
                    {
                        sb.Append(" ");  // Separator between elements in the same row
                    }
                }
                if (i < BDCards.Instance.defensaPoints.Count - 1)
                {
                    sb.Append("//");  // Separator between rows
                }
            }

            Debug.Log("Matrix: " + sb.ToString());

        }
        else
        {
            //Debug.Log("entro? " + indexCard + " con cartaDefensa: " + EnemyLogic.Instance.indexSelectCardEnemy);
            masScore = BDCards.Instance.ReturningScore(indexCard, EnemyLogic.Instance.indexSelectCardEnemy);
        }
        //Debug.Log("cont: " + cont);
        newScore = int.Parse(player.GetComponent<TextMeshPro>().text) + masScore;
        player.GetComponent<TextMeshPro>().text = newScore.ToString();
    }

    IEnumerator DiscardCard()
    {
        yield return new WaitForSeconds(0); //Revisar si vale la pena
        nameMesa = transform.parent.gameObject.name;

        //Poner putnaje
        AddScore();
        //Entre muchas comillas aqui va la animación de draw new
        mini1.SetActive(false);
        mini2.SetActive(false);

        mini1AI.SetActive(false);
        mini2AI.SetActive(false);
        scoreAI.GetComponent<TextMeshPro>().text = "0";
        scoreHuman.GetComponent<TextMeshPro>().text = "0";
        ResetTurns();

        //Debug.Log("Se ha eliminado");

        indexCard = UnityEngine.Random.Range(0, BDCards.Instance.ataquesNames.Count);
        TextoCard.GetComponent<TextMeshPro>().text = BDCards.Instance.ataquesNames[indexCard];

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
        //Debug.Log("Index: " + index);
        objTurns[index].SetActive(false);
    }

    public void ResetTurns()
    {
        for (int i = 0; i < 4; i++)
        {
            objTurns[i].SetActive(true);
        }
    }

    public void AddScore()
    {
        int scAI = int.Parse(scoreAI.GetComponent<TextMeshPro>().text);
        int scHuman = int.Parse(scoreHuman.GetComponent<TextMeshPro>().text);
        //Debug.Log("Scores: " + scAI + "-" + scHuman);
        if (scAI > scHuman)
        {
            GameManager.Instance.puntajeAI = GameManager.Instance.puntajeAI + scAI + scHuman / 2;
            //Debug.Log("Carta ganada: AI");
        }
        else if (scAI < scHuman)
        {
            GameManager.Instance.puntajePlayer = GameManager.Instance.puntajePlayer + scHuman + scAI / 2;
            //Debug.Log("Carta ganada: Human");
        }
        else
        {
            //Debug.Log("Empate");
            ;
        }

        GameManager.Instance.UIScore.GetComponent<TextMeshProUGUI>().text = "Puntaje jugador: " + GameManager.Instance.puntajePlayer + "\nPuntaje AI: " + GameManager.Instance.puntajeAI;
        GameManager.Instance.GameOver();
    }
}
