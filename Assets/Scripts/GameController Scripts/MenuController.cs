using UnityEngine;

public class MenuController : MonoBehaviour
{
   public static MenuController instance;

   [SerializeField]
   private GameObject[] _birds;

   private bool isGreenBirdUnlocked;
   private bool isRedBirdUnlocked;

   private void Awake()
   {
      MakeInstance();
   }

   void Start()
   {
      _birds[GameController.instance.GetSelectedBird()].SetActive(true);
      CheckUnlockedBirds();
   }

   void Update()
   {

   }

   void MakeInstance()
   {
      if (instance == null)
      {
         instance = this;
      }
   }

   void CheckUnlockedBirds()
   {
      if (GameController.instance.IsGreenBirdUnlocked() == 1)
      {
         isGreenBirdUnlocked = true;
      }

      if (GameController.instance.IsRedBirdUnlocked() == 1)
      {
         isRedBirdUnlocked = true;
      }
   }

   public void ChangeBird()
   {
      if (GameController.instance.GetSelectedBird() == 0)
      {
         if (isGreenBirdUnlocked)
         {
            _birds[0].SetActive(false);
            GameController.instance.SetSelectedBird(1);

            _birds[GameController.instance.GetSelectedBird()].SetActive(true);

         }
      }
      else if (GameController.instance.GetSelectedBird() == 1)
      {
         if (isRedBirdUnlocked)
         {
            _birds[1].SetActive(false);
            GameController.instance.SetSelectedBird(2);
            _birds[GameController.instance.GetSelectedBird()].SetActive(true);
         }
         else
         {
            _birds[1].SetActive(false);
            GameController.instance.SetSelectedBird(0);
            _birds[GameController.instance.GetSelectedBird()].SetActive(true);
         }
      }
      else if (GameController.instance.GetSelectedBird() == 2)
      {
         _birds[2].SetActive(false);
         GameController.instance.SetSelectedBird(0);
         _birds[GameController.instance.GetSelectedBird()].SetActive(true);
      }
   }
}