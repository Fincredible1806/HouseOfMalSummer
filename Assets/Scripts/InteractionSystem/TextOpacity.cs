using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextOpacity : MonoBehaviour
{
    [SerializeField] TMP_Text uiInfoText;
    [SerializeField] float fadeSpeed = 0.3f;
    [SerializeField] public float fadeTime = 2f;
    void Update()
    {
        fadeTime -= Time.deltaTime * fadeSpeed;
        uiInfoText.color = Color.Lerp(Color.clear, Color.white, fadeTime);
        fadeTime = Mathf.Clamp(fadeTime, -2f, 3f);
    }
}
