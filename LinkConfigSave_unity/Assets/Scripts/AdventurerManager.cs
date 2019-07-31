using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerManager : MonoBehaviour {

  //public static event Action OnAdventurerModified = delegate { };
  AdventurerConfig _config;
  private int numAdventurerSprites = 0;

  void Awake ()
  {
    _config = new AdventurerConfig();
    // Get listener set up for any loading or other changes. Don't want to miss out.
    //LoadButton.OnLoadRequested += LoadButton_OnLoadRequested;
    // Actually we should be listening for the load/save manager
    NextButton.OnNextRequested += NextButton_OnNextRequested;
    LoadSaveManager.OnConfigLoaded += LoadSaveManager_OnConfigLoaded;
    SaveButton.OnSaveRequested += SaveButton_OnSaveRequested;
  }

  private void Start()
  {
    
  }

  private void NextButton_OnNextRequested()
  {
    // How many adventurers are there? have to ask the game/atlas manager;
    // Then we can go up to count-1 and back to zero.
    Debug.Log("AdventurerManager heard about Next.");
    _config.pictureId += 1;
    gameObject.BroadcastMessage("ApplyAdventurerConfig", _config);
  }

  private void SaveButton_OnSaveRequested()
  {
    Debug.Log("AdventurerManager heard someone wants a save.");
    // send out the config for saving
    LoadSaveManager.Instance.Save(_config);
  }

  private void LoadSaveManager_OnConfigLoaded( AdventurerConfig loadedConfig )
  {
    Debug.Log("AdventurerManager heard about save request.");
    gameObject.BroadcastMessage("ApplyAdventurerConfig", loadedConfig);
  }

}
