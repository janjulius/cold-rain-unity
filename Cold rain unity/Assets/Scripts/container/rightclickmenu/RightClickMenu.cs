using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RightClickMenu : MonoBehaviour
{
    public Image contentPanel;
    public Transform parent;
    private Image previousObject;

    private static RightClickMenu instance;

    public static RightClickMenu Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(RightClickMenu)) as RightClickMenu;
                if (instance == null)
                {
                    instance = new RightClickMenu();
                }
            }
            return instance;
        }
    }

    public void CreateContextMenu(List<RightClickMenuItem> items, Vector2 position)
    {
        if (previousObject != null)
            Destroy(previousObject.gameObject);

        Image panel = Instantiate(contentPanel, new Vector3(position.x, position.y, 0), Quaternion.identity) as Image;
        previousObject = panel;
        panel.transform.SetParent(parent);
        panel.transform.SetAsLastSibling();
        panel.rectTransform.anchoredPosition = position;

        foreach (var item in items)
        {
            RightClickMenuItem tempReference = item;
            Button button = Instantiate(item.button, panel.transform) as Button;
            TextMeshProUGUI buttonText = button.GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            buttonText.text = item.text;
            button.onClick.AddListener(delegate { tempReference.action(panel); });
            button.transform.SetParent(panel.transform);
        }
    }
}
