using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorNormal;
    [SerializeField] private Texture2D cursorReload;
    [SerializeField] private Texture2D cursorShoot;

    private Vector2 hotspot = new Vector2(16, 48);
    void Start()
    {
        Cursor.SetCursor(cursorNormal, hotspot, CursorMode.Auto);
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorShoot, hotspot, CursorMode.Auto);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorNormal, hotspot, CursorMode.Auto);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Cursor.SetCursor(cursorReload, hotspot, CursorMode.Auto);
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            Cursor.SetCursor(cursorNormal, hotspot, CursorMode.Auto);
        }
        
    }
}
