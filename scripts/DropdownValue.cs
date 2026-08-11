using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DropdownValue : MonoBehaviour
{
    [SerializeField] public TMP_Dropdown dropdown;
    public GameObject dropdownObject;
    public int PickedEntryIndex;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDropdownValue()
    {
        //gets the value of the dropdown menu
        PickedEntryIndex = dropdown.value;

        Debug.Log(PickedEntryIndex);
    }
}
