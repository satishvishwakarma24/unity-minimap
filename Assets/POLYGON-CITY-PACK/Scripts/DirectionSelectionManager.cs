using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DirectionSelectionManager : MonoBehaviour
{
    [SerializeField] private DirectionPolylineManager polylineManager;
    [SerializeField] private TMP_Dropdown startLocationDropdown;
    [SerializeField] private TMP_Dropdown destinationDropdown;
    [SerializeField] private Button submitButton;
    
    [SerializeField] private GameObject directionsMenuCanvas;
    
    // List of available locations (you would populate this with your actual locations)
    [SerializeField] private List<Transform> availableLocations = new List<Transform>();
    
    private void Start()
    {
        // Initialize references if not set in inspector
        if (polylineManager == null)
            polylineManager = FindObjectOfType<DirectionPolylineManager>();
            
        if (directionsMenuCanvas == null)
            directionsMenuCanvas = transform.Find("DirectionsMenuCanvas").gameObject;
            
        // Set up dropdowns
        PopulateLocationDropdowns();
        
        // Set up button
        if (submitButton != null)
            submitButton.onClick.AddListener(OnSubmitDirections);
    }
    
    private void PopulateLocationDropdowns()
    {
        if (startLocationDropdown == null || destinationDropdown == null)
        {
            Debug.LogError("Dropdowns not assigned!");
            return;
        }
        
        // Clear existing options
        startLocationDropdown.ClearOptions();
        destinationDropdown.ClearOptions();
        
        // Create new options
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        
        foreach (Transform location in availableLocations)
        {
            options.Add(new TMP_Dropdown.OptionData(location.name));
        }
        
        // Add options to dropdowns
        startLocationDropdown.AddOptions(options);
        destinationDropdown.AddOptions(options);
    }
    
    public void OnSubmitDirections()
    {
        if (availableLocations.Count == 0)
        {
            Debug.LogWarning("No locations available");
            return;
        }
        
        int startIndex = startLocationDropdown.value;
        int destIndex = destinationDropdown.value;
        
        // Get selected transforms
        Transform start = availableLocations[startIndex];
        Transform destination = availableLocations[destIndex];
        
        // Tell the polyline manager to draw the path
        polylineManager.SetDirectionPoints(start, destination);
    }
    
    // To be called from your existing toggle button
    public void ToggleDirectionsMenu()
    {
        if (directionsMenuCanvas != null)
            directionsMenuCanvas.SetActive(!directionsMenuCanvas.activeSelf);
    }
    
    // Method to add locations to the available list - call this to setup your locations
    public void AddLocation(Transform locationTransform)
    {
        if (!availableLocations.Contains(locationTransform))
        {
            availableLocations.Add(locationTransform);
            // Refresh dropdowns if already initialized
            if (startLocationDropdown != null)
                PopulateLocationDropdowns();
        }
    }
}