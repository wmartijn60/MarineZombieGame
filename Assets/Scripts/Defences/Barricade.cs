public class Barricade : Defence
{
    private HealthSystem health;

    void Start()
    {
        health = GetComponent<HealthSystem>();
        health.died += Destroyed;
    }

    public override void PlaceDefence()
    {
        base.PlaceDefence();
        Invoke("DisableAnimator", 1f);
    }

    public override void Destroyed() {
        base.Destroyed();
        Destroy(gameObject, 1f); // change time depending on animation duration
    }

    private void DisableAnimator()
    {
        spawnAnimator.enabled = false;
    }
}
