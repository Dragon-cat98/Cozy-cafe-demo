using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D DefaultCursorTexture;
    [SerializeField] private Vector2 clickPosition = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gives the cursor texture to the chosen one
        Cursor.SetCursor(DefaultCursorTexture, clickPosition, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
