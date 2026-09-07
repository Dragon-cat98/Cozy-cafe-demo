using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class DrinkUnlockManager : MonoBehaviour
{
    public GameManager gameManager;
    public DropdownValue dropdownValue;
    [SerializeField] private Button [] UnlockDrinks;
    public bool UnlockedCoffe = false;
    public int UnlockCoffePrice;
    public bool UnlockedOrange = false;
    public int UnlockOrangePrice;

    [SerializeField] private GameObject CoffeRemoveObject;
    [SerializeField] private GameObject OrangeRemoveObject;
    [SerializeField] private GameObject CoffeDisplayObject;
    [SerializeField] private GameObject OrangeDisplayObject;
    [SerializeField] private GameObject OrangeLock;
    [SerializeField] private GameObject MoneyTextObject;


    [SerializeField] private TextMeshProUGUI UnlockedCoffeText;
    [SerializeField] private TextMeshProUGUI UnlockedOrangeText;

    public ToolTipTrigger toolTipTriggerOrange;

    
    void Start()
    {
        gameManager = Object.FindAnyObjectByType<GameManager>();
        dropdownValue = Object.FindAnyObjectByType<DropdownValue>();

        OrangeRemoveObject.SetActive(false);
        CoffeRemoveObject.SetActive(false);
        OrangeDisplayObject.SetActive(false);
        CoffeDisplayObject.SetActive(false);

        //starts the coroutine to unlock the coffe
        StartCoroutine(StartCoffeUnlock());
        OrangeLock.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the palyer has enough money to buy the coffe and if he already has
        if(gameManager.money >= UnlockCoffePrice && UnlockedCoffe == false)
        {
            UnlockDrinks[0].interactable = true;
        }
        else
        {
            UnlockDrinks[0].interactable = false;
        }

        //checks if the palyer has enough money to buy the OJ and if he already has
        if(gameManager.money >= UnlockOrangePrice && UnlockedOrange == false && ClockScript.instance.day >= 2)
        {
            UnlockDrinks[1].interactable = true;
        }
        else
        {
            UnlockDrinks[1].interactable = false;
        }

        if(ClockScript.instance.day >= 2)
        {
            //checks if the player arrived at day 2, if so unlocks the possibility to unlock the OJ
            OrangeLock.SetActive(false);
        }
    }

    public void UnlockCoffe()
    {
        //unlocks the coffe drink
        dropdownValue.dropdown.options.Add(new TMPro.TMP_Dropdown.OptionData("Coffe", null, Color.black));
        UnlockedCoffe = true;
        dropdownValue.dropdown.RefreshShownValue();
        CoffeRemoveObject.SetActive(true);
        CoffeDisplayObject.SetActive(true);
        gameManager.money -= UnlockCoffePrice;

        UnlockedCoffeText.text = "unlocked";
    }

    public void UnlockOrange()
    {
        //unlocks the orange juice drink
        dropdownValue.dropdown.options.Add(new TMPro.TMP_Dropdown.OptionData("Orange juice", null, Color.black));
        UnlockedOrange = true;
        dropdownValue.dropdown.RefreshShownValue();
        OrangeRemoveObject.SetActive(true);
        OrangeDisplayObject.SetActive(true);
        

        gameManager.money -= UnlockOrangePrice;

        UnlockedOrangeText.text = "unlocked";
        MoneyTextObject.SetActive(false);

    }

    IEnumerator StartCoffeUnlock()
    {
        //automatically unlocks the coffe drink at the start
        yield return null; // wait one frame
        UnlockCoffe();
    }

}
