using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public AudioSource pickUpAudio;


    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count>=12)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movementVector*speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            pickUpAudio.Play();
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
        
    }
}
