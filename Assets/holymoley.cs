using UnityEngine;
using UnityEngine.UI;

public class Holymoley : MonoBehaviour
{
    public GameObject gople;
    public GameObject jellyfish;
    public GameObject buttonPrefab;

    void OnMouseDown()
    {
        Debug.Log("Mouse Down on: " + gameObject.name);

        if (gameObject == gople || gameObject == jellyfish)
        {
            ShowDirectionButtons();
            Debug.Log("saut");
        }
    }

    void ShowDirectionButtons()
    {
        // Example: Instantiate UI buttons dynamically at the transform of the current game object
        SpawnDirectionButton(Vector2.right, transform.position);
        SpawnDirectionButton(Vector2.up, transform.position);
        SpawnDirectionButton(Vector2.left, transform.position);
        SpawnDirectionButton(Vector2.down, transform.position);
    }

    void SpawnDirectionButton(Vector2 direction, Vector2 position)
    {
        // Example: Instantiate UI button prefab at the specific position
        GameObject buttonGO = Instantiate(buttonPrefab, position, Quaternion.identity);
        Button button = buttonGO.GetComponent<Button>();
        // Add a listener to the button to handle the direction
        button.onClick.AddListener(() => MoveObject(gameObject, direction));
    }

    void MoveObject(GameObject obj, Vector2 direction)
    {
        obj.transform.position = new Vector2(obj.transform.position.x + direction.x, obj.transform.position.y + direction.y);
    }
}
