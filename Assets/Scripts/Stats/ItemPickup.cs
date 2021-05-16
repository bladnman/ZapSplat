using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

public class ItemPickup : Collectible {
  [SerializeField] ItemType itemType;
  [SerializeField] int count = 1;
  [SerializeField] bool allowMultiples = true;

  public override void DoCollection(GameObject collector) {
    Inventory inventory = GetInventory(collector);
    inventory.AddItem(new Item(itemType, count));
  }

  public virtual Inventory GetInventory(GameObject source) {
    Inventory inventory = ((Player)source.GetComponent<Player>())?.inventory;
    if (inventory != null) {
      return inventory;
    }
    // try as component
    if (source.TryGetComponent<Inventory>(out inventory)) return inventory;
    return null;
  }

  public override bool IsCollectableBy(GameObject collector) {
    return InventoryWillAllow(collector);
  }
  bool InventoryWillAllow(GameObject collector) {
    var inventory = GetInventory(collector);
    if (inventory == null) return false;
    if (!allowMultiples && inventory.CountOfType(itemType) > 0) return false;

    return true;
  }
}
