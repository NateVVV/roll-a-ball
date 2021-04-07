using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text timeText;

    private Rigidbody rb;
    private int count;
    private int maxCount;
    private const string winTextStr = "You Win!"; 

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = winTextStr;
        winText.enabled = false;
        timeText.text = "0.0";
        GameObject[] getCount = GameObject.FindGameObjectsWithTag("Pick Up");
        maxCount = getCount.Length;
        SetCountText();
    }
	
	// Update is called once per frame
	void Update () {
        if(!winText.enabled)
        {
            timeText.text = Time.fixedTime.ToString();
        }
	}

    private void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= maxCount)
        {
            winText.enabled = true;
        }
    }
}
