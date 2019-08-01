//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

// Super simple class, nothing Unity about it.
public class AdventurerConfig
{
  public string name = "GRORGNAR";
  public int pictureId = 1;

  public AdventurerConfig()
  {
    // go with defaults.
  }

  public AdventurerConfig(string name, int pictureId=1)
  {
    // There are other ways to initialize public variables on objects
    // but I'll keep to what we know for now
    this.name = name;
    this.pictureId = pictureId;
  }
}
