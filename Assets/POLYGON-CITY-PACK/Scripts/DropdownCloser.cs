using UnityEngine;
using TMPro; // If you also need TMP_Dropdown reference

public class DropdownCloser : MonoBehaviour
{
    public GameObject dropdownPanel; // Assign the Dropdown's GameObject (or its parent panel)

    public void OnConfirmButtonClicked()
    {
        if (dropdownPanel != null)
        {
            dropdownPanel.SetActive(false);
            Debug.Log("Dropdown panel deactivated on Confirm.");
        }
    }
}
