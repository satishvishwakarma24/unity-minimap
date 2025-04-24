using UnityEngine;

public class DropdownToggleBtn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject menuCanvas;
    private bool isMenuOpen = false;

    public void ToggleMenu()
    {

        if (menuCanvas != null)
        {
            isMenuOpen = !isMenuOpen;
            menuCanvas.SetActive(isMenuOpen);
        }
    }
}
