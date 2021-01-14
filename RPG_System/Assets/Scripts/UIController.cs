using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public CharcterPickup charcterPickup;
    public BagSystem bagSystem;
    public UIItemUse[] uIItemUses;

    public void UpdateUI(DataItem _dataItem)
    {
        foreach (UIItemUse item in uIItemUses)
        {
            if (item.itemname == _dataItem.itemName)
            {
                Debug.Log("PickupUpdateUI value : " + _dataItem.value);
                item.UpdateUI(_dataItem);
            }
        }
    }
    public void UseItem(DataItem _dataItem)
    {
        bagSystem.UseItem(_dataItem, 1);
    }
}


