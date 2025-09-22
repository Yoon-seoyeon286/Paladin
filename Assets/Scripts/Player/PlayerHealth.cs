using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public int Hp { get; private set; }

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        Hp = 100;

    }

  


}
