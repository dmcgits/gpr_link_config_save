using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerSpriteChanger : MonoBehaviour
{
  private SpriteRenderer _spriteRenderer;
   
  private void Awake()
  {
    // Cache the renderer now and we don't have to call GetComponent ever again.
    _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
  }

  public void ApplyAdventurerConfig( AdventurerConfig config )
  {
    Debug.Log("Change to sprite: adventurer_" + config.pictureId);
    Sprite adventurerSprite = AtlasManager.Instance.GetSprite("adventurer", config.pictureId);

	if (adventurerSprite != null)
    {
      _spriteRenderer.sprite = adventurerSprite;
    } else
    {
      Debug.Log("Couldn't get a sprite man.");
    }
  }

}
