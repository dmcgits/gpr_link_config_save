using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AtlasManager : MonoBehaviour {

  [SerializeField]
  private SpriteAtlas _spriteAtlas;

  private static AtlasManager _instance;

  public static AtlasManager Instance
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
    /// If this is the first GameManager instance, store self in a static forever. 
    /// If not, self-destruct because that static position has been filled.
    
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
  }

  public int NumberOfSprites( string name )
  {
    int numSpritesFound = 0;
    bool spriteWasFound = true;
    Sprite spriteFromAtlas = null;

    while( spriteWasFound )
    {
      // We'll check for _1 first.
      spriteFromAtlas = _spriteAtlas.GetSprite(name + "_" + (numSpritesFound+1));
      
      if (spriteFromAtlas == null)  // if nothing came from atlas
      {
        spriteWasFound = false;
      } else { 
        numSpritesFound += 1;
      }
    }
    return (numSpritesFound);
  }

  public Sprite GetSprite( string name, int id )
  {
    Sprite spriteFromAtlas = _spriteAtlas.GetSprite(name + "_" + id);

    return (spriteFromAtlas);
  }
}
