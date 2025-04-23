using Unity.VisualScripting;
using UnityEngine;

public class LimitCamera : MonoBehaviour
{
    public GameObject Player;

    private void LateUpdate() {
        transform.position = new Vector3(Player.transform.position.x, 15f,Player.transform.position.z);    
    }
}
