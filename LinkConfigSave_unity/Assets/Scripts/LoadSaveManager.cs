using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.U2D;
using Newtonsoft.Json;

public class LoadSaveManager : MonoBehaviour
{

	public static event Action<AdventurerConfig> OnConfigLoaded = delegate { }; // Shouting that new config loaded from disk

	private static LoadSaveManager _instance;

	private string _savePath = "";

	public static LoadSaveManager Instance
	{
		get
		{
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
		string configJson = JsonConvert.SerializeObject(config); // Convert (serialize) our objects to a JSon string

		File.WriteAllText(_savePath, configJson); // Save file
		return true;
	}

	private void LoadButton_OnLoadRequested()
	{
		// load
		Debug.Log(" LoadSaveManager heard about a load click");

		if (File.Exists(_savePath)) // Don't try to load a file that isn't there
		{
			string loadedJson = File.ReadAllText(_savePath); // read existing file

			AdventurerConfig loadedConfig = JsonConvert.DeserializeObject<AdventurerConfig>(loadedJson); // string back to sprite config object

			// Throw event out to the world with the new config attached
			OnConfigLoaded(loadedConfig);
		}

	}
}
