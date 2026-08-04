using UnityEngine;

public class RandomCustomerSkin : MonoBehaviour
{
    [Header("StartingSprite")]
    //int randomSprite2;
    //Sprite ChosenSprite2;
    
    [Header("Normal")]
    public Sprite [] customerSkin;
    public Sprite [] customerSkin2;
    int randomSprite;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRenderer2;
    Sprite ChosenSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //randomizes the customer skin when the customer is instantiated
        randomSprite = Random.Range(0, customerSkin.Length);
        ChosenSprite = customerSkin[randomSprite];

        randomSprite = Random.Range(0, customerSkin2.Length);
        ChosenSprite = customerSkin2[randomSprite];

        //randomSprite2 = Random.Range(0, customerSkin.Length);
        //ChosenSprite2 = customerSkin[randomSprite2];
    }



    public void ChangeSprite()
    {
        //randomizes the customer1 skin when the customer arrives to the starting point
        randomSprite = Random.Range(0, customerSkin.Length);
        ChosenSprite = customerSkin[randomSprite];
        spriteRenderer.sprite = ChosenSprite;
    }

    public void ChangeSprite2()
    {
        //randomizes the customer2 skin when the customer arrives to the starting point
        randomSprite = Random.Range(0, customerSkin2.Length);
        ChosenSprite = customerSkin2[randomSprite];
        spriteRenderer2.sprite = ChosenSprite;
    }


}
