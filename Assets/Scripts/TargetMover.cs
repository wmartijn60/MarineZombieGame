using UnityEngine;

public class TargetMover : MonoBehaviour
{
    private Vector3 targetStartPosition;
    private Vector3 moveDirection;
    private GameObject target;
    [SerializeField] private float maximumDistanceAway = 1;
    [SerializeField] private float stepSize = 0.05f;

    void Start()
    {
        target = gameObject;
        targetStartPosition = target.transform.position;
        moveDirection = Vector3.right * stepSize;
    }

    void Update()
    {
        MoveTarget();
    }

    private void MoveTarget()
    {
        if (Vector3.Distance(targetStartPosition, target.transform.position) >= maximumDistanceAway)
        {
            moveDirection *= -1;
        }
        target.transform.position += moveDirection;
    }
}
