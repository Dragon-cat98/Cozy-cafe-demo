using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using JetBrains.Annotations;
using Unity.VisualScripting.Dependencies.NCalc;
using Unity.Collections.LowLevel.Unsafe;
using NUnit.Framework.Constraints;
public class ShiftManager : MonoBehaviour
{
    public static ShiftManager instance;
    public Image darkOverlay;
    public Image darkOverlay2;
    public float fadeDuration = 10f;
    public bool Darkened;
    public GameObject SummaryBG;
    public GameObject ShopBG;

    [Header("Customer Reset")]
    public GameObject customer1;
    public GameObject customer2;

    public Transform startTransfrom1;
    public Transform startTransfrom2;

    public Customer_logic customer_Logic;
    public Customer_logic2 customer_Logic2;
    public GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        Darkened = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndShift()
    {
        //function that ends the shift
        //scurisce gradualmente lo schermo
        StartCoroutine(DarkenScreen(3f));
        //appare uno sfondo un po' scurito
        StartCoroutine(BGappearance(10f));

        //disables the clock script so that it stops counting        
        ClockScript.instance.enabled = false;
    }

    public void resetCustomers()
    {
        //fucntion that resets the customers
        customer1.transform.position = startTransfrom1.position;
        customer2.transform.position = startTransfrom2.position;

        customer_Logic.time = customer_Logic.fixed_time;
        customer_Logic2.time = customer_Logic2.fixed_time;

        gameManager.Serve();
        gameManager.Serve2();
        gameManager.Serve_Orange();
        gameManager.Serve_Orange2();
    }

    private IEnumerator DarkenScreen(float Darkendelay)
    {
        //coroutine that darkens the screen

        //waits the time before starting to darken the screen
        yield return new WaitForSeconds(Darkendelay);

        //variable that keeps track of the elapsed time
        float elapsed = 0f;

        //gets the current color of the dark overlay
        Color c = darkOverlay.color;

        //while the elapsed time is less than the fade duration, it gradually increases the alpha of the dark overlay
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            //clamps the alpha value between 0 and 1 and sets it to the dark overlay color
            c.a = Mathf.Clamp01(elapsed / fadeDuration);

            //sets the dark overlay color to the new color with the updated alpha value
            darkOverlay.color = c;
            yield return null;
        }

        //sets the alpha value to 1 to ensure that the dark overlay is fully opaque
        c.a = 1f;
        darkOverlay.color = c;
    }


    private IEnumerator DarkenScreen2(float Darkendelay)
    {
        //same thing but for another screen
        yield return new WaitForSeconds(Darkendelay);
        float elapsed = 0f;
        Color c = darkOverlay2.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsed / fadeDuration);
            darkOverlay2.color = c;
            yield return null;
        }

        c.a = 1f;
        darkOverlay2.color = c;
    }

    public IEnumerator BGappearance(float AppearanceDelay)
    {
        //coroutine that makes the Background of the end shift appear(along w/ the summary)
        yield return new WaitForSeconds(AppearanceDelay);
        SummaryBG.SetActive(true);
    }

    public IEnumerator BGdisappearance(float AppearanceDelay)
    {
        //coroutine that makes the Background of the end shift disappear(along w/ the summary)
        yield return new WaitForSeconds(AppearanceDelay);
        SummaryBG.SetActive(false);
        ShopBG.SetActive(false);
        //updates the day and re-enables the clock script
        ClockScript.instance.day++;
        ClockScript.instance.enabled = true;
    }

    private IEnumerator InvertedDarkenScreen(float Darkendelay)
    {
        //dame as the darken screen but inverted
        yield return new WaitForSeconds(Darkendelay);

        float elapsed = 0f;
        Color c = darkOverlay.color;
        c.a = 1f; // start fully opaque (dark)
        darkOverlay.color = c;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Clamp01(1f - (elapsed / fadeDuration)); // 1 → 0
            darkOverlay.color = c;
            yield return null;
        }

        c.a = 0f; // end fully transparent (clear)
        darkOverlay.color = c;

    }
    private IEnumerator InvertedDarkenScreen2(float Darkendelay)
    {
        //same thing
        yield return new WaitForSeconds(Darkendelay);

        float elapsed = 0f;
        Color c = darkOverlay2.color;
        c.a = 1f; // start fully opaque (dark)
        darkOverlay2.color = c;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Clamp01(1f - (elapsed / fadeDuration)); // 1 → 0
            darkOverlay2.color = c;
            yield return null;
        }

        c.a = 0f; // end fully transparent (clear)
        darkOverlay2.color = c;

    }

    private IEnumerator StartNewShift()
    {
        //coroutine that starts the new shift
        yield return StartCoroutine(DarkenScreen2(0.5f));
        yield return StartCoroutine(BGdisappearance(1f));
        SummaryScript.instance.Reset();
        yield return StartCoroutine(InvertedDarkenScreen(0f));
        yield return StartCoroutine(InvertedDarkenScreen2(0f));
    }

    public void StartNewShiftSequence()
    {
        //function that un-stops time and calls the startnewshift coroutine
        Time.timeScale = 1f;
        StartCoroutine(StartNewShift());
    }
}
