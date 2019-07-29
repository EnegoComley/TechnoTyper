using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardKeyDetector : MonoBehaviour
{
    const float scaleDownButton = 0.8f;
    const float scaleUpButton = 1.0f;

    public string keyName;
    Text text;
    Transform imageTransform;
    Transform textTransform;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        var parent = GameObject.Find(text.text);
        if(parent != null)
        {
            imageTransform = parent.transform;
        }
        textTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        text.color = Color.white;
        imageTransform.localScale = new Vector3(scaleUpButton, scaleUpButton);
        textTransform.localScale = new Vector3(2, 2);
        if (Input.GetKey(keyName))
        {
            text.color = Color.red;
            Debug.Log(text.text);
            imageTransform.localScale = new Vector3(scaleDownButton, scaleDownButton);
            textTransform.localScale = new Vector3(2.5f, 2.5f);
            
        }
    }
}
