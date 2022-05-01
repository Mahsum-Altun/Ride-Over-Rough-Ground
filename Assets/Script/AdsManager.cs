using UnityEngine;
using UnityEngine.Advertisements;


public class AdsManager : MonoBehaviour, IUnityAdsListener
{
     private string gameID = ".....Type your game ID here......";
     private string Rewarded = "Rewarded_Android";
     private string Interstitial = "Interstitial_Android";
     private string Banner = "Banner_Android";
     public bool testMode = true;


      void Start() 
     {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, testMode);
     }  

     


     public void  rewarded()
     {
        if (Advertisement.IsReady(Rewarded))
        {
            Advertisement.Show(Rewarded);
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
     }

      public void OnDestroy()
    {
       Advertisement.RemoveListener(this);
    }

   
}

   
