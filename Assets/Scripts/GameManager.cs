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
    public GameObject UITurno;

    public GameObject mesa1;
    public GameObject mesa2;
    public GameObject mesa3;
    public GameObject mesa4;

    public List<int> turnos = new List<int>();
    public List<GameObject> mesaCards = new List<GameObject>();

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeTurn()
    {
        humanTurn = !humanTurn;

        if (humanTurn)
        {
            UITurno.GetComponent<TextMeshProUGUI>().text = "Turno: Tu";
            //Debug.Log("Entrar change turn: tu");
        }
        else
        {
            UITurno.GetComponent<TextMeshProUGUI>().text = "Turno: No tu";
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
                Debug.Log("TURNO 4!!!!");
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
}
