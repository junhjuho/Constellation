using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Text dialogText;
    public bool isAction;

    // Start is called before the first frame update

    void OnEnable()
    {
        string sampleText = dialogText.text;
        dialogText.text = "";
        StartCoroutine(Typing(sampleText));
    }

    // Update is called once per frame
    void Update() 
    {

    }

    IEnumerator Typing(string text)
    {
        foreach (char letter in text.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }
}