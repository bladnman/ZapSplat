using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Inventory {

  private List<Item> itemList;

  public Inventory() {
    itemList = new List<Item>();
  }

  public void AddItem(Item item) {
    itemList.Add(item);
  }
  public int CountOfType(Item.ItemType itemType) {
    return itemList.Aggregate(0, (acc, item) => item.itemType == itemType ? acc + 1 : acc);
  }

}
