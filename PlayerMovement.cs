using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    public float moveSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Text gameMessage;
    public GameObject destroyText;
    int waitTime = 3;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject Lantern;
    public GameObject waypointsHolder;
    private int thoughtCount = 0;

    Vector3 velocity;

    bool isGrounded;
    bool lanternUsed;
    bool healerUsed;
    public static bool hasLantern;

    private GameObject lantern;

    public string[] thoughtsNeg = {
        "I am not worth anything.",
        "I have never accomplished anything.",
        "I always make mistakes.",
        "I am a jerk.",
        "I don't deserve a good life.",
        "I am stupid."
    };

    void Start() {
        lantern = GameObject.Find("Lantern");
        destroyText = GameObject.Find("DestroyText");
        lantern.transform.gameObject.SetActive(false);
        waypointsHolder.SetActive(false);
        
        hasLantern = false;

        gameMessage.text = "";
        DestroyText(false);
    }
    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        // Lantern script
        if(Input.GetKeyDown("e") && hasLantern){
            // Use lantern
            lanternUsed = true;
            lantern.transform.gameObject.SetActive(true);

        }

        if(Input.GetKeyDown("q") && hasLantern){
            // Put lantern away
            lanternUsed = false;
            lantern.transform.gameObject.SetActive(false);
            //set healing tablet
        }

        if(hasLantern) {
            waypointsHolder.SetActive(true);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(thoughtCount >= thoughtsNeg.Length) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.tag == "T1") {
            gameMessage.text = thoughtsNeg[0];
            DestroyText(true);
            if(Input.GetKeyDown("space")) {
                Destroy(other.gameObject);
                gameMessage.text = "Thought destroyed";
                DestroyText(false);
                thoughtCount++;
            }
        }
        
        if(other.tag == "T2") {
            gameMessage.text = thoughtsNeg[1];
            DestroyText(true);
            if(Input.GetKeyDown("space")) {
                Destroy(other.gameObject);
                gameMessage.text = "Thought destroyed";
                DestroyText(false);
                thoughtCount++;
            }
        }
        
        if(other.tag == "T3") {
            gameMessage.text = thoughtsNeg[2];
            DestroyText(true);
            if(Input.GetKeyDown("space")) {
                Destroy(other.gameObject);
                gameMessage.text = "Thought destroyed";
                DestroyText(false);
                thoughtCount++;
            }
        }
        
        if(other.tag == "T4") {
            gameMessage.text = thoughtsNeg[3];
            DestroyText(true);
            if(Input.GetKeyDown("space")) {
                Destroy(other.gameObject);
                gameMessage.text = "Thought destroyed";
                DestroyText(false);
                thoughtCount++;
            }
        }
        
        if(other.tag == "T5") {
            gameMessage.text = thoughtsNeg[4];
            DestroyText(true);
            if(Input.GetKeyDown("space")) {
                Destroy(other.gameObject);
                gameMessage.text = "Thought destroyed";
                DestroyText(false);
                thoughtCount++;
            }
        }
        
        if(other.tag == "T6") {
            gameMessage.text = thoughtsNeg[5];
            DestroyText(true);
            if(Input.GetKeyDown("space")) {
                Destroy(other.gameObject);
                gameMessage.text = "Thought destroyed";
                DestroyText(false);
                thoughtCount++;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Lantern") {
            hasLantern = true;
            Destroy(Lantern);
            StartCoroutine(LanternMessages());
        }
    }

    private IEnumerator LanternMessages() {
        gameMessage.text = "Picked up lantern";
        yield return new WaitForSeconds(3f);
        gameMessage.text = "";
        yield return new WaitForSeconds(1f);
        gameMessage.text = "Press E to use the lantern, press Q to put away.";
        yield return new WaitForSeconds(3);
        gameMessage.text = "";
    }

    private IEnumerator WaitABit(int waitTime) {
        yield return new WaitForSeconds(waitTime);
    }

    void DestroyText(bool _value) {
        destroyText.transform.gameObject.SetActive(_value);
    }

}
