using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorCheckItem : MonoBehaviour
{
    public float length;
    public LayerMask layer;
    private int temp_idItem;
    private ItemPickup temp_itemPickup;
    private RaycastHit hit;
    private bool canPick;
    private void LateUpdate()
    {

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * length, Color.yellow);

        if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit, length, layer))
        {
            if (hit.collider.GetInstanceID() != temp_idItem)
            {
                if (hit.collider.gameObject.GetComponent<ItemPickup>() != null)
                {
                    temp_idItem = hit.collider.GetInstanceID();
                    temp_itemPickup = hit.collider.gameObject.GetComponent<ItemPickup>();
                    temp_itemPickup.ShowText(true);
                    canPick = true;
                }
            }
            else
            {
                temp_itemPickup.ShowText(true);
                canPick = true;
            }
        }
        else
        {
            if (temp_itemPickup != null)
            {
                temp_itemPickup.ShowText(false);
                canPick = false;
            }
        }
    }
    public bool Pickup()
    {
        return canPick;
    }
    public ItemPickup GetItemPickup()
    {
        return temp_itemPickup;
    }
}
