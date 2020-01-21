using Assets.Scripts.contants;
using Assets.Scripts.logger;
using Assets.Scripts.saving;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.gameinterfaces.console
{
    public class GameConsole : Node
    {
        private GameConsole() { }
        public static GameConsole Instance;

        public TMP_InputField inputfield;
        public ConsoleMessage textfield;
        public Transform contentField;
        public Scrollbar Scrollbar;
        private const int maxTextFields = 100;
        private List<ConsoleMessage> history = new List<ConsoleMessage>();
        private GameManager gameManager;
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
            gameManager = Camera.main.GetComponent<GameManager>();
            player = gameManager.player;
            inputfield.onSelect.AddListener(OnTextFieldSelected);
            inputfield.onDeselect.AddListener(OnTextFieldDeselected);
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
                Destroy(history[0].gameObject);
                history.RemoveAt(0);
            }
            if (text.StartsWith(Constants.COMMAND_PREFIX))
                ProcessCommand(inputfield.text);

            ConsoleMessage obj = Instantiate(textfield, contentField);
            obj.Message = text;
            obj.Filtered = isFiltered;
            obj.GetComponent<TextMeshProUGUI>().text = text;
            history.Add(obj);

            inputfield.text = "";
        }

        public void SendConsoleMessage(string text)
        {
            ProcessInput(text, false);
            CrLogger.Log(this, text, CrLogger.LogType.CONSOLE);
        }

        public void SendFilteredConsoleMessage(string text)
        {
            ProcessInput(text, true);
            CrLogger.Log(this, text, CrLogger.LogType.FILTERED);
        }

        public void SendDevMessage(string text)
        {
            if (Constants.DEVELOPER_MODE)
            {
                ProcessInput(text, true);
                CrLogger.Log(this, text, CrLogger.LogType.DEVELOPER);
            }
        }
        
        private void OnTextFieldSelected(string args0)
        {
            player.Lock();
        }

        public void OnTextFieldDeselected(string args0)
        {
            player.Unlock();
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
            HideButton.GetComponentInChildren<TextMeshProUGUI>().text = enabled ? "Hide Console" : "Show Console";
        }

        public void ProcessCommand(string text)
        {
            CommandHandler.ProcessCommand(gameManager,text);
        }
    }
}
