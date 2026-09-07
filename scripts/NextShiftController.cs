using UnityEngine;
using System.Collections;
public class NextShiftController : MonoBehaviour
{
    public Kitchen_prepare kitchen_Prepare;
    public ShelfChecker shelfChecker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextShift()
    {
        //function that's called for starting the new shift
        ShiftManager.instance.StartNewShiftSequence();
        //SummaryScript.instance.Reset();
        StartCoroutine(ResetShelf());
        ShiftManager.instance.resetCustomers();
    }

    IEnumerator ResetShelf()
    {
        //coroutine that resets the shelfs 
        yield return new WaitForEndOfFrame();

        kitchen_Prepare.Coffes_made = 0;
        shelfChecker.CoffeOnShelf = 0;
        shelfChecker.OrangeOnShelf = 0;
    }
}
