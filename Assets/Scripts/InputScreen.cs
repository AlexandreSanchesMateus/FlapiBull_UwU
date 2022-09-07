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
    public TMP_Text floatroText;
    public GameObject jojoSong;
    private Vector3 inputPosition;

    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputText = inputField.text;
        inputPosition = new Vector3(-46.1f, inputField.GetComponent<RectTransform>().position.y - 72, 0);
    }

    void Update()
    {
        inputText = inputField.text;
        if (inputText.ToLower() == "run\"flappiBulle"  && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.sceneCount + 1);
        }

        else if (inputText.ToLower() == "dl\"jba.ogg" && Input.GetKeyDown(KeyCode.Return))
        {
            jojoSong.SetActive(true);
            floatroText.text = "";
            inputField.text = "";
        }

        else if (Input.GetKeyDown(KeyCode.Return) && inputText != "" )
        {
            Debug.Log(inputField.GetComponent<RectTransform>().position.y);
            introText.text += "Error\n";

            //inputField.GetComponent<RectTransform>().localPosition = inputPosition;
            //inputPosition = new Vector3(inputPosition.x, inputPosition.y - 12, inputPosition.z);

            floatroText.text = "";
            inputField.text = "";
        }
    }
}
