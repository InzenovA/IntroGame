using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 7;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
    }

    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
        if (count >= numPickups)
        {
            winText.text = "You Win!";
        }
    }
}
