using System.Drawing;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    float width;
    public float backDistance = 6.5f;
    public float moveTiming = 3.5f;

    void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -width*moveTiming)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        Vector2 offset = new Vector2(width *backDistance, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
