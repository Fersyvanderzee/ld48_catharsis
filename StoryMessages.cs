using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryMessages : MonoBehaviour
{
    public Text StoryMessage;
    private bool continueStory = true;
    
    void Start() {
        StoryMessage.text = "";
        StartCoroutine(Messages(3));
    }

    void Update() {
        if(PlayerMovement.hasLantern && continueStory) {
            StartCoroutine(Messages2(3));
            StopCoroutine(Messages2(3));
        }

    }

    private IEnumerator Messages(int showTime) {
        yield return new WaitForSeconds(1f);
        StoryMessage.text = "Welcome to the Forest of Thought.";
        yield return new WaitForSeconds(showTime);
        StoryMessage.text = "";
        yield return new WaitForSeconds(1f);
        StoryMessage.text = "It's quite dark in the patient's mind.";
        yield return new WaitForSeconds(showTime);
        StoryMessage.text = "";
        yield return new WaitForSeconds(1f);
        StoryMessage.text = "Pick up the lantern indicated on your HUD.";
        yield return new WaitForSeconds(showTime);        
    }

    private IEnumerator Messages2(int showTime) {
        StoryMessage.text = "Good. Now track down the thoughts on your HUD.";
        yield return new WaitForSeconds(showTime);
        StoryMessage.text = "";
        yield return new WaitForSeconds(1);
        continueStory = false;
    }
}
