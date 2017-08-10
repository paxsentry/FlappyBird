using UnityEngine;

public class CameraScript : MonoBehaviour
{

   public static float offsetX;

   void Start() { }

   void Update()
   {
      if (BirdScript.instance != null)
      {
         if (BirdScript.instance.isAlive)
         {
            MoveThaCamera();
         }
      }
   }

   void MoveThaCamera()
   {
      Vector3 temp = transform.position;
      temp.x = BirdScript.instance.GetPositionX() + offsetX;

      transform.position = temp;
   }
}