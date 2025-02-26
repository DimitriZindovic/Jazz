using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public AudioObject[] conversation;
    private bool HasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !HasPlayed)
        {
            AudioManager.instance.StartConversation(conversation);
            HasPlayed = true;
        }
    }
}
