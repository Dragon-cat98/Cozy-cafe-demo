using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


[ExecuteInEditMode()]
public class ToolTip : MonoBehaviour
{
    //got from a tooltip tutorial video: https://youtu.be/HXFoUGw7eKk?si=6cV8c062ctGSAPD_
    
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentfield;
    public LayoutElement layoutElement;
    public int characterWrapLimit;
    public RectTransform rectTransform;
    public ButtonManager buttonManager;
    public int cost;
    public ToolTipTrigger toolTipTrigger;
    public bool isUpgrade;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        buttonManager = Object.FindAnyObjectByType<ButtonManager>();
    }


    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }
        if (isUpgrade == false)
        {
            contentfield.text = content;
        }
        else if (isUpgrade == true)
        {
            contentfield.text = content + "\ncost:" + cost;
        }

        int headerLenght = headerField.text.Length;
        int contentLenght = contentfield.text.Length;

        layoutElement.enabled = (headerLenght > characterWrapLimit || contentLenght > characterWrapLimit) ? true : false;

    }


    void Update()
    {
        if (Application.isEditor)
        {
            int headerLenght = headerField.text.Length;
            int contentLenght = contentfield.text.Length;

            layoutElement.enabled = (headerLenght > characterWrapLimit || contentLenght > characterWrapLimit) ? true : false;
        }

        Vector2 position = Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;


        rectTransform.pivot = new Vector2(pivotX + 0.2f, pivotY + 0.2f);
        transform.position = position;


    }
}
