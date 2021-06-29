using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextFaderGameOver : MonoBehaviour
{
    private float f_elapsedTime = 0f;
    private float f_fadeTime = 4f;
    private TextMeshProUGUI textMesh;
    bool b_reverse = false;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!b_reverse && f_elapsedTime < 1.2f)
        {
            f_elapsedTime += Time.deltaTime / f_fadeTime;
        } else
        {
            b_reverse = true;
            f_elapsedTime -= Time.deltaTime / f_fadeTime;
        }
        textMesh.fontMaterial.SetColor("_FaceColor", Color.Lerp(Color.clear, Color.white, f_elapsedTime));
        textMesh.fontMaterial.SetColor("_OutlineColor", Color.Lerp(Color.clear, Color.red, f_elapsedTime / 2.5f));
        if (f_elapsedTime < 0 || Input.anyKeyDown)
        {
            SceneManager.LoadScene("main menu");
        }
    }
}
