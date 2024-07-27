using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideLogic : MonoBehaviour
{
    public GameObject closed_book;
    public GameObject open_book;
    public GameObject X;

    public static GuideLogic Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void abrirGuidebook()
    {
        open_book.SetActive(true);
        GameManager.Instance.UIScore.SetActive(false);
    }

    public void cerrarGuidebook()
    {
        open_book.SetActive(false);
        GameManager.Instance.UIScore.SetActive(true);
    }
}
