using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{

   public static BirdScript instance;

   [SerializeField]
   private Rigidbody2D _rigidBody;

   [SerializeField]
   private Animator _animator;
   private float forwardSpeed = 3f;
   private float bounceSpeed = 4f;

   private bool didFlap;
   private Button flapButton;

   public bool isAlive;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }

      isAlive = true;
      flapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
      flapButton.onClick.AddListener(() => FlapTheBird());

      SetCameraX();
   }

   void Start() { }

   void FixedUpdate()
   {
      if (isAlive)
      {
         Vector3 temp = transform.position;
         temp.x += forwardSpeed * Time.deltaTime;
         transform.position = temp;

         if (didFlap)
         {
            didFlap = false;
            _rigidBody.velocity = new Vector2(0, bounceSpeed);
            _animator.SetTrigger("Flap");
         }

         if (_rigidBody.velocity.y >= 0)
         {
            transform.rotation = Quaternion.Euler(0, 0, 0);
         }
         else
         {
            float angle = 0;
            angle = Mathf.Lerp(0, -90, -_rigidBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle);
         }
      }
   }

   public void FlapTheBird()
   {
      didFlap = true;
   }

   public float GetPositionX()
   {
      return transform.position.x;
   }

   void SetCameraX()
   {
      CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
   }
}