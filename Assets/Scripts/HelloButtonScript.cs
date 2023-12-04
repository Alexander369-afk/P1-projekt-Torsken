using UnityEngine;
using UnityEngine.UI;

public class HelloButtonScript : MonoBehaviour
{
    void Start()
    {
        // Attach the button click listener
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PrintHello);
        }
        else
        {
            Debug.LogError("Button component not found on the GameObject.");
        }
    }

    // Method to be called when the button is clicked
    void PrintHello()
    {
        Debug.Log("Hello");
    }
}
