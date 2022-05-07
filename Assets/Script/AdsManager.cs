using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System.Collections;


public class AdsManager : MonoBehaviour, IUnityAdsListener
{
     private string gameID = "4730193";
     private string Rewarded = "Rewarded_Android";
     private string Interstitial = "Interstitial_Android";
     private string Banner = "Banner_Android";
     public bool testMode = true;
     public Button rewardedButton;


      void Start() 
     {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, testMode);
        rewardedButton.interactable = Advertisement.IsReady (gameID); 
        StartCoroutine (ShowBannerWhenReady ());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
     }  

     IEnumerator ShowBannerWhenReady () 
     {
        while (!Advertisement.IsReady (Banner)) 
        {
            yield return new WaitForSeconds (0.5f);
        }
        Advertisement.Banner.Show(Banner);
    }

     


     public void  rewarded()
     {
        if (Advertisement.IsReady(Rewarded))
        {
            Advertisement.Show(Rewarded);
            SaveManager.instance.money += 30;
            SaveManager.instance.Save();
        }
        else
        {
            Debug.Log("Rewarded not loaded");
        }
     }

     public void interstitial()
     {
        if (Advertisement.IsReady(Interstitial))
        {
            Advertisement.Show(Interstitial);
        }
        else
        {
            Debug.Log("Interstitial not loaded");
        }
     }

     public void banner()
     {
        if (Advertisement.IsReady(Banner))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(Banner);
        }
        else
        {
            Debug.Log("Banner not loaded");
        }
     }

     public void HideBanner()
     {
         Advertisement.Banner.Hide();
     }

     public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
     {
         if (showResult == ShowResult.Finished)
         {
             Debug.Log("Rewarded");
         }
         
         if (showResult == ShowResult.Skipped)
         {
             Debug.Log("Ads Skip");
         }
         
         if (showResult == ShowResult.Failed)
         {
             Debug.LogWarning("Error ADS Failed");
         }
     }

     public void OnUnityAdsDidError(string message)
     {
        Debug.Log("Ads not loaded:" + message);
     }

     public void OnUnityAdsDidStart(string placementId)
     {
         Debug.Log("Ads started:" + placementId);
     }

     public void OnUnityAdsReady(string placementId)
     {
         Debug.Log("Ready" + placementId);
         rewardedButton.interactable = true;
     }

      public void OnDestroy()
    {
       Advertisement.RemoveListener(this);
    }

   
}

   
