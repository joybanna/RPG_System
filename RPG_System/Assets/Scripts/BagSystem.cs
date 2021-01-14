using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSystem : MonoBehaviour
{
    public List<DataItem> dataItems;
    public UIController uIController;
    private void Start()
    {
        dataItems = new List<DataItem>();
    }
    public void AddItem(string _dataitem)
    {
        DataItem data = dataItems.Find(item => item.itemName == _dataitem);
        if (data != null)
        {
            data.value += 1;
            uIController.UpdateUI(data);
            Debug.Log("data " + data.itemName + " : " + data.value);
        }
        else
        {
            DataItem newItem = new DataItem(_dataitem, 1);
            dataItems.Add(newItem);
            uIController.UpdateUI(newItem);
        }
    }
    public void UseItem(DataItem _dataitem, int _value)
    {
        foreach (DataItem data in dataItems)
        {
            if (_dataitem.itemName == data.itemName)
            {
                if (data.value > 0 && data.value - _value >= 0)
                {
                    data.value -= _value;
                    uIController.UpdateUI(data);
                }
                else
                {
                    Debug.Log("item not enough");
                }
            }
        }
    }
}
