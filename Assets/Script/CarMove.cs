using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
  private bool moveLeft, moveRight, moveForward, moveBackward;
  //Create the rigidbody and the collider
  private Rigidbody rb;
  private Collider col;
  
  //Create a variable you can change in inspector windown for speed
  [SerializeField]
  private float speed;

  [SerializeField]
  private float smoothRotation;



  void Start ()
  {
      //Get the rigidbody and collider
      rb = GetComponent<Rigidbody>();
      col = GetComponent<Collider>();
  }



  void Update ()
  {
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


     if (moveForward)
     {
         rb.AddRelativeForce(Vector3.forward * speed); 

     } 


     if (moveBackward)
     {
         rb.AddRelativeForce(Vector3.back * speed);

     }
  
  
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
  }

  public void StopMovingForward ()
  {
      moveForward = false;
  }

  public void MoveBackward ()
  {
      moveBackward = true;
  }

  public void StopMovingBackward ()
  {
      moveBackward = false;
  }

}
