using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideBook : MonoBehaviour
{
    private Vector3 posIni = new Vector3(0f, 0f, 0f);
    private Vector3 scalFin = new Vector3(0f, 0f, 0f);
    private Vector3 scalIni = new Vector3(0f, 0f, 0f);
    private Vector3 temp = new Vector3(1f, 1f, 0f);


    void Start()
    {
        posIni = gameObject.transform.position;
        scalIni = gameObject.transform.localScale;
        scalFin = scalIni + temp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        transform.localScale = scalFin;
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Open guidebook2");
            //Esconder puntaje
            
            GuideLogic.Instance.abrirGuidebook();
        }
    }


    void OnMouseExit()
    {
        transform.localScale = scalIni;
    }



}
