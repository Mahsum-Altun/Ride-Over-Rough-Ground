using UnityEngine;

//Add the cars to be used in the game and bring them to the screen in order
public class CarModel : MonoBehaviour
{
   [SerializeField] private GameObject[] carModels;

   private void Awake()
   {
       //Add cars
       ChooseCarModel(SaveManager.instance.currentCar);
   }
   //Bring selected cars
   private void ChooseCarModel(int _index)
   {
       Instantiate(carModels[_index],transform.position, Quaternion.identity, transform);
   }
}
