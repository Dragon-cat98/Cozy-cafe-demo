using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    [SerializeField] private TextMeshProUGUI UnlockedCoffeText;
    [SerializeField] private TextMeshProUGUI UnlockedOrangeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = Object.FindAnyObjectByType<GameManager>();
        dropdownValue = Object.FindAnyObjectByType<DropdownValue>();

        OrangeRemoveObject.SetActive(false);
        CoffeRemoveObject.SetActive(false);
        OrangeDisplayObject.SetActive(false);
        CoffeDisplayObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.money >= UnlockCoffePrice && UnlockedCoffe == false)
        {
            UnlockDrinks[0].interactable = true;
        }
        else
        {
            UnlockDrinks[0].interactable = false;
        }

        if(gameManager.money >= UnlockOrangePrice && UnlockedOrange == false)
        {
            UnlockDrinks[1].interactable = true;
        }
        else
        {
            UnlockDrinks[1].interactable = false;
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

    }


}
