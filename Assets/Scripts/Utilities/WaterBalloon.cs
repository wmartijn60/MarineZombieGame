using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBalloon : MonoBehaviour
{
    [SerializeField]private float balloonCooldown = 1f;

    [SerializeField]private ItemManager itemManager;

    [SerializeField]private Animator balloonLeft;
    [SerializeField]private Animator balloonMid;
    [SerializeField]private Animator balloonRight;

    private float balloonLeftCD;
    private float balloonMidCD;
    private float balloonRightCD;

    void Start()
    {
        balloonLeftCD = balloonCooldown;
        balloonMidCD = balloonCooldown;
        balloonRightCD = balloonCooldown;
    }
    
    void Update()
    {
        ThrowBalloonLeft();
        ThrowBalloonMid();
        ThrowBalloonRight();
    }

    public void ThrowBalloonLeft()
    {
        if (Input.GetKeyDown(KeyCode.Q) && itemManager.UseBalloon() && balloonLeftCD <= 0)
        {
            balloonLeft.gameObject.SetActive(true);
            balloonLeft.SetTrigger("ThrowLeft");
            itemManager.balloonAmount--;
            itemManager.UpdateBalloonCount();
            balloonLeftCD = balloonCooldown;
        }
        else
        {
            balloonLeftCD -= Time.deltaTime;
        }
    }

    public void ThrowBalloonMid()
    {
        if (Input.GetKeyDown(KeyCode.W) && itemManager.UseBalloon() && balloonMidCD <= 0)
        {
            balloonMid.gameObject.SetActive(true);
            balloonMid.SetTrigger("ThrowMid");
            itemManager.balloonAmount--;
            itemManager.UpdateBalloonCount();
            balloonMidCD = balloonCooldown;
        }
        else
        {
            balloonMidCD -= Time.deltaTime;
        }
    }

    public void ThrowBalloonRight()
    {
        if (Input.GetKeyDown(KeyCode.E) && itemManager.UseBalloon() && balloonRightCD <= 0)
        {
            balloonRight.gameObject.SetActive(true);
            balloonRight.SetTrigger("ThrowRight");
            itemManager.balloonAmount--;
            itemManager.UpdateBalloonCount();
            balloonRightCD = balloonCooldown;
        }
        else
        {
            balloonRightCD -= Time.deltaTime;
        }
    }

}
