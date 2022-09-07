using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InputScreen : MonoBehaviour
{
    private TMP_InputField inputField;
    private string inputText;
    public TMP_Text introText;

    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputText = inputField.text;
    }

    void Update()
    {
        inputText = inputField.text;
        if ((inputText == "FlappiBulle" || inputText == "Flappibulle") && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.sceneCount + 1);
        }
        else if (Input.GetKeyDown(KeyCode.Return) && inputText != "" )
        {
            Debug.Log(inputField.GetComponent<RectTransform>().position.y);
            introText.text += "Error\n";
            inputField.GetComponent<RectTransform>().localPosition = new Vector3(-46.1f, inputField.GetComponent<RectTransform>().position.y - 5, 0);
        }
    }
}
