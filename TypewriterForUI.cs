using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TypewriterUI : MonoBehaviour
{
    private Text _text;
    private TMP_Text _tmpProText;
    private string originalText;
    private int charsLeft;

    [SerializeField] private float startDelay = 0f;
    [SerializeField] private float charDelay = 0.1f;
    [SerializeField] private string leadingChar = "";
    [SerializeField] private bool leadingCharBeforeDelay = false;

    private void Start()
    {
        _text = GetComponent<Text>();
        _tmpProText = GetComponent<TMP_Text>();

        if (_text != null)
        {
            StartCoroutine(TypeWriter(_text, originalText = _text.text));
        }

        if (_tmpProText != null)
        {
            StartCoroutine(TypeWriter(_tmpProText, originalText = _tmpProText.text));
        }

        
    }

    private IEnumerator TypeWriter(Text textComponent, string text)
    {
        textComponent.text = leadingCharBeforeDelay ? leadingChar : "";
        yield return new WaitForSeconds(startDelay);

        foreach (char c in text)
        {
            if (textComponent.text.Length > 0) textComponent.text = textComponent.text.Substring(0, textComponent.text.Length - leadingChar.Length);
            textComponent.text += c + leadingChar;
            yield return new WaitForSeconds(charDelay);
        }

        if (leadingChar != "") textComponent.text = textComponent.text.Substring(0, textComponent.text.Length - leadingChar.Length);
    }

    private IEnumerator TypeWriter(TMP_Text textMeshProComponent, string text)
    {
        textMeshProComponent.text = leadingCharBeforeDelay ? leadingChar : "";
        yield return new WaitForSeconds(startDelay);

        foreach (char c in text)
        {
            if (textMeshProComponent.text.Length > 0) textMeshProComponent.text = textMeshProComponent.text.Substring(0, textMeshProComponent.text.Length - leadingChar.Length);
            textMeshProComponent.text += c + leadingChar;
            yield return new WaitForSeconds(charDelay);
        }

        if (leadingChar != "") textMeshProComponent.text = textMeshProComponent.text.Substring(0, textMeshProComponent.text.Length - leadingChar.Length);
    }
}

