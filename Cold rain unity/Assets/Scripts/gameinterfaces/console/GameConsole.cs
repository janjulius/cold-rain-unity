using Assets.Scripts.contants;
using Assets.Scripts.saving;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.gameinterfaces.console
{
    public class GameConsole : Node, SavingModule
    {
        private GameConsole() { }
        public static GameConsole Instance;

        public TMP_InputField inputfield;
        public ConsoleMessage textfield;
        public Transform contentField;
        private const int maxTextFields = 100;
        private List<ConsoleMessage> history = new List<ConsoleMessage>();
        private Player player;

        public Button FilterButton;
        public Button UnFilterButton;
        public Button HideButton;

        public override void Initiate()
        {
            base.Initiate();
            Instance = this;
        }

        public override void StartInitiate()
        {
            base.StartInitiate();
            UnFilterMessages(); //TODO: make savingmodule load this from prev session
            enabled = true;
            player = Camera.main.GetComponent<GameManager>().player;
        }

        private void Update()
        {
            if (inputfield.text != "")
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    ProcessInput(inputfield.text, false);
                }
            }
        }

        private void ProcessInput(string text, bool isFiltered)
        {
            if (history.Count >= maxTextFields)
            {
                Destroy(history[0]);
                history.RemoveAt(0);
            }
            if (text.StartsWith(Constants.COMMAND_PREFIX))
                ProcessCommand(inputfield.text);

            ConsoleMessage obj = Instantiate(textfield, contentField);
            obj.Message = text;
            obj.Filtered = isFiltered;
            obj.GetComponent<TextMeshProUGUI>().text = text;
            obj.transform.SetSiblingIndex(0);
            history.Add(obj);

            inputfield.text = "";
        }

        public void SendConsoleMessage(string text) => ProcessInput(text, false);
        public void SendFilteredConsoleMessage(string text) => ProcessInput(text, true);
        public void SendDevMessage(string text) { if (Constants.DEVELOPER_MODE) { ProcessInput(text, true); } }

        public void OnTextFieldSelected()
        {
            player.BlockMovement(float.MaxValue);
        }

        public void OnTextFieldDeselected()
        {
            player.UnlockMovement();
        }

        public void FilterMessages()
        {
            UnFilterButton.gameObject.SetActive(true);
            FilterButton.gameObject.SetActive(false);
            foreach (ConsoleMessage cm in history)
            {
                cm.gameObject.SetActive(!cm.Filtered);
            }
        }

        public void UnFilterMessages()
        {
            FilterButton.gameObject.SetActive(true);
            UnFilterButton.gameObject.SetActive(false);
            foreach (ConsoleMessage cm in history)
            {
                cm.gameObject.SetActive(true);
            }
        }

        public void ToggleConsoleActivity()
        {
            enabled = !enabled;
            inputfield.gameObject.SetActive(enabled);
            contentField.parent.parent.gameObject.SetActive(enabled);
            HideButton.GetComponentInChildren<TextMeshProUGUI>().text = enabled ? "Hide\nConsole" : "Show\nConsole";
        }

        public void ProcessCommand(string text)
        {

        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
