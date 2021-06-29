using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextScrollCredits : MonoBehaviour
{
    float f_scrollTime = 30f;
    float f_elapsedTime = 0.0f;
    Vector3 m_start;
    Vector3 m_end;

    // Start is called before the first frame update
    void Start()
    {
        m_start = transform.position;
        m_end = transform.position + new Vector3(0, 2000, 0);
    }

    // Update is called once per frame
    void Update()
    {
        f_elapsedTime += Time.deltaTime / f_scrollTime;
        transform.position = Vector3.Lerp(m_start, m_end, f_elapsedTime);
        if (f_elapsedTime > 1.1f || Input.anyKeyDown)
        {
            SceneManager.LoadScene("main menu");
        }
    }
}
