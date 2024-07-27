using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewLogic : MonoBehaviour
{
    public static PreviewLogic Instance { get; private set; }

    public GameObject PreCard;
    public GameObject tex;
    public bool open = false;
    public GameObject moreInfo;

    public bool flipped = false;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectedPreview()
    {
        if(flipped)
        {
            flipped = false;
            tex.GetComponent<TextMeshPro>().fontSize = 3;
        }
        if (CardManager.Instance.selectedCard == null)
        {
            tex.GetComponent<TextMeshPro>().text = "¡Haz clic en una carta!"; //Debug.Log("Selected card: " + "no hay");
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
        //Debug.Log("hola?");
        if (Input.GetMouseButtonDown(0))
        {
            //Open in guidebook logic
            //GuideLogic.Instance.abrirGuidebook();
            if (!open)
            {
                transform.position = (transform.position + Vector3.left + Vector3.left);
                open = true;
                //Debug.Log("Open preview card");
            }
            else
            {
                transform.position = (transform.position + Vector3.right + Vector3.right);
                open = false;
                //Debug.Log("Close preview card");
            }
        }
    }

    public void FlipCard()
    {
        //Animacion de flip
        if(!flipped)
        {
            tex.GetComponent<TextMeshPro>().text = "Selecciona una carta!";
            tex.GetComponent<TextMeshPro>().fontSize = 3;
            if(CardManager.Instance.selectedCard != null)
            {
                BuscarDefensaMatrix();
            }

            flipped = true;
        }
        else
        {
            SelectedPreview();
            flipped = false;
            tex.GetComponent<TextMeshPro>().fontSize = 3;
        }
    }

    public void BuscarDefensaMatrix()
    {
        //Debug.Log("Card: "+ CardManager.Instance.selectedCard);
        string strTest = "";
        for (int i = 0; i < BDCards.Instance.ataquesNames.Count; i++)
        {
            strTest = strTest + BDCards.Instance.ataquesNamesShort[i] + ": " + BDCards.Instance.defensaPoints[CardManager.Instance.indexSelectedCard][i] + "\n"; 
        }
        tex.GetComponent<TextMeshPro>().text = strTest;
        tex.GetComponent<TextMeshPro>().fontSize = 1.7f;
        //CardManager.Instance.selectedCard.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>().text;
    }
}
