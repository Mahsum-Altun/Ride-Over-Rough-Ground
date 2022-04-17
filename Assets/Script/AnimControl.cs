using UnityEngine;
public class AnimControl : MonoBehaviour
{
  Animator animator;
  //Get Rigidbody from CarMove class to use Rigidbody
  public CarMove rigid;
    
  void Start()
  {
    //Get the Animator
    animator = GetComponent<Animator>();
  }
  void Update()
  {
    //Adjust animation based on rigidbody speed
    float move = rigid.rb.velocity.magnitude;
    animator.SetFloat("Velocity", move);
  }

}