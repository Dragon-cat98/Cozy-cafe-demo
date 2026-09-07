using UnityEngine;

using UnityEngine.UI;
using System.Collections;
public class ShopButton : MonoBehaviour
{
    public Image darkOverlay;
    public float fadeDuration = 5f;
    public GameObject ShopBG;
    public GameObject summaryBG;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShopBG.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator InvertedDarkenScreen(float Darkendelay)
    {
        //inverted darken screen(see shift manager script)
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

    private IEnumerator DarkenScreen(float Darkendelay)
    {
        //darken screen(see shift manager script)
        yield return new WaitForSeconds(Darkendelay);
        float elapsed = 0f;
        Color c = darkOverlay.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsed / fadeDuration);
            darkOverlay.color = c;
            yield return null;
        }
        c.a = 1f;
        darkOverlay.color = c;
    }
    void OpenShop()
    {
        //opens the shop
        summaryBG.SetActive(false);
        ShopBG.SetActive(true);
    }

    IEnumerator OpenShopSequence(float WaitTime)
    {
        //coroutine that opens the shop
        yield return new WaitForSeconds(WaitTime);
        OpenShop();
    }
    public void GoToShop()
    {
        //function that opens the shop
        Debug.Log("itstarts");
        StartCoroutine(DarkenScreen(1f));
        Debug.LogError("wtfhappened");
        StartCoroutine(OpenShopSequence(2f));
        StartCoroutine(InvertedDarkenScreen(4f));
    }
}
