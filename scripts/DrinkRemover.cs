using JetBrains.Annotations;
using UnityEngine;

public class DrinkRemover : MonoBehaviour
{
   [SerializeField] private Kitchen_prepare kitchenPrepare;
   [SerializeField] private ShelfChecker shelfChecker;
   [SerializeField] private GameManager gameManager;
   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
        
   }

   // Update is called once per frame
   void Update()
   {
        
   }

   public void RemoveOrange()
   {
      //used to remove an orange juice drink if there are too many and
      //the player is in need of other drinks
      kitchenPrepare.Coffes_made--;
      kitchenPrepare.UpdatePrepButton();
      shelfChecker.OrangeOnShelf--;
      
      gameManager.PosChecker();
   }

   public void RemoveCoffe()
   {
      //used to remove a coffe drink if there are too many and
      //the player is in need of other drinks
      kitchenPrepare.Coffes_made--;
      kitchenPrepare.UpdatePrepButton();
      shelfChecker.CoffeOnShelf--;

      //used to check what positions are available and sets them available
      gameManager.PosChecker();
   }
}
