using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using LitJson;

public class PanelController : MonoBehaviour
{
    public TextAsset textJSON;
    private PanelConfig panelConfig;
    private int index = 0;
    public Canvas canvas;
    public event System.Action OnClear;

    [System.Serializable]
    public class NarrativeEvent
    {
        public List<Dialogue> dialogues;

    }
    [System.Serializable]
    public struct Dialogue
    {
        public string name;
        public string dialogueText;
        public bool leftSide;
    }

    public static string startJson =
        "{\n  \'dialogues\': [\n    {\n      \'name\': \'Tavern Master\',\n      \'dialogueText\': \'You are very strange, are you new here!\',\n      \'leftSide\': true\n    },\n   {\n      \'name\': \'Knight\',\n      \'dialogueText\': \'Yeah! I come here from a far away country.\',\n      \'leftSide\': false\n    },\n   {\n      \'name\': \'Tavern Master\',\n      \'dialogueText\': \'Why you come here?\',\n      \'leftSide\': true\n    },\n   {\n      \'name\': \'Knight\',\n      \'dialogueText\': \'I hear about princess, is she here?\',\n      \'leftSide\': false\n    },\n     {\n      \'name\': \'Tavern Master\',\n      \'dialogueText\': \'Yeah! She is here ... you want to see her\',\n      \'leftSide\': true\n    },\n   {\n      \'name\': \'Tavern Master\',\n      \'dialogueText\': \'Just go to the door, she is in the last floor of the maze .. Good luck\',\n      \'leftSide\': true\n    },\n  {\n      \'name\': \'Knight\',\n      \'dialogueText\': \'Thanks!\',\n      \'leftSide\': false\n    }\n     ]\n}\n";

    public NarrativeEvent narrativeEvent = new NarrativeEvent();

    void Start()
    {
        narrativeEvent = JsonMapper.ToObject<NarrativeEvent>(startJson);
        panelConfig = GameObject.Find("TalkPanel").GetComponent<PanelConfig>();

        InitDialogue();
    }
    void Update()
    {
        if (Input.anyKeyDown && canvas.isActiveAndEnabled)
        {
            if (index < narrativeEvent.dialogues.Count)
            {
                var currentDialog = narrativeEvent.dialogues[index++];
                panelConfig.UpdatePanel(currentDialog);
            }
            else
            {
                if (OnClear != null)
                {
                    OnClear();
                }
                canvas.gameObject.SetActive(false);
            }
        }
    }

    public void InitDialogue()
    {
        index = 0;

        var currentDialog = narrativeEvent.dialogues[index++];
        panelConfig.UpdatePanel(currentDialog);
    }
}
