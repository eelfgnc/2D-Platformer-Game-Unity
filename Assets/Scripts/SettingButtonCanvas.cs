using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButtonCanvas : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private Button button;

    private void Awake()
    {
        button.onClick.AddListener(() => {
            settingPanel.SetActive(true);
        });
    }

}
