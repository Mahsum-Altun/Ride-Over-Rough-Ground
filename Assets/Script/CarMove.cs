using UnityEngine;
using UnityEngine.UI;

public class CarMove : MonoBehaviour
{
  private bool moveLeft, moveRight, moveForward, moveBackward;
  //Create the rigidbody and the collider
  public Rigidbody rb;
  private Collider col;
  //Create a variable you can change in inspector windown for speed
  [SerializeField]
  private float speed;
  [SerializeField]
  private float smoothRotation;
  public Rigidbody rbGo;
  //Create a variable for the PlayerCollider class
  PlayerCollider m_playerCollider;
  //Created to tune the sound of an object in the air and on the ground
  public AudioSource audioSource1, audioSource2, audioSource3;
  public Button leftButton;
  public Button rightButton;
  public bool blocksRaycasts;
  public CanvasGroup canvasGroup;  
  //Add effect
  [SerializeField] ParticleSystem collectParticle;
  //Add effect
  [SerializeField] ParticleSystem collectParticle2;

  void Start ()
  {
    //Get the PlayerCollider class
    m_playerCollider = GetComponent<PlayerCollider>();
    //Get the collider
    col = GetComponent<Collider>();
  }

  void Update ()
  {  
    //Reset speed when object turns upside down
    float dot = Vector3.Dot(transform.up,Vector3.up);
    if (dot <= -0.5f)
    {
        speed = 0;
    }
     //Is OnCollisionStay on the ground?
     if (m_playerCollider.IsOnGround)
     {
         //Moves the object forward
        if (moveForward)
        {
          rb.AddRelativeForce(Vector3.forward * speed * Time.deltaTime); 
        } 
        //Moves the object backwards
        if (moveBackward)
        {
          rb.AddRelativeForce(Vector3.back * speed * Time.deltaTime);
        }
        //Turns up sound if OnCollisionStay is on the ground
        audioSource1.volume = 0.11f;
        audioSource2.volume = 0.11f;
        audioSource3.volume = 0.11f;
     }

     else
    {
        //OnCollisionStay mutes sound if in mid-air
        audioSource1.volume = 0f;
        audioSource2.volume = 0f;
        audioSource3.volume = 0f;
    }
     //Get the vehicle's speed
     var velocity = rb.velocity;
     var localVel = transform.InverseTransformDirection(velocity);

     if (moveLeft)
     {
        // Turn the vehicle direction to the left
        transform.Rotate(Vector3.up, -90 * smoothRotation * Time.deltaTime);
        // Go in the direction the vehicle is facing     
        if (localVel.z > 0) 
        {
            rb.velocity = transform.forward * rb.velocity.magnitude;
        }
         else
         {
             rb.velocity = -transform.forward * rb.velocity.magnitude;
         }
     }
     if (moveRight)
     {
        // Turn the vehicle direction to the right
       transform.Rotate(Vector3.up, 90 * smoothRotation * Time.deltaTime);
        // Go in the direction the vehicle is facing
        if (localVel.z > 0)
        {
            rb.velocity = transform.forward * rb.velocity.magnitude;
        }
        else 
        {
            rb.velocity = -transform.forward * rb.velocity.magnitude;
        }
     }
    }
    //Is the vehicle on the ground?
    private void OnCollisionStay(Collision other) 
    {
         //Gravity if the vehicle is on the ground
        Physics.gravity = new Vector3(0, -15f, 0);
        rightButton.interactable = true;
        leftButton.interactable = true;
        //Right and left UI buttons can be used if the vehicle is on the ground
        canvasGroup.blocksRaycasts = true;
    }
    //Is the vehicle in the air?
    private void OnCollisionExit(Collision other) 
    {
        //Gravity if the vehicle is in the air
        Physics.gravity = new Vector3(0, -40f, 0);
        rightButton.interactable = false;
        leftButton.interactable = false;
        //Right and left UI buttons are not available if the vehicle is in the air
        canvasGroup.blocksRaycasts = false;
    }
  
 public void MoveLeft ()
  {
    moveLeft = true;
  }
  public void StopMovingLeft ()
  {
    moveLeft = false;
  }
  public void MoveRight ()
  {
    moveRight = true; 
  }
  public void StopMovingRight ()
  {
    moveRight = false;
  }
  public void MoveForward ()
  {
    moveForward = true;
    //OnCollisionStay stops when a rigidbody sleeps Wake rigidbody when asks OnCollisionStay to run
    rbGo.WakeUp();
    //Play effect
    collectParticle.Play();
    //Play effect
    collectParticle2.Play();
  }
  public void StopMovingForward ()
  {
    moveForward = false;
    //Stop effect
    collectParticle.Stop();
    //Stop effect
    collectParticle2.Stop();
  }
  public void MoveBackward ()
  {
    moveBackward = true;
    //OnCollisionStay stops when a rigidbody sleeps Wake rigidbody when asks OnCollisionStay to run
    rbGo.WakeUp();
    //Play effect
    collectParticle.Play();
    //Play effect
    collectParticle2.Play();
  }
  public void StopMovingBackward ()
  {
    moveBackward = false;
    //Stop effect
    collectParticle.Stop();
    //Stop effect
    collectParticle2.Stop();
  }
  

}
