using UnityEngine;

public class CollectingCoins : MonoBehaviour
{
   public int coins;
   public AudioSource CoinSource;
   public AudioClip CoinClip;

   public void OnTriggerEnter(Collider Col) 
   {
       if (Col.gameObject.tag == "Coin")
       {
           SaveManager.instance.money += 1;
           SaveManager.instance.Save();
           Destroy(Col.gameObject);
           CoinSource.PlayOneShot(CoinClip);
       }
   }
}
