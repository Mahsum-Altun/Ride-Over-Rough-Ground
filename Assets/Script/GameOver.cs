using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;
    
    //Call EndGame method from GameManager.cs when collider with GameOver collider
    void OnTriggerEnter() 
   {
      FindObjectOfType<GameManager>().EndGame();   
   }

}
