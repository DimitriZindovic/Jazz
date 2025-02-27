using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door; // Référence vers la porte

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.OpenDoor();

        }
    }
}
