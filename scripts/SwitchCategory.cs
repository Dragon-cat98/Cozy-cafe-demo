using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SwitchCategory : MonoBehaviour
{
    public GameObject DrinksCategory;
    public GameObject UPSCategory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //functions to switch the drink categories
    public void SwitchCategoty_Drinks()
    {
        DrinksCategory.SetActive(true);
        UPSCategory.SetActive(false);
    }
    
    public void SwitchCategoty_UPS()
    {
        DrinksCategory.SetActive(false);
        UPSCategory.SetActive(true);
    }
}
