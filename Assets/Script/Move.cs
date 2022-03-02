using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool Ispressend;
    public GameObject player;
    public float RotateSpeed = 0.1f;
    
  
    
    void Update() 
    {
        if (Input.GetButtonDown("Horizontal"))
            transform.Rotate(-Vector3.right * Time.deltaTime);
        /*else if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);*/
       if (Ispressend)
       {
           player.transform.Translate(0, 0,2f, 0);
           
       }       
     
    }

    public void OnPointerDown(PointerEventData eventData)
    {
         Ispressend = true;
    }

        public void OnPointerUp(PointerEventData eventData)
    {
        Ispressend = false;
    }

}
