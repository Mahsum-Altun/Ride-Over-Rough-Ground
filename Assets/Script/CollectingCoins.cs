using UnityEngine;

public class CollectingCoins : MonoBehaviour
{
   public int coins;

   public void OnTriggerEnter(Collider Col) 
   {
       if (Col.gameObject.tag == "Coin")
       {
           SaveManager.instance.money += 1;
           SaveManager.instance.Save();
           Destroy(Col.gameObject);
       }
   }
}
