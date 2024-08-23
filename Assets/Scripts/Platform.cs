using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
   
   public GameObject WellTop;
   public GameObject WellLeft;
   public GameObject WellRight;
   public GameObject WellDown;
   
   public bool isWellTop = false;
   public bool isWellDown= false;
   public bool isWellLeft= false;
   public bool isWellRight= false;

   private void Start()
   {
      if (isWellTop)
      {
         WellTop.SetActive(true);
      }
      if (isWellDown)
      {
         WellDown.SetActive(true);
      }
      if (isWellRight)
      {
         WellRight.SetActive(true);
      }
      if (isWellLeft)
      {
         WellLeft.SetActive(true);
      }
   }
}
