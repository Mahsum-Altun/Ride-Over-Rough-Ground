using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimControl : CarMove
{
  Animator animator;
  private bool animPlay, animStop;
    
  void Start()
  {
    //Get the Animator
    animator = GetComponent<Animator>();
  }
   void Update()
  {
      //Adjust animation based on rigidbody speed
      float move = rb.velocity.magnitude;
      animator.SetFloat("Velocity", move);
  }



}