using UnityEngine;
using UnityEngine.UI;

//Select cars with UI buttons
public class CarSelection : MonoBehaviour
{
    //Back UI button
   [SerializeField] private Button previousButton;
   //Forward UI button
   [SerializeField] private Button nextButton;
   private int currentCar;

   private void Start()
   {
       //Save currentCar to SaveManager.cs
       currentCar = SaveManager.instance.currentCar;
       SelectCar(currentCar);
   }

   private void SelectCar(int _index)
   {
       for (int i= 0; i < transform.childCount; i++)
       transform.GetChild(i).gameObject.SetActive(i == _index);
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
}
