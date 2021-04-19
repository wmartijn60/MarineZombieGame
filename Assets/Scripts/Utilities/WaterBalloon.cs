using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBalloon : MonoBehaviour
{
    [SerializeField]private ItemManager itemManager;

    [SerializeField]private Animator balloonLeft;
    [SerializeField]private Animator balloonMid;
    [SerializeField]private Animator balloonRight;

    void Start()
    {
        
    }
    
    void Update()
    {
        ThrowBalloonLeft();
        ThrowBalloonMid();
        ThrowBalloonRight();
    }

    public void ThrowBalloonLeft()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            balloonLeft.gameObject.SetActive(true);
            balloonLeft.SetTrigger("ThrowLeft");
        }
    }

    public void ThrowBalloonMid()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            balloonMid.gameObject.SetActive(true);
            balloonMid.SetTrigger("ThrowMid");
        }
    }

    public void ThrowBalloonRight()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            balloonRight.gameObject.SetActive(true);
            balloonRight.SetTrigger("ThrowRight");
        }
    }

    public void ImpactLeft()
    {

    }

    public void ImpactMid()
    {

    }

    public void ImpactRight()
    {
        
    }
}
