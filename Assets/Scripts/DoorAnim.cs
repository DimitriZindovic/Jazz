using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    private bool isOpen = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            animator.Play("OpenDoor");; // Déclenche l'animation
        }
    }
}
