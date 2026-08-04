using UnityEngine;
using UnityEngine.UI;
public class LoadPanel : MonoBehaviour
{
    public GameObject [] panel;
    /*This script makes it easier to load and unload panels, and you can modify it based on how many panels you need*/
    //you need to create a panel manager gameobject and assign it the scripts
    //then add the panel to the array
    //then on the button you want to use to load the panel you need to add the function PanelLoad() 
    //and on the button you want to use to unload the panel you need to add the function PanelUnLoad()
    //(you need to assign the panelmanager gameobject to the button as well)
    public void PanelLoad()
    {
        //loads the first panel in the array
        panel[0].SetActive(true);
    }
    public void PanelUnLoad()
    {
        //unloads the first panel in the array
        panel[0].SetActive(false);
    }

    public void PanelLoad2()
    {
        panel[1].SetActive(true);
    }
    public void PanelUnLoad2()
    {
        panel[1].SetActive(false);
    }

    public void PanelLoad3()
    {
        panel[2].SetActive(true);
    }
    public void PanelUnLoad3()
    {
        panel[2].SetActive(false);
    }
    
    public void PanelLoad4()
    {
        panel[3].SetActive(true);
    }
    public void PanelUnLoad4()
    {
        panel[3].SetActive(false);
    }
    

}
