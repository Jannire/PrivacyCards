using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    public int puntajePlayer;
    public int puntajeAI;
    public int turno1;
    public int turno2;
    public int turno3;
    public int turno4;

    public static GameManager Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        puntajePlayer = 0;
        puntajeAI = 0;

        turno1 = 0;
        turno2 = 0;
        turno3 = 0;
        turno4 = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
