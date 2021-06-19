using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveGranade : MonoBehaviour
{
    //small impact
    //teleport all survivors to the boat
    //(maybe already in an not outside so you have no bugs?)
    //cooldown should be long
    //needs to cost a bit of money, 50 maybe?
    //make 3 locations `the granade can be thrown

    [SerializeField] private float teleporterCooldown = 5f;

    [SerializeField] private ItemManager itemManager;

    [SerializeField] private GameObject LeftTeleporter;
    [SerializeField] private GameObject midTeleporter;
    [SerializeField] private GameObject rightTeleporter;

    private TeleportPeople teleportPeople;
    private float teleporterLeftCD;
    private float teleporterMidCD;
    private float teleporterRightCD;

    void Start()
    {
        teleporterLeftCD = teleporterCooldown;
        teleporterMidCD = teleporterCooldown;
        teleporterRightCD = teleporterCooldown;
    }

    void Update()
    {
        ActivateTeleporterLeft();
        ActivateTeleporterMid();
        ActivateTeleporterRight();
    }

    public void ActivateTeleporterLeft()
    {
        teleportPeople = LeftTeleporter.GetComponent<TeleportPeople>();
        if (Input.GetKeyDown(KeyCode.A) && itemManager.UseTeleporter() && teleporterLeftCD <= 0)
        {
            LeftTeleporter.gameObject.SetActive(true);
            teleportPeople.TeleportHumans();
            itemManager.teleporterAmount--;
            itemManager.UpdateteleporterCount();
            teleporterLeftCD = teleporterCooldown;
        }
        else
        {
            teleporterLeftCD -= Time.deltaTime;
        }
    }

    public void ActivateTeleporterMid()
    {
        teleportPeople = midTeleporter.GetComponent<TeleportPeople>();
        if (Input.GetKeyDown(KeyCode.S) && itemManager.UseTeleporter() && teleporterMidCD <= 0)
        {
            midTeleporter.gameObject.SetActive(true);
            teleportPeople.TeleportHumans();
            itemManager.teleporterAmount--;
            itemManager.UpdateteleporterCount();
            teleporterMidCD = teleporterCooldown;
        }
        else
        {
            teleporterMidCD -= Time.deltaTime;
        }
    }

    public void ActivateTeleporterRight()
    {
        teleportPeople = rightTeleporter.GetComponent<TeleportPeople>();
        if (Input.GetKeyDown(KeyCode.D) && itemManager.UseTeleporter() && teleporterRightCD <= 0)
        {
            rightTeleporter.gameObject.SetActive(true);
            teleportPeople.TeleportHumans();
            itemManager.teleporterAmount--;
            itemManager.UpdateteleporterCount();
            teleporterRightCD = teleporterCooldown;
        }
        else
        {
            teleporterRightCD -= Time.deltaTime;
        }
    }

}