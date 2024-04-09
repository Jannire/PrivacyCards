using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
  public GameObject card1;
  public GameObject card2;
  public GameObject card3;
  public GameObject card4;
  public GameObject selectedCard;
  public bool IsCardSelected;

  public static CardManager Instance { get; private set; }
  
  private void Awake()
  {
    Instance = this;
  }
  
  void Start()
  {
    IsCardSelected = false;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
