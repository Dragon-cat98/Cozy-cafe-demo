using UnityEngine;
using TMPro;
using System.Collections;
using Unity.Mathematics;

using UnityEngine.UI;
public class ClockScript : MonoBehaviour
{
    public static ClockScript instance;
    public TextMeshProUGUI hourOfDay;
    public TextMeshProUGUI DayCounter;
    public float rotationZ;
    public int hourIncrease = 1;
    public int currenthour = 12;
    public int day = 1;
    public RectTransform ClockrectTransform;

    bool isCroutineActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        if(instance == null)
        {
            instance = this;
        }

        //set the initial values for the clock and day counter 
        hourOfDay.text = currenthour + ":00";
        DayCounter.text = "day " + day;
        SummaryScript.instance.Day = day;
        //starts the coroutine for the day logic
        StartCoroutine(HourOfDayLogic(30f));
    }

    // Update is called once per frame
    void Update()
    {
        SummaryScript.instance.Day = day;
        DayCounter.text = "day " + day;

        //checks if the coroutine has ended
        if(isCroutineActive == false)
        {
            //if it has ended starts a new one
            Debug.Log("routine ended");
            StartCoroutine(HourOfDayLogic(30f));
        }

           
    }

    IEnumerator HourOfDayLogic(float TimeBetweenHours)
    {
        //logs the current day in the end shift summary
        SummaryScript.instance.Day = day;
        isCroutineActive = true;

        //waits the time before rotating the clock for 1 hour
        yield return new WaitForSeconds(TimeBetweenHours);
        ClockrectTransform.localEulerAngles += new Vector3(0, 0, rotationZ);

        //increases the hour on the clock
        currenthour += hourIncrease;   
        
        //updates the clock text
        hourOfDay.text = currenthour + ":00";

        //ends the coroutine
        isCroutineActive = false;

        if(currenthour == 20)
        {
            //if the hour is 20 the shift ends
            ShiftManager.instance.EndShift();
        }
    }
}
