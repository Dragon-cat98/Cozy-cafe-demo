using NUnit.Framework.Internal;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SummaryScript : MonoBehaviour
{
    [Header("End Shift Summary Data")]
    public static SummaryScript instance;
    public int Revenue;
    public int Expenses;
    public int profit;
    public int drinks_made;
    public int drinks_trashed;
    public int Day;
    //int overdraft supplies fee(to add after shop is made)
    public int drinks_served;

    [Header("New Shift Summary Data")]
    private int default_Revenue = 0;
    private int default_Expenses = 0;
    private int default_profit = 0;
    private int default_drinks_made = 0;
    private int default_drinks_trashed = 0;
    //int default_overdraft supplies fee(to add after shop is made)  = 0;
    private int default_drinks_served = 0;

    [Header("End Shift Summary Text")]
    public TextMeshProUGUI RevenueText;
    public TextMeshProUGUI ExpensestText;
    public TextMeshProUGUI ProfitText;
    public TextMeshProUGUI drinks_madeText;
    public TextMeshProUGUI drinks_trashedText;
    public TextMeshProUGUI drinks_servedText;
    public TextMeshProUGUI DayText;

    [Header("random things")]
    public GameObject summaryScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        summaryScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //puts all the gathered data of the day in the text boxes of all the values
        //the spaces are for making sure they are kinda all aligned(I know it's inefficient)

        profit = Revenue - Expenses;

        RevenueText.text = "revenue                              " + Revenue;
        ExpensestText.text = "Expenses                            " + Expenses;
        ProfitText.text = "profit                                 " + profit;
        drinks_madeText.text = "drinks made                       " + drinks_made;
        drinks_trashedText.text = "drinks trashed                  " + drinks_trashed;
        drinks_servedText.text = "drinks served                    " + drinks_served;
        DayText.text = "day " + Day;
    }

    public void Reset()
    {
        //function that resets all the stored summary values of that day

        Revenue = default_Revenue;
        Expenses = default_Expenses;
        profit = default_profit;
        drinks_made = default_drinks_made;
        drinks_trashed = default_drinks_trashed;
        //int overdraft supplies fee(to add after shop is made)  =  default_overdraft supplies fee;
        drinks_served = default_drinks_served;

        //resets the clock objects and values
        ClockScript.instance.ClockrectTransform.localEulerAngles = Vector3.zero;
        ClockScript.instance.currenthour = 12;
        ClockScript.instance.hourOfDay.text = ClockScript.instance.currenthour + ":00";
    }

    
}
