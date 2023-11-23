using UnityEngine;
using UnityEngine.UI;

public class FunctionalityFunctions3 : MonoBehaviour
{
    public Button myButton;
    private Animator animations;
    private Vector2 moveDistance = new Vector2(-760f, -524f);

    void Start()
    {
        animations = GetComponent<Animator>();
        myButton.onClick.AddListener(ButtonClick);
    }

    // Method to be called when the button is clicked
    void ButtonClick()
    {
        Debug.Log("Button Clicked!");

        // Move the object when the button is clicked
        transform.Translate(moveDistance, Space.World);

        // Trigger animation if available
       /* if (animations != null)
        {
            animations.SetTrigger("stenos");
        } */
    }
}
