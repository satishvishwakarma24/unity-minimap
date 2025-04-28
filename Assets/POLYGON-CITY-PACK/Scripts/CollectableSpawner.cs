using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]
    private Collectable Prefab;
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private LineRenderer Path;
    [SerializeField]
    private float PathHeightOffset = 1.25f;
    [SerializeField]
    private float SpawnHeightOffset = 1.5f;
    [SerializeField]
    private float PathUpdateSpeed = 0.25f;

    private Collectable ActiveInstance;
    private NavMeshTriangulation Triangulation;
    private Coroutine DrawPathCoroutine;

    [SerializeField]
    private Collectable RuntimeAssignedCollectable;

    private void Awake()
    {
        Triangulation = NavMesh.CalculateTriangulation();
    }
    // Array of tags you want to search for
    string[] tags = { "Hotel", "Gym", "School" };
    void Start()
    {
        // Initialize runtime assigned collectable
        // RuntimeAssignedCollectable = GameObject.FindGameObjectsWithTag(tags).GetComponent<Collectable>();
        foreach (string tag in tags)
        {
            GameObject[] collectables = GameObject.FindGameObjectsWithTag(tag);

            // Loop through each GameObject found for the current tag
            foreach (GameObject collectable in collectables)
            {
                Collectable collectableScript = collectable.GetComponent<Collectable>();
                if (collectableScript != null)
                {
                    // Perform actions on the collectable object
                    Debug.Log("Found collectable with tag: " + tag);
                }
            }
        }

        if (RuntimeAssignedCollectable == null)
        {
            Debug.LogError("RuntimeAssignedCollectable not found.");
        }

        // Spawn a new object
        SpawnNewObject();
    }

    public void SpawnNewObject()
    {
        ActiveInstance = RuntimeAssignedCollectable;
        ActiveInstance.Spawner = this;

        // Move to a random NavMesh point
        ActiveInstance.transform.position = Triangulation.vertices[Random.Range(0, Triangulation.vertices.Length)] + Vector3.up * SpawnHeightOffset;

        // Stop the existing path-drawing coroutine (if any)
        if (DrawPathCoroutine != null)
        {
            StopCoroutine(DrawPathCoroutine);
        }

        // Force immediate path update
        UpdatePathImmediately();

        // Start the path-drawing coroutine for continuous updates
        DrawPathCoroutine = StartCoroutine(DrawPathToCollectable());
    }

    private void UpdatePathImmediately()
    {
        NavMeshPath path = new NavMeshPath();

        // Calculate path to the collectable
        if (NavMesh.CalculatePath(Player.position, ActiveInstance.transform.position, NavMesh.AllAreas, path))
        {
            // Update the LineRenderer immediately
            Path.positionCount = path.corners.Length;

            for (int i = 0; i < path.corners.Length; i++)
            {
                Path.SetPosition(i, path.corners[i] + Vector3.up * PathHeightOffset);
            }
        }
        else
        {
            Debug.LogError($"Unable to calculate a path on the NavMesh between {Player.position} and {ActiveInstance.transform.position}!");
        }
    }

    private IEnumerator DrawPathToCollectable()
    {
        WaitForSeconds Wait = new WaitForSeconds(PathUpdateSpeed);
        NavMeshPath path = new NavMeshPath();

        while (ActiveInstance != null)
        {
            // Recalculate path every frame (or at regular intervals)
            if (NavMesh.CalculatePath(Player.position, ActiveInstance.transform.position, NavMesh.AllAreas, path))
            {
                // Update LineRenderer positions
                Path.positionCount = path.corners.Length;

                for (int i = 0; i < path.corners.Length; i++)
                {
                    Path.SetPosition(i, path.corners[i] + Vector3.up * PathHeightOffset);
                }
            }
            else
            {
                Debug.LogError($"Unable to calculate a path on the NavMesh between {Player.position} and {ActiveInstance.transform.position}!");
            }

            // Wait before updating the path again
            yield return Wait;
        }
    }

    public void AssignCollectableByName(string collectableName)
    {
        GameObject found = GameObject.Find(collectableName);
        if (found != null && found.TryGetComponent(out Collectable col))
        {
            RuntimeAssignedCollectable = col;
            Debug.Log($"Assigned Collectable: {collectableName}");
        }
        else
        {
            Debug.LogError($"Collectable with name '{collectableName}' not found in scene.");
        }
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class CollectableSpawner : MonoBehaviour
// {
//     [SerializeField]
//     private Collectable Prefab;
//     [SerializeField]
//     private Transform Player;
//     [SerializeField]
//     private LineRenderer Path;
//     [SerializeField]
//     private float PathHeightOffset = 1.25f;
//     [SerializeField]
//     private float SpawnHeightOffset = 1.5f;
//     [SerializeField]
//     private float PathUpdateSpeed = 0.25f;

//     private Collectable ActiveInstance;
//     private NavMeshTriangulation Triangulation;
//     private Coroutine DrawPathCoroutine;

//     [SerializeField]
//     private Collectable RuntimeAssignedCollectable;
//     private void Awake()
//     {
//         Triangulation = NavMesh.CalculateTriangulation();
//     }
//     void Start()
//     {
//         // RuntimeAssignedCollectable = GameObject.Find("MyCollectable").GetComponent<Collectable>();
//     RuntimeAssignedCollectable = GameObject.FindGameObjectWithTag("MyCollectable").GetComponent<Collectable>();

//         if (RuntimeAssignedCollectable == null)
//         {
//             Debug.LogError("RuntimeAssignedCollectable not found.");
//         }

//         SpawnNewObject();
//     }

//     // public void SpawnNewObject()
//     // {
//     //     ActiveInstance = RuntimeAssignedCollectable;
//     //     ActiveInstance.Spawner = this;

//     //     // Move to a random NavMesh point
//     //     ActiveInstance.transform.position = Triangulation.vertices[Random.Range(0, Triangulation.vertices.Length)] + Vector3.up * SpawnHeightOffset;

//     //     if (DrawPathCoroutine != null)
//     //     {
//     //         StopCoroutine(DrawPathCoroutine);
//     //     }

//     //     DrawPathCoroutine = StartCoroutine(DrawPathToCollectable());
//     // }

// public void SpawnNewObject()
// {
//     ActiveInstance = RuntimeAssignedCollectable;
//     ActiveInstance.Spawner = this;

//     // Move to a random NavMesh point
//     ActiveInstance.transform.position = Triangulation.vertices[Random.Range(0, Triangulation.vertices.Length)] + Vector3.up * SpawnHeightOffset;

//     if (DrawPathCoroutine != null)
//     {
//         StopCoroutine(DrawPathCoroutine);
//     }

//     // Force immediate path update when a new collectable is spawned
//     DrawPathToCollectable();  // Call directly to update path immediately
//     DrawPathCoroutine = StartCoroutine(DrawPathToCollectable()); // Continue coroutine to update path at intervals
// }


//     // private IEnumerator DrawPathToCollectable()
//     // {
//     //     WaitForSeconds Wait = new WaitForSeconds(PathUpdateSpeed);
//     //     NavMeshPath path = new NavMeshPath();

//     //     while (ActiveInstance != null)
//     //     {
//     //         if (NavMesh.CalculatePath(Player.position, ActiveInstance.transform.position, NavMesh.AllAreas, path))
//     //         {
//     //             Path.positionCount = path.corners.Length;

//     //             for (int i = 0; i < path.corners.Length; i++)
//     //             {
//     //                 Path.SetPosition(i, path.corners[i] + Vector3.up * PathHeightOffset);
//     //             }
//     //         }
//     //         else
//     //         {
//     //             Debug.LogError($"Unable to calculate a path on the NavMesh between {Player.position} and {ActiveInstance.transform.position}!");
//     //         }

//     //         yield return Wait;
//     //     }
//     // }

// private IEnumerator DrawPathToCollectable()
// {
//     WaitForSeconds Wait = new WaitForSeconds(PathUpdateSpeed);
//     NavMeshPath path = new NavMeshPath();
//     Vector3 lastPosition = ActiveInstance.transform.position;  // Track last position

//     while (ActiveInstance != null)
//     {
//         // Only recalculate path if the destination has changed
//         if (ActiveInstance.transform.position != lastPosition)
//         {
//             if (NavMesh.CalculatePath(Player.position, ActiveInstance.transform.position, NavMesh.AllAreas, path))
//             {
//                 Path.positionCount = path.corners.Length;

//                 for (int i = 0; i < path.corners.Length; i++)
//                 {
//                     Path.SetPosition(i, path.corners[i] + Vector3.up * PathHeightOffset);
//                 }
//             }
//             else
//             {
//                 Debug.LogError($"Unable to calculate a path on the NavMesh between {Player.position} and {ActiveInstance.transform.position}!");
//             }

//             lastPosition = ActiveInstance.transform.position; // Update last position
//         }

//         yield return Wait;
//     }
// }

//     public void AssignCollectableByName(string collectableName)
// {
//     GameObject found = GameObject.Find(collectableName);
//     if (found != null && found.TryGetComponent(out Collectable col))
//     {
//         RuntimeAssignedCollectable = col;
//         Debug.Log($"Assigned Collectable: {collectableName}");
//     }
//     else
//     {
//         Debug.LogError($"Collectable with name '{collectableName}' not found in scene.");
//     }
// }

// }