using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X_guidebook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        Debug.Log("in background");
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("closed guidebook");
            GuideLogic.Instance.cerrarGuidebook();
        }
    }

}
