using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public AudioObject[] conversation; // Assigné dans l’Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(AudioManager.instance.PlayConversation(conversation));
        }
    }
}
