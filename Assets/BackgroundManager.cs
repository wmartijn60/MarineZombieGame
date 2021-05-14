using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] Animator backgroundAnimator;


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
