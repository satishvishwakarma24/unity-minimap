using UnityEngine;
using UnityEngine.UI;

public class DropdownChecker : MonoBehaviour
{
    public Dropdown myDropdown; // assign in Inspector

    void Start()
    {
        myDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    void OnDropdownValueChanged(int index)
    {
        string selectedOption = myDropdown.options[index].text;
        Debug.Log("Selected Option: " + selectedOption);
    }
}
