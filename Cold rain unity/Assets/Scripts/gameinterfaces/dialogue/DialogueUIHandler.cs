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

        public void SetDialogueText(string text)
        {
            dialogueText.text = text;
        }

        public void SetSenderText(string text)
        {
            senderText.text = text;
        }

        public void ContinueDialogue()
        {

        }
    }
}
