using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InfoAttack : MonoBehaviour
{
    public int indexAttack;
    public string attackName;
    
    public GameObject title;
    public GameObject filler;

    // Start is called before the first frame update
    void Start()
    {
        WhatAttack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        //Debug.Log("Hola soy: " + attackName);
        title.GetComponent<TextMeshPro>().text = attackName;
        filler.GetComponent<TextMeshPro>().text = BDCards.Instance.ataquesInfo[indexAttack];
        filler.GetComponent<TextMeshPro>().fontSize = 0.3f;

        if (title.GetComponent<TextMeshPro>().text.Length > 22)
        {
            title.GetComponent<TextMeshPro>().fontSize = 0.4f;
        }
        else if (title.GetComponent<TextMeshPro>().text.Length > 18)
        {
            title.GetComponent<TextMeshPro>().fontSize = 0.5f;
        }
        else
        {
            title.GetComponent<TextMeshPro>().fontSize = 0.6f;
        }
    }

    public void WhatAttack()
    {
        attackName = gameObject.name;
        indexAttack = (int)Char.GetNumericValue(attackName[6]) - 1;
        //string res = BDCards.Instance.ataquesNamesShort[indexAttack-1];
        //Debug.Log("Attacks: " + res);
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = BDCards.Instance.ataquesNamesShort[indexAttack];
        attackName = BDCards.Instance.ataquesNamesShort[indexAttack];
    }
}
