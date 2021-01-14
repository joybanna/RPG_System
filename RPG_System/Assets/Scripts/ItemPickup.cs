using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string itemName;
    public int value;
    public GameObject interactText;
    private bool isEnough;

    public void Pickup()
    {
        value--;
    }
    public void ShowText(bool _isShow)
    {
        interactText.gameObject.SetActive(_isShow);
        StartCoroutine(TextLookAt(_isShow));

    }
    IEnumerator TextLookAt(bool _isLook)
    {
        while (_isLook)
        {
            yield return new WaitForEndOfFrame();
            interactText.transform.LookAt(Camera.main.transform);
        }
    }
    public bool CanPick()
    {
        if (value > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
