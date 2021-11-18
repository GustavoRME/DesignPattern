using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace StatePattern
{
    [RequireComponent(typeof(Button))]
    public class ButtonUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMesh = default;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            Debug.Log("Awaked");
        }

        public void CreateButton<T>(string buttonText, UnityAction<T> callBack, T param)
        {
            _textMesh.text = buttonText;
            _button.onClick.AddListener(delegate { callBack(param); });
            Debug.Log("Created");
        }
    }

}

