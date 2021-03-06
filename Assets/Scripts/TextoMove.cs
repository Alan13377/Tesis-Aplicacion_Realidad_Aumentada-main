using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextoMove : MonoBehaviour
{
    [TextArea]
    public string m_text;
    [Range(0.01f,0.2f)]
    public float m_characterInterval;

    private string m_partialText;
    private float m_cumulativeDeltaTime;

    private Text m_label;

    private void Awake()
    {
        m_label = GetComponent<Text>();
    }
    void Start()
    {
        m_partialText = "";
        m_cumulativeDeltaTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_cumulativeDeltaTime += Time.deltaTime;
        while(m_cumulativeDeltaTime > m_characterInterval && m_partialText.Length < m_text.Length)
        {
            m_partialText += m_text[m_partialText.Length];
            m_cumulativeDeltaTime -= m_characterInterval;
        }
        m_label.text = m_partialText;
    }
}
