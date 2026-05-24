using UnityEngine;
using TMPro;  // TextMeshPro for TMP_Dropdown

public class DropdownDebugger : MonoBehaviour
{
    public TMP_Dropdown myDropdown;  // Reference to the dropdown
    public GameObject[] gameObjectsToToggle;  // Array of GameObjects to toggle based on selection

    void Start()
    {
        // Add a listener to handle when the dropdown value changes
        myDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    void OnDropdownValueChanged(int index)
    {
        // Log the selected option
        Debug.Log("OnDropdownValueChanged Callled!!!! ");
        Debug.Log("Selected Option: " + myDropdown.options[index].text);

        // Deactivate all game objects first
        foreach (GameObject obj in gameObjectsToToggle)
        {
            obj.SetActive(false);
        }

        // Activate the selected GameObject based on index
        if (index >= 0 && index < gameObjectsToToggle.Length)
        {
            gameObjectsToToggle[index].SetActive(true);  // Activate the GameObject corresponding to the dropdown option
        }
    }
}
