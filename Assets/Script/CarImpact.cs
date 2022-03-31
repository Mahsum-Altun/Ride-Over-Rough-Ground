using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarImpact : MonoBehaviour
{
    //Create impact clip
    public AudioClip impact;
    public AudioSource carSound;
    //Create collision detector
      void OnCollisionEnter(Collision collision) 
  {
    foreach (ContactPoint contact in collision.contacts)
    {
      Debug.DrawRay(contact.point, contact.normal, Color.white);
    }
    //Play impact sound if velocity is greater than 12
    if (collision.relativeVelocity.magnitude > 12)
    {
        //Play impact sound
       carSound.PlayOneShot(impact);
    }  
  }

}
