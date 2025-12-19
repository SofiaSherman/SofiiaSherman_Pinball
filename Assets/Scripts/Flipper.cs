using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float force;
    private Rigidbody2D rb2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb2D.AddForce(new Vector3(0,force,0));
        }
    }
}
