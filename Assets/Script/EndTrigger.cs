using UnityEngine;


//Upload new level
public class EndTrigger : MonoBehaviour
{
   //Button prefab inside the car
   public GameObject buttonUI;
   //A UI panel that appears when you finish Level
   public GameObject complateLevelUI;


   public void OnTriggerEnter(Collider other) 
   {
     if (gameObject.tag == "Player")
     {
       complateLevelUI.SetActive(true);
       buttonUI.SetActive(false);
     }
   }
}
