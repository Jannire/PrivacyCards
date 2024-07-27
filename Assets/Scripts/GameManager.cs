using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Variables
    public int puntajePlayer;
    public int puntajeAI;
    public bool humanTurn = true;
    public GameObject UIScore;
    public GameObject GameOverText;
    public GameObject GameOverScreen;

    public GameObject mesa1;
    public GameObject mesa2;
    public GameObject mesa3;
    public GameObject mesa4;

    public List<int> turnos = new List<int>();
    public List<int> indexCardsMesa = new List<int> {0, 0, 0, 0};
    public List<GameObject> mesaCards = new List<GameObject>();

    public GameObject glowEnemy;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        puntajePlayer = 0;
        puntajeAI = 0;

        turnos.Add(0);
        turnos.Add(0);
        turnos.Add(0);
        turnos.Add(0);

        mesaCards.Add(mesa1);
        mesaCards.Add(mesa2);
        mesaCards.Add(mesa3);
        mesaCards.Add(mesa4);

        humanTurn = true; //Inicia jugador
        //GameManager.Instance.UIScore.SetActive(false); // para pruebas
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeTurn()
    {
        humanTurn = !humanTurn;
        List<GameObject> activeCards = new List<GameObject>();
        activeCards = CardManager.Instance.BuscarCardsActivas();
        if (humanTurn)
        {
            for (int i = 0; i < activeCards.Count; i++)
            {
                activeCards[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            glowEnemy.SetActive(false);
            UIScore.GetComponent<TextMeshProUGUI>().text = "Puntaje jugador: " + puntajePlayer + "\nPuntaje AI: " + puntajeAI;
            //Debug.Log("Entrar change turn: tu");
        }
        else
        {
            for (int i = 0; i < activeCards.Count; i++)
            {
                activeCards[i].transform.GetChild(2).gameObject.SetActive(false);
            }
            glowEnemy.SetActive(true);
            UIScore.GetComponent<TextMeshProUGUI>().text = "Puntaje jugador: " + puntajePlayer + "\nPuntaje AI: " + puntajeAI;
            // UITurno.GetComponent<TextMeshProUGUI>().text = "Turno: No tu";
            //Debug.Log("Entrar change turn: No tu");
        }

        int numTemp = 0;

        for (int i = 0; i < 4; i++)
        {
            if (turnos[i] > 0)
            {
                if (!mesaCards[i].transform.GetChild(0).gameObject.GetComponent<CardMesaLogic>().indicadorFT)
                {
                    numTemp = i + 1;
                    //Debug.Log("++ Turno en card: " + numTemp);
                    mesaCards[i].transform.GetChild(0).gameObject.GetComponent<CardMesaLogic>().TurnUp(turnos[i]);
                    turnos[i]++;
                }
                else
                {
                    mesaCards[i].transform.GetChild(0).gameObject.GetComponent<CardMesaLogic>().indicadorFT = false;
                }
            }
            if (turnos[i] == 4)
            {
                QuitarCardMesa(mesaCards[i]);
                turnos[i] = 0;
                //mesaCards[i].transform.GetChild(0).gameObject.GetComponent<CardMesaLogic>().ResetTurns();
                //Debug.Log("TURNO 4!!!!");
            }
        }
        if (!humanTurn)
        {

            EnemyLogic.Instance.CheckMove();
        }
    }

    public void QuitarCardMesa(GameObject card)
    {
        //Debug.Log("Card? " + card.transform.GetChild(0).gameObject);
        card.transform.GetChild(0).gameObject.GetComponent<CardMesaLogic>().EliminarCard();
    }

    public void GameOver()
    {
        if(puntajePlayer >= 30 )
        {
            Debug.Log("Gano jugador!");
            GameOverScreen.SetActive(true);
            GameOverText.GetComponent<TextMeshProUGUI>().text = "¡Haz ganado esta partida!\n¡Para jugar de nuevo refresca la página! \n\nGracias por tu participación";
            //GameOverScreen.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "¡Haz ganado esta partida!\n¡Para jugar de nuevo refresca la página! \n\nGracias por tu participación";
        }
        else if(puntajeAI >= 30)
        {
            Debug.Log("Perdió jugador");
            GameOverScreen.SetActive(true);
            GameOverText.GetComponent<TextMeshProUGUI>().text = "¡En la siguiente podrás vencer!\n¡Para jugar de nuevo refresca la página!\n\nGracias por tu participación";
            //GameOverScreen.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "¡En la siguiente podrás vencer!\n¡Para jugar de nuevo refresca la página!\n\nGracias por tu participación";
        }
    }
}
