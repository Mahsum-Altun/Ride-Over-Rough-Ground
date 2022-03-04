using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class PlayerMove : MonoBehaviour
{
    private bool moveLeft, moveRight,moveForward,moveBackward;

// Create the rigidbody and the collider
private Rigidbody rb;
private Collider col;

// Create a variable you can change in inspector window for speed
[SerializeField]
private float speed;

void Start ()
{
    // You can either use a CC (Character Controller) or a Rigidbody. Doesn't make that much of a difference.
    // Important thing is, if you use a rigidbody, you will need a collider as well. Collider detect collision
    // but rigidbodies do the actual work with regards to physics. In this case we use rigidbody/collider

    // Get the rigidbody
    // If you are making a 2D game, you should use Rigidbody2D
    // The rigidbody will simulate actual physics. I tested this script, the 
    // rigibody will accelerate and will need time to slow down upon breaking
    // You can change it's mass and stuff
    rb = GetComponent<Rigidbody>();

    // Now in this case we just get any collider. You can be more specific, if you know which collider your gameobjects has
    // e.g. BoxCollider or SphereCollider
    // If you are making a 2D game, you should use Collider2D
    col = GetComponent<Collider>();
}


void Update ()
{
    if (moveLeft)
    {
        // If you make a 2D game, use Vector2
        rb.AddForce(Vector3.left * speed);
        
    }
     if (moveRight)
    {
        // If you make a 2D game, use Vector2
        rb.AddForce(Vector3.right * speed);
       
    }
     if (moveForward)
    {
        // If you make a 2D game, use Vector2
        rb.AddForce(Vector3.forward * speed);
      
    }
     if (moveBackward)
    {
        // If you make a 2D game, use Vector2
        rb.AddForce(Vector3.back * speed);
    
    }
}

public void MoveLeft()
{
    moveLeft = true;
}

public void StopMovingLeft()
{
    moveLeft = false;
}
public void MoveRight()
{
    moveRight = true;
}

public void StopMovingRight()
{
    moveRight = false;
}
public void MoveForward()
{
    moveForward = true;
}

public void StopMovingForward()
{
    moveForward = false;
}
public void MoveBackward()
{
    moveBackward = true;
}

public void StopMovingBackward()
{
    moveBackward = false;
}




}
