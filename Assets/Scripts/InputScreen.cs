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
    public GameObject megaBullania;
    private Vector3 inputPosition;
    public GameObject wattilogo;


    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputText = inputField.text;
        inputPosition = new Vector3(-46.1f, inputField.GetComponent<RectTransform>().position.y - 72, 0);
    }

    void Update()
    {
        inputText = inputField.text;
        if (inputText.ToLower() == "run\"flappibulle"  && Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(ecranIntroWatti());
        }

        else if (inputText.ToLower() == "dl\"jba.ogg" && Input.GetKeyDown(KeyCode.Return))
        {
            jojoSong.SetActive(true);
            floatroText.text = "";
            inputField.text = "";
        }

        else if (inputText.ToLower() == "dl\"megabullania.ogg" && Input.GetKeyDown(KeyCode.Return))
        {
            megaBullania.SetActive(true);
            floatroText.text = "";
            inputField.text = "";
        }

        else if (Input.GetKeyDown(KeyCode.Return) && inputText != "" )
        {
            Debug.Log(inputField.GetComponent<RectTransform>().position.y);
            introText.text += "Error\n";

            floatroText.text = "";
            inputField.text = "";
        }
    }

    private IEnumerator ecranIntroWatti ()
    {
        wattilogo.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.sceneCount);
    }
}
