using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//You can save anything you want in the game
public class SaveManager : MonoBehaviour
{
  public static SaveManager instance {get; private set;}

  //What we want to save
  
  //selected car
  public int currentCar;
  public int money;
  public bool [] carsUnlocked = new bool [2] {true, false};

  private void Awake()
  {
      if (instance != null && instance != this)
      Destroy(gameObject);
      else
      instance = this;

      DontDestroyOnLoad(gameObject);
      Load();
  }

  public void Load()
  {
      if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
      {
          BinaryFormatter bf = new BinaryFormatter();
          FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
          PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

          currentCar = data.currentCar;
          money = data.money;
          carsUnlocked = data.carsUnlocked;

          if (data.carsUnlocked == null)
          {
              carsUnlocked = new bool [2] {true, false};
          }

          file.Close();
      }
  }

  public void Save()
  {
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
      PlayerData_Storage data = new PlayerData_Storage();

      data.currentCar = currentCar;
      data.money = money;
      data.carsUnlocked = carsUnlocked;

      bf.Serialize(file, data);
      file.Close();
  }
}

[Serializable]
class PlayerData_Storage
{
    public int currentCar;
    public int money;
    public bool [] carsUnlocked;
}
