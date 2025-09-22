using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float stopDistance = 2f;
    public Transform player;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
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
        PlayerHealth playerHealth = FindAnyObjectByType<PlayerHealth>();
        playerHealth.Damage(damage);
    }
}
