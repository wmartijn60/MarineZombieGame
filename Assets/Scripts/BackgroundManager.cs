using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Animator backgroundAnimator;


    private void Start()
    {
        OpenDoor();
    }

    public void CloseDoor()
    {
        backgroundAnimator.SetTrigger("CloseDoor");
    }

    public void OpenDoor()
    {
        backgroundAnimator.SetTrigger("OpenDoor");
    }
}
