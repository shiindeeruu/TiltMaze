using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    [SerializeField]
    private AudioClip coinSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 14)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            AudioSource.PlayClipAtPoint(coinSound, transform.position);

            SetCountText();
        }

        if(other.gameObject.CompareTag("Chicken"))
        {
            transform.position = new Vector3(8.5f, 0.5f, 9.0f);
        }
    }
}
