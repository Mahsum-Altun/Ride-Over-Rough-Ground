using UnityEngine;
using UnityEngine.UI;

//Select cars with UI buttons
public class CarSelection : MonoBehaviour
{
    [Header ("Navigation Buttons")]
    //Back UI button
   [SerializeField] private Button previousButton;
   //Forward UI button
   [SerializeField] private Button nextButton;

   [Header ("Play/Buy Buttons")]
   [SerializeField] private Button play;
   [SerializeField] private Button buy;
   [SerializeField] private Text priceText;

   [Header ("Car Attributes")]
   [SerializeField] private int[] carPrices; 
   private int currentCar;

   private void Start()
   {
       //Save currentCar to SaveManager.cs
       currentCar = SaveManager.instance.currentCar;
       SelectCar(currentCar);
   }

   private void SelectCar(int _index)
   {
       //Close the UIbutton when the number of cars is over
       previousButton.interactable = (_index != 0);
       //Close the UIbutton when the number of cars is over
       nextButton.interactable = (_index != transform.childCount -1);
       for (int i= 0; i < transform.childCount; i++)
       transform.GetChild(i).gameObject.SetActive(i == _index);
       //Update UIbutton on vehicle purchase
       UpdateUI();
   }
   private void UpdateUI()
   {
        if (SaveManager.instance.carsUnlocked [currentCar])
       {
           play.gameObject.SetActive(true);
           buy.gameObject.SetActive(false);
       }
       else
       {
           play.gameObject.SetActive(false);
           buy.gameObject.SetActive(true);
           priceText.text = carPrices[currentCar] + "$";
       }
       //Check if we have enough money
       buy.interactable = (SaveManager.instance.money >= carPrices[currentCar]);

   }

   public void ChangeCar(int _change)
   {
       currentCar += _change;

       if(currentCar > transform.childCount -1)
       currentCar += 0;
       else if (currentCar < 0)
       currentCar = transform.childCount -1;

       SaveManager.instance.currentCar = currentCar;
       SaveManager.instance.Save();
       SelectCar(currentCar);
   }

   public void BuyCar()
   {
       SaveManager.instance.money -= carPrices[currentCar];
       SaveManager.instance.carsUnlocked[currentCar] = true; 
       SaveManager.instance.Save();
       UpdateUI();
   }
}
