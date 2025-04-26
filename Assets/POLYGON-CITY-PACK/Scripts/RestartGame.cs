using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Call this method to restart the current scene
    public void Restart()
    {
        // Reloads the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Debug.Log("✅️ Game Restarted Successfully!!! ✅️");
    }
}
