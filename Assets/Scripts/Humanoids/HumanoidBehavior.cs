using UnityEngine;
using System.Collections;

public class HumanoidBehavior : MonoBehaviour
{
	
	public Transform target;
    protected Transform defaultTarget;
    public float speed = 20;

	private Vector2[] path;
	private int targetIndex;
	private float refreshTime = 0.25f;
	[SerializeField] private HealthSystem health;
    public Animator anim;


	protected virtual void Start() 
	{
        defaultTarget = GameObject.FindGameObjectsWithTag("Player")[Random.Range(0, 2)].transform;
        health.died += Die;
        anim = GetComponent<Animator>();
        StartCoroutine (RefreshPath ());       
    }

	private IEnumerator RefreshPath() 
	{
		Vector2 targetPositionOld = (Vector2)target.position + Vector2.up; // ensure != to target.position initially
			
		while (true) 
		{
			if (target == null) target = defaultTarget;
            if (targetPositionOld != (Vector2)target.position)
            {
                targetPositionOld = (Vector2)target.position;

                path = Pathfinding.RequestPath(transform.position, target.position);
                StopCoroutine("FollowPath");
                StartCoroutine("FollowPath");
                anim.SetBool("isRunning", true);
            }

			yield return new WaitForSeconds (refreshTime);
		}
	}
		
	private IEnumerator FollowPath() 
	{
		if (path.Length > 0)
		{
			targetIndex = 0;
			Vector2 currentWaypoint = path [0];

			while (true)
			{
				if ((Vector2)transform.position == currentWaypoint)
				{
					targetIndex++;
					if (targetIndex >= path.Length) {
						yield break;
					}
					currentWaypoint = path [targetIndex];
				}

				transform.position = Vector2.MoveTowards (transform.position, currentWaypoint, speed * Time.deltaTime);
				yield return null;
			}
		}
	}

	private void Die() 
	{
		anim.SetBool("isAlive", false);
        
		Destroy(gameObject, 1f); // change time depending on animation duration
    }

	public void OnDrawGizmos() 
	{
		if (path != null)
		{
			for (int i = targetIndex; i < path.Length; i ++)
			{
				Gizmos.color = Color.green;

				if (i == targetIndex) 
				{
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else 
				{
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}

    protected virtual void OnDestroy()
	{
		GameManager.CheckWaveStatus();
    }
}
