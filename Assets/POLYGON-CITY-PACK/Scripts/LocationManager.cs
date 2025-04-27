using UnityEngine;
using TMPro;  // TextMeshPro for TMP_Dropdown

public class LocationManager : MonoBehaviour
{
    public TMP_Dropdown startPointDropdown;
    public TMP_Dropdown destinationPointDropdown;
    public GameObject[] locations; // List of location points   
    public GameObject player; // Reference to the player object
    public PathDrawer pathDrawer; // Reference to the PathDrawer script

    public GameObject StartPoint { get; private set; }
    public GameObject DestinationPoint { get; private set; }

    void Start()
    {
        Debug.Log("========= Location state Manager Called! =========");

        startPointDropdown.onValueChanged.AddListener(OnStartPointSelected);
        destinationPointDropdown.onValueChanged.AddListener(OnDestinationPointSelected);

        // Set player's current location as StartPoint temporarily
        if (player != null)
        {
            StartPoint = player;
            Debug.Log("Start Point set to Player's current location: " + player.name);
        }
        
        if (locations.Length > 0)
        {
            DestinationPoint = locations[0];
            UpdatePathDrawerDestination();
        }
    }

    void OnStartPointSelected(int index)
    {
        if (index >= 0 && index < locations.Length)
        {
            StartPoint = locations[index];
            Debug.Log("Start Point Selected: " + StartPoint.name);
        }
    }

    void OnDestinationPointSelected(int index)
    {
        if (index >= 0 && index < locations.Length)
        {
            DestinationPoint = locations[index];
            Debug.Log("Destination Point Selected: " + DestinationPoint.name);
            UpdatePathDrawerDestination();  // Update the destination in PathDrawer
        }
    }

    // Notify PathDrawer when the destination changes
    void UpdatePathDrawerDestination()
    {
        if (pathDrawer != null && DestinationPoint != null)
        {
            pathDrawer.SetDestination(DestinationPoint.transform);  // Pass the new destination
        }
    }
}
