using UnityEngine;

public class BirdScript : MonoBehaviour {

   public static BirdScript instance;

   [SerializeField]
   private Rigidbody2D _rigidBody;

   [SerializeField]
   private Animator _animator;
   private float forwardSpeed = 3f;
   private float bounceSpeed = 4f;

   private bool didFlap;

   public bool isAlive;

   private void Awake()
   {
      if(instance == null)
      {
         instance = this;
      }

      isAlive = true;
   }

   void Start () {
		
	}
	
	void FixedUpdate () {
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
      }
	}

   public void FlapTheBird()
   {
      didFlap = true;
   }
}