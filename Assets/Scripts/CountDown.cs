using UnityEngine;

public class CountDown : MonoBehaviour
{
    private float timeLeft = 0;
    private bool countingDown = false;

    public delegate void StartingCountdown();
    public delegate void PausingCountdown();
    public delegate void ContineCountdown();
    public delegate void StoppingCountdown();

    public StartingCountdown startingCountDown;
    public PausingCountdown pausingCountdown;
    public ContineCountdown contineCountdown;
    public StoppingCountdown stoppingCountdown;

    private UIManager uiManager;

    private void Start() 
    {
        uiManager = GetComponent<UIManager>();
        StartCountDown(30);
    }

    private void FixedUpdate()
    {
        if (!countingDown) return;
        if (timeLeft > 0)
        {
            timeLeft -= Time.fixedDeltaTime;
            uiManager.UpdateCountDownText((int)timeLeft);
        }
        if (timeLeft <= 0)
        {
            StopCountDown();
        }
    }

    public void StartCountDown(float time)
    {
        timeLeft = time;
        countingDown = true;
        uiManager.UpdateCountDownText((int)timeLeft);
        DefencesGrid.StartPlacingDefence();
        GameManager.PlacingState = true;
        if(startingCountDown != null) startingCountDown();
    }

    public void PauseCountDown()
    {
        countingDown = false;
        if (pausingCountdown != null) pausingCountdown();
    }
    public void ContinueCountDown()
    {
        countingDown = true;
        if (contineCountdown != null) contineCountdown();
    }
    public void StopCountDown()
    {
        timeLeft = 0;
        uiManager.UpdateCountDownText((int)timeLeft);
        countingDown = false;
        DefencesGrid.StopPlacingDefence();
        GameManager.PlacingState = false;
        if (stoppingCountdown != null) stoppingCountdown();
    }
}
