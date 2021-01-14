using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIItemUse : MonoBehaviour
{
    private UIController uIController;
    public string itemname;
    public Image cooldownMask;
    public TextMeshProUGUI value;
    public KeyCode key;
    private DataItem dataItem;
    private float cooldownTime;
    private void Start()
    {
        uIController = FindObjectOfType<UIController>();
        dataItem = new DataItem(itemname, 0);
        cooldownMask.fillAmount = 0f;
        value.text = "X 0";
    }
    private void Update()
    {
        if (Input.GetKeyUp(key) && cooldownTime <= 0)
        {
            if (dataItem.value > 0)
            {
                Debug.Log("use " + key.ToString());
                uIController.UseItem(dataItem);
                StartCoroutine(CooldownItem());
            }
        }
    }
    public void UpdateUI(DataItem _dataItem)
    {
        value.text = "X " + _dataItem.value;
        dataItem = _dataItem;
    }
    IEnumerator CooldownItem()
    {
        cooldownTime = 5f;
        while (cooldownTime > 0)
        {
            cooldownTime -= Time.deltaTime;
            if (cooldownTime < 0)
            {
                cooldownTime = 0;
            }
            cooldownMask.fillAmount = cooldownTime / 5f;
            yield return new WaitForEndOfFrame();
        }
    }

}
