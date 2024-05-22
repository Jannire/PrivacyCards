using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewLogic : MonoBehaviour
{
    public static PreviewLogic Instance { get; private set; }

    public GameObject PreCard;
    public GameObject tex;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }


    void Update()
    {

    }

    public void SelectedPreview()
    {
        if (CardManager.Instance.selectedCard == null)
        {
            Debug.Log("Selected card: " + "no hay");
        }
        else
        {
            tex.GetComponent<TextMeshPro>().text = CardManager.Instance.selectedCard.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>().text;
        }
        //Debug.Log("CARD: " + CardManager.Instance.selectedCard.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>().text);
    }

    void OnMouseOver()
    {
        //transform.localScale = scalFin;
        Debug.Log("hola?");
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Open preview card");
            //Open in guidebook logic
            //GuideLogic.Instance.abrirGuidebook();
        }
    }
}
