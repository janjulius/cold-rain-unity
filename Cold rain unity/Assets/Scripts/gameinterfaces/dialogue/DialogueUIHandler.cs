using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using Assets.Scripts.dialogue;
using UnityEngine.UI;

namespace Assets.Scripts.gameinterfaces.dialogue
{
    public class DialogueUIHandler : MonoBehaviour
    {
        private Dialogue dialogue;

        public TextMeshProUGUI dialogueText;
        public TextMeshProUGUI senderText;

        public Button nextButton;

        public GameObject OptionButtonPanel;
        public Button[] optionButtons = new Button[5];

        public void SetDialogueText(string text)
        {
            dialogueText.text = text;
            nextButton.gameObject.SetActive(true);
        }

        public void SetSenderText(string text)
        {
            senderText.text = text;
        }

        public void SetOptionsTexts(params string[] options)
        {
            nextButton.gameObject.SetActive(false);

            OptionButtonPanel.SetActive(true);
            foreach(Button button in optionButtons)
            {
                button.gameObject.SetActive(false);
            }

            for (int i = 0; i < options.Length; i++)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = options[i];
            }

        }

        public void ContinueDialogue()
        {

        }
    }
}
