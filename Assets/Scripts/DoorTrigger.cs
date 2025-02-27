using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoorScript
{
    public class DoorTrigger : MonoBehaviour
    {
        public Door door; // Référence au script Door (que l'on va assigner dans l'inspecteur)
        private bool HasTriggered;
        public bool isOpenTrigger;
        // Cette fonction est appelée lorsque quelque chose entre dans le trigger
        private void OnTriggerEnter(Collider other)
        {
            // Si c'est le joueur (avec un tag "Player")
            if (other.CompareTag("Player") && !HasTriggered)
            {
                // Appeler la fonction OpenDoor du script Door
                if (door != null)
                {
                    HasTriggered = true;
                    door.OpenDoor(isOpenTrigger);
                }
            }
        }
    }
}
