using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        
    }
}
