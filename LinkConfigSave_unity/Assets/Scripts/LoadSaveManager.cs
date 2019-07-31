using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.U2D;
using Newtonsoft.Json;

public class LoadSaveManager : MonoBehaviour {

  public static event Action<AdventurerConfig> OnConfigLoaded = delegate { };

  private static LoadSaveManager _instance;

  private string _savePath = "";
  
  public static LoadSaveManager Instance
  {
    get {
      return _instance; 
     }
    private set
    {
      _instance = value;
    }

  }

  void Awake()
  {
    // Check if instance exists
    if (Instance == null)
    {
      //if not, set instance to this
      Instance = this;
    }
    //If instance already exists and it's not this:
    else if (Instance != this)
    {
      //Then wipe self. Zero mercy for late arrivals.
      Destroy(gameObject);
    }

    //Sets this one to not be destroyed when reloading scene
    DontDestroyOnLoad(gameObject);

    // Prepare for save and load
    _savePath = Path.Combine(Application.persistentDataPath, "adventurer_config.json");
    LoadButton.OnLoadRequested += LoadButton_OnLoadRequested;
    //SaveButton.OnSaveRequested += SaveButton_OnSaveRequested;
  }

  // You could have several overloads of the Save function taking different types of config file.
  // Keeps the callers from having to know lots of function names
  public bool Save(AdventurerConfig config)
  {
    // save
    Debug.Log("LoadSave trying to save AdventurerConfig");
    return true;
  }

  private void LoadButton_OnLoadRequested()
  {
    // load
    Debug.Log(" LoadSaveManager heard about a load click");
    AdventurerConfig config = new AdventurerConfig();
    config.pictureId = 3;
    // Send out a default config for testing.
    // Replace with all the loady stuff.
    OnConfigLoaded(config);
  }

}
