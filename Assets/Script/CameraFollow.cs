using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public GameObject target;
  public float speed = 5;
  public Vector3 offset;
  //Add kinematic Rigidbody for camera shake
  public Rigidbody rb;
    
 
    private void Start()
    {
        //Get the Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var newRotation = Quaternion.LookRotation(target.transform.position - rb.position + Vector3.zero);
        rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, speed * Time.deltaTime);
        Vector3 newPosition = target.transform.position - target.transform.forward * offset.z - target.transform.up * offset.y;
        rb.position = Vector3.Slerp(rb.position, newPosition, Time.deltaTime * speed);
    }
    
    //forward UI button
    public void Forward()
    {
        //Adjust camera speed if button is pressed
        speed = 10;
    }
    //Backward UI button
    public void Backward()
    {
        //Adjust camera speed if button is pressed
        speed = 5;
    }
}
