using System.Collections;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
   public static SceneFader instance;

   [SerializeField]
   private GameObject fadeCanvas;

   [SerializeField]
   private Animator fadeAnimator;

   private void Awake()
   {
      MakeSingleton();
   }

   void MakeSingleton()
   {
      if (instance != null)
      {
         Destroy(gameObject);
      }
      else
      {
         instance = this;
         DontDestroyOnLoad(gameObject);
      }
   }

   IEnumerator FadeInAnimation(string levelName)
   {
      fadeCanvas.SetActive(true);
      fadeAnimator.Play("FadeIn");
      yield return StartCoroutine(BridgeCorutine.WaitForRealSeconds(0.7f));
      Application.LoadLevel(levelName);
      FadeOut();
   }

   IEnumerator FadeOutAnimation()
   {
      fadeAnimator.Play("FadeOut");
      yield return StartCoroutine(BridgeCorutine.WaitForRealSeconds(1f)); ;
      fadeCanvas.SetActive(false);
   }

   public void FadeOut()
   {
      StartCoroutine(FadeOutAnimation());
   }

   public void FadeIn(string levelName)
   {
      StartCoroutine(FadeInAnimation(levelName));
   }
}