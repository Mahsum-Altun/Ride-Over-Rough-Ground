using UnityEngine;

public class AdsTrigger : MonoBehaviour
{
  public AdsManager adsManager;

  private void OnTriggerEnter(Collider other) 
  {
    adsManager.interstitial();
  }
}
