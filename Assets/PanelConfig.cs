using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelConfig : MonoBehaviour
{
    public bool isLeftNotRight;
    public Image leftAvatar;
    public Image rightAvatar;
    public Text textName;
    public Text textContent;
    private Color maskInactiveColor = new Color(0.5f, 0.5f, 0.5f);

    private void ToggleCharacterMask()
    {
        if (isLeftNotRight)
        {
            leftAvatar.color = Color.white;
            rightAvatar.color = maskInactiveColor;
        }
        else
        {
            rightAvatar.color = Color.white;
            leftAvatar.color = maskInactiveColor;
        }
    }

    public void UpdatePanel(PanelController.Dialogue dialogue)
    {
        isLeftNotRight = dialogue.leftSide;

        ToggleCharacterMask();

        textName.text = dialogue.name;
        textContent.text = dialogue.dialogueText;

    }    
}
