using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float stopDistance = 2f;
    public Transform player;
    Animator animator;
    PlayerHealth playerHealth;


    void Awake()
    {
        
        animator = GetComponent<Animator>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            playerHealth = playerObj.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
                animator.SetBool("Attack", false);
            }

            else
            {
                animator.SetBool("Attack", true);
            }

        }
    }

    public void Attack(float damage)
    {
       
        playerHealth.Damage(damage);
    }
}
