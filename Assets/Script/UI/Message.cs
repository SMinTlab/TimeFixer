using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour

{
    public static readonly int MAX_LENGTH = 30;
    public static readonly int MAX_LINE = 5;

    public string[] sentences;
    Text text;

    float intervalForCharDisplay = 0.05f;
    private int currentSentenceNum = 0;
    private string currentSentence = string.Empty;
    private float timeUntilDisplay = 0;
    private float timeStartDisplay = 1;
    private int lastUpdateCharCount = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (sentences != null)
        {
            text = gameObject.GetComponent<Text>();
            for (int i = 0; i < sentences.Length; i++)
            {
                sentences[i] = insertLineBreaks(sentences[i]);
            }
            Next();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        int tail = (int)((Time.time - timeStartDisplay) / intervalForCharDisplay);
        if (tail<=currentSentence.Length)
        {
            text.text = currentSentence.Substring(0, tail);
        }
        


    }

    private void Next()
    {
        currentSentence = sentences[currentSentenceNum];
        timeUntilDisplay = currentSentence.Length * intervalForCharDisplay;
        timeStartDisplay = Time.time;
        currentSentenceNum++;
    }

    private string insertLineBreaks(string sentence)
    {
        string[] lines = sentence.Split('\n');
        int num = 0;
        string newSentence="";
        
        for (int i=0; i<lines.Length; i++)
        {
            num = lines[i].Length / MAX_LENGTH - lines[i].Length%MAX_LENGTH>0?0:1;
            for (int j = 0; j < num; j++)
            {
                lines[i] = lines[i].Insert(j*MAX_LENGTH+j, "\n");
            }
            newSentence = string.Concat(newSentence, lines[i], "\n");
        }
        return newSentence;

    }
}
