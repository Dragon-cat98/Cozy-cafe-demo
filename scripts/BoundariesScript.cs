using UnityEngine;
using UnityEngine.UI;
public class BoundariesScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //get the rect transform component from the object that's triggering
        RectTransform rt = other.GetComponent<RectTransform>();

        //If the object triggering has any of the tags 
        if(other.CompareTag("Empty") || other.CompareTag("CoffeFull") || other.CompareTag("EmptyOrange") || other.CompareTag("OrangeFull") || other.CompareTag("Mug") || other.CompareTag("Jug"))
        {
            //send him back to it's spawn position
            rt.anchoredPosition = new Vector2(0f, 0f);
        }
    }
}
