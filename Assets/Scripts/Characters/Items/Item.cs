using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

  public enum ItemType {
    KeyBlue,
    KeyYellow,
    KeyRed,
    KeyGreen,
  }

  public ItemType itemType;
  public int amount;

  public Item(ItemType itemType, int amount) {
    this.itemType = itemType;
    this.amount = amount;
  }

  // may not be needed in my world... but interesting from:
  // https://www.youtube.com/watch?v=2WnAOV7nHW0
  public Sprite GetSprite() {
    switch (itemType) {
      default:
      case ItemType.KeyBlue: return ItemAssets.Instance.keyBlue;
      case ItemType.KeyRed: return ItemAssets.Instance.keyRed;
      case ItemType.KeyYellow: return ItemAssets.Instance.keyYellow;
      case ItemType.KeyGreen: return ItemAssets.Instance.keyGreen;
    }
  }
}
