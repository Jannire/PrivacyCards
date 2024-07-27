using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moreInfoCard : MonoBehaviour
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
        //transform.localScale = scalFin;
        Debug.Log("???");
        if (Input.GetMouseButtonDown(0) && PreviewLogic.Instance.open)
        {
            PreviewLogic.Instance.FlipCard();
        }

    }
}
