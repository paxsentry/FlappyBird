using UnityEngine;

public class PipeCollector : MonoBehaviour
{
   private GameObject[] pipeHolders;
   private float distance = 2.5f;
   private float lastPipe_X;
   private float pipeMin = -2.2f;
   private float pipeMax = 2.2f;

   void Awake()
   {
      pipeHolders = GameObject.FindGameObjectsWithTag("PipeHolder");

      for (int i = 0; i < pipeHolders.Length; i++)
      {
         Vector3 temp = pipeHolders[i].transform.position;
         temp.y = Random.Range(pipeMin, pipeMax);

         pipeHolders[i].transform.position = temp;
      }

      lastPipe_X = pipeHolders[0].transform.position.x;

      for (int i = 1; i < pipeHolders.Length; i++)
      {
         var currentX = pipeHolders[i].transform.position.x;
         if (lastPipe_X < currentX)
         {
            lastPipe_X = currentX;
         }
      }
   }

   private void OnTriggerEnter2D(Collider2D target)
   {
      if (target.tag == "PipeHolder")
      {
         Vector3 temp = target.transform.position;

         temp.x = lastPipe_X + distance;
         temp.y = Random.Range(pipeMin, pipeMax);

         target.transform.position = temp;

         lastPipe_X = temp.x;
      }
   }
}