using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    //A UI panel that appears when you finish Level
    public GameObject complateLevelUI;
    //Button prefab inside the car
    public GameObject buttonUI;

   public void CompleteLevel()
   {
       complateLevelUI.SetActive(true);
       buttonUI.SetActive(false);
   }

   public void EndGame()
   {
       if (gameHasEnded == false)
       {
           gameHasEnded = true;
           Invoke ("Restart", restartDelay);
       }
   }

  public void Restart()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void Quit()
   {
       Application.Quit();
       Debug.Log("Quit");
   }

   //Loads the next level after the panel that appears when the level is completed
   public void LoadNextLevel()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);       
   }

   //Load selected level
   public void LoadLevelNumber(int _index)
  {
      SceneManager.LoadScene(_index);
  }
}
