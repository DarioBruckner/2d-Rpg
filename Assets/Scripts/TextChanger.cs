using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{



    public Text battlelog;

    // Start is called before the first frame update
    void Start()
    {
        battlelog.text = "Enemy approching...";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
