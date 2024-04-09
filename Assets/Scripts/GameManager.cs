using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    public int puntajePlayer;
    public int puntajeAI;

    public static GameManager Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        puntajePlayer = 0;
        puntajeAI = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
