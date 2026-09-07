using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    //got from a tooltip tutorial video: https://youtu.be/HXFoUGw7eKk?si=6cV8c062ctGSAPD_

    public static ToolTipSystem current;
    public ToolTip tooltip;
    public void Awake()
    {
        current = this;
    }

    public static void Show(string content, string header = "")
    {
        current.tooltip.SetText(content, header);
        current.tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        current.tooltip.gameObject.SetActive(false);
    }
}
