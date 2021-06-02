using UnityEngine;

public  class Survivor : HumanoidBehavior
{
    [SerializeField]private float leapDistance = 1;
    [SerializeField]private int coinsAmountToGive = 20;
    public int CoinsAmountToGive { get { return coinsAmountToGive; } }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Barricade")
        {
            anim.SetBool("isJumping", true);
            AnimatorClipInfo[] info = anim.GetCurrentAnimatorClipInfo(0);

            Invoke("JumpOver", info[0].clip.length);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EndZone")
        {
            anim.SetBool("isCheering", true);
        }
    }
      
    private void JumpOver()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - leapDistance);
        anim.SetBool("isJumping", false);
    }
}
