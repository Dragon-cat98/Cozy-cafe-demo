using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //got from a tooltip tutorial video: https://youtu.be/HXFoUGw7eKk?si=6cV8c062ctGSAPD_

    public string content;
    public string header;
    public ToolTip toolTip;
    public ButtonManager buttonManager;
    void Start()
    {

    }
    void Update()
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        ToolTipSystem.Hide();
        if (toolTip.isUpgrade == true)
            toolTip.isUpgrade = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(ToolTipDelay(1f));

        if (header == "More money")
        {
            toolTip.cost = buttonManager.Cost;
            Debug.LogError(toolTip.cost);
            toolTip.isUpgrade = true;
        }
        else if (header == "More Customers")
        {
            toolTip.cost = buttonManager.cost2;
            Debug.LogError(toolTip.cost);
            toolTip.isUpgrade = true;

        }
        else if (header == "More Coffe")
        {
            toolTip.cost = buttonManager.cost3;
            Debug.LogError(toolTip.cost);
            toolTip.isUpgrade = true;
        }


    }

    IEnumerator ToolTipDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ToolTipSystem.Show(content, header);
    }
}
