using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    int activeMessage =0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages)
    {
        currentMessages = messages;
        activeMessage = 0;
        isActive = true;
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f);
    }
    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;
        AnimateTextColor();
    }
    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInExpo();
            isActive = false;
        }

    }
    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }
    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.F)&& isActive ==  true) 
        {
            NextMessage();
        }
    }
}
