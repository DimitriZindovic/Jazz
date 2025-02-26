using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public AudioObject[] conversation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.StartConversation(conversation);
        }
    }
}
