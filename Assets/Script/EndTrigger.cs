using UnityEngine;

//Upload new level
public class EndTrigger : MonoBehaviour
{
   public GameManager gameManager;

   void OnTriggerEnter() 
   {
      gameManager.CompleteLevel();    
   }
}
