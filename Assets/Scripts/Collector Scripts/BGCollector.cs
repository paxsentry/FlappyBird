using System;
using UnityEngine;

public class BGCollector : MonoBehaviour
{

   private GameObject[] backgrounds;
   private GameObject[] grounds;

   private float lastBG_X;
   private float lastGround_X;

   void Awake()
   {
      backgrounds = GameObject.FindGameObjectsWithTag("Background");
      grounds = GameObject.FindGameObjectsWithTag("Ground");

      lastBG_X = backgrounds[0].transform.position.x;
      lastGround_X = grounds[0].transform.position.x;

      for (int i = 1; i < backgrounds.Length; i++)
      {
         var currentX = backgrounds[i].transform.position.x;
         if (lastBG_X < currentX)
         {
            lastBG_X = currentX;
         }
      }

      for (int i = 1; i < grounds.Length; i++)
      {
         var currentX = grounds[i].transform.position.x;
         if (lastGround_X < currentX)
         {
            lastGround_X = currentX;
         }
      }
   }

   void OnTriggerEnter2D(Collider2D target)
   {
      Debug.Log("Here");
      if (target.tag == "Background")
      {
         Vector3 temp = target.transform.position;
         float width = ((BoxCollider2D)target).size.x;

         temp.x = lastBG_X + width;

         target.transform.position = temp;

         lastBG_X = temp.x;
      }
      else if (target.tag == "Ground")
      {
         Vector3 temp = target.transform.position;
         float width = ((BoxCollider2D)target).size.x;

         temp.x = lastGround_X + width;

         target.transform.position = temp;

         lastGround_X = temp.x;
      }
   }
}