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
        //If your mouse hovers over the GameObject with the script attached, output this message
        //gameObject.transform.position = (gameObject.transform.position + Vector3.up);
        // += scal;
        transform.localScale = scalFin;
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        //gameObject.transform.position  = (gameObject.transform.position + Vector3.down);
        //gameObject.transform.position = posIni;
        //transform.localScale -= scal;
        transform.localScale = scalIni;
        Debug.Log("Mouse is no longer on GameObject.");
    }

    void onMouseDown()
    {
        Debug.Log("Open guidebook");
    }

    
}
