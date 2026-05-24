// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// public class LocationSelectionManager : MonoBehaviour
// {
//     public TMP_Dropdown startDropdown;
//     public TMP_Dropdown destinationDropdown;
//     public Button submitButton;
//     public GameObject directionSelectionCanvas;
//     public CollectableSpawner collectableSpawner; // Assign in Inspector

//     void Start()
//     {
//         submitButton.onClick.AddListener(OnSubmit);
//     }

//     void OnSubmit()
//     {
//         if (startDropdown.options.Count == 0 || destinationDropdown.options.Count == 0)
//             return;

//         string startLocation = startDropdown.options[startDropdown.value].text;
//         string destinationLocation = destinationDropdown.options[destinationDropdown.value].text;

//         // Save to global state (optional)
//         LocationManager.SetLocations(startLocation, destinationLocation);
//         Debug.Log("Start: " + startLocation + " | Destination: " + destinationLocation);

//         // 👉 Assign collectable based on destination
//         collectableSpawner.AssignCollectableByName(destinationLocation);

//         // Disable canvas
//         directionSelectionCanvas.SetActive(false);
//     }
// }

// // using UnityEngine;
// // using UnityEngine.UI;
// // using TMPro;

// // public class LocationSelectionManager : MonoBehaviour
// // {
// //     public TMP_Dropdown startDropdown;
// //     public TMP_Dropdown destinationDropdown;
// //     public Button submitButton;
// //     public GameObject directionSelectionCanvas; // <-- Assign this in Inspector

// //     void Start()
// //     {
// //         submitButton.onClick.AddListener(OnSubmit);
// //     }

// //     void OnSubmit()
// //     {
// //         // Safety checks
// //         if (startDropdown.options.Count == 0 || destinationDropdown.options.Count == 0)
// //         {
// //             Debug.LogWarning("One or both dropdowns have no options.");
// //             return;
// //         }

// //         if (startDropdown.value < 0 || startDropdown.value >= startDropdown.options.Count ||
// //             destinationDropdown.value < 0 || destinationDropdown.value >= destinationDropdown.options.Count)
// //         {
// //             Debug.LogWarning("Selected dropdown index is out of range.");
// //             return;
// //         }

// //         string startLocation = startDropdown.options[startDropdown.value].text;
// //         string destinationLocation = destinationDropdown.options[destinationDropdown.value].text;

// //         LocationManager.SetLocations(startLocation, destinationLocation);
// //         Debug.Log("Start: " + startLocation + " | Destination: " + destinationLocation);

// //         // 🔻 Fully deactivate the entire canvas
// //         directionSelectionCanvas.SetActive(false);
// //     }
// // }


// // using UnityEngine;
// // using UnityEngine.UI;
// // using TMPro;

// // public class LocationSelectionManager : MonoBehaviour
// // {
// //     public TMP_Dropdown startDropdown;
// //     public TMP_Dropdown destinationDropdown;
// //     public Button submitButton;

// //     void Start()
// //     {
// //         // Add listener to button

// //         submitButton.onClick.AddListener(OnSubmit);
// //     }

// //     // void OnSubmit()
// //     // {
// //     //     string startLocation = startDropdown.options[startDropdown.value].text;
// //     //     string destinationLocation = destinationDropdown.options[destinationDropdown.value].text;

// //     //     // Save to global state
// //     //     LocationManager.SetLocations(startLocation, destinationLocation);

// //     //     Debug.Log("Start: " + startLocation + " | Destination: " + destinationLocation);
// //     // }

// //     // void OnSubmit()
// //     // {
// //     //     // Safety checks
// //     //     if (startDropdown.options.Count == 0 || destinationDropdown.options.Count == 0)
// //     //     {
// //     //         Debug.LogWarning("One or both dropdowns have no options.");
// //     //         return;
// //     //     }

// //     //     if (startDropdown.value < 0 || startDropdown.value >= startDropdown.options.Count ||
// //     //         destinationDropdown.value < 0 || destinationDropdown.value >= destinationDropdown.options.Count)
// //     //     {
// //     //         Debug.LogWarning("Selected dropdown index is out of range.");
// //     //         return;
// //     //     }

// //     //     string startLocation = startDropdown.options[startDropdown.value].text;
// //     //     string destinationLocation = destinationDropdown.options[destinationDropdown.value].text;

// //     //     LocationManager.SetLocations(startLocation, destinationLocation);
// //     //     Debug.Log("Start: " + startLocation + " | Destination: " + destinationLocation);
// //     // }


// //     // void OnSubmit()
// //     // {
// //     //     // Safety checks
// //     //     if (startDropdown.options.Count == 0 || destinationDropdown.options.Count == 0)
// //     //     {
// //     //         Debug.LogWarning("One or both dropdowns have no options.");
// //     //         return;
// //     //     }

// //     //     if (startDropdown.value < 0 || startDropdown.value >= startDropdown.options.Count ||
// //     //         destinationDropdown.value < 0 || destinationDropdown.value >= destinationDropdown.options.Count)
// //     //     {
// //     //         Debug.LogWarning("Selected dropdown index is out of range.");
// //     //         return;
// //     //     }

// //     //     string startLocation = startDropdown.options[startDropdown.value].text;
// //     //     string destinationLocation = destinationDropdown.options[destinationDropdown.value].text;

// //     //     // Save to global state
// //     //     LocationManager.SetLocations(startLocation, destinationLocation);

// //     //     Debug.Log("Start: " + startLocation + " | Destination: " + destinationLocation);

// //     //     // Disable dropdowns
// //     //     startDropdown.interactable = false;
// //     //     destinationDropdown.interactable = false;

// //     //     // Optionally disable the submit button too
// //     //     submitButton.interactable = false;
// //     // }
// //     void OnSubmit()
// //     {
// //         // Safety checks
// //         if (startDropdown.options.Count == 0 || destinationDropdown.options.Count == 0)
// //         {
// //             Debug.LogWarning("One or both dropdowns have no options.");
// //             return;
// //         }

// //         if (startDropdown.value < 0 || startDropdown.value >= startDropdown.options.Count ||
// //             destinationDropdown.value < 0 || destinationDropdown.value >= destinationDropdown.options.Count)
// //         {
// //             Debug.LogWarning("Selected dropdown index is out of range.");
// //             return;
// //         }

// //         string startLocation = startDropdown.options[startDropdown.value].text;
// //         string destinationLocation = destinationDropdown.options[destinationDropdown.value].text;

// //         LocationManager.SetLocations(startLocation, destinationLocation);
// //         Debug.Log("Start: " + startLocation + " | Destination: " + destinationLocation);

// //         // Deactivate the dropdowns
// //         startDropdown.gameObject.SetActive(false);
// //         destinationDropdown.gameObject.SetActive(false);

// //         // Optionally hide the submit button too
// //         submitButton.gameObject.SetActive(false);
// //     }


// // }
