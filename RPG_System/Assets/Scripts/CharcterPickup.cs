using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterPickup : MonoBehaviour
{
    public SensorCheckItem sensorCheckItem;
    public BagSystem bagSystem;
    private void LateUpdate()
    {
        if (sensorCheckItem.Pickup())
        {
            if (Input.GetKeyUp(KeyCode.E))
            {

                if (sensorCheckItem.GetItemPickup().CanPick())
                {
                    Debug.Log("pick");
                    sensorCheckItem.GetItemPickup().Pickup();
                    bagSystem.AddItem(sensorCheckItem.GetItemPickup().itemName);
                }

            }
        }
    }

}
