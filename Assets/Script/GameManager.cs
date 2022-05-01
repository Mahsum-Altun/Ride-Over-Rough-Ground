using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //is the game over
    bool gameHasEnded = false;
    //Scene load delay
    public float restartDelay = 1f;
    //Select the scene to load when it comes to an end
    public int nextSceneLoad;


   //win the level
   public void CompleteLevel()
   {
       //Upload next scene
         nextSceneLoad = SceneManager.GetActiveScene().buildIndex +1;
         SceneManager.LoadScene(nextSceneLoad);
         
         //Unlock the next scene
          if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
         {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
         }
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
   }

   //Load selected level
   public void LoadLevelNumber(int _index)
  {
      SceneManager.LoadScene(_index);
  }

}
