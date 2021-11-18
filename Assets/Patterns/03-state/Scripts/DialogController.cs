using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class DialogController : MonoBehaviour
    {
        [SerializeField] private ADialogPanel[] _dialogs = default;

        [Space]
        [SerializeField] private ButtonUI _prefab = default;
        [SerializeField] private RectTransform _parent = default;

        private ADialogPanel _curDialog;

        private void Awake()
        {
            for (int i = 0; i < _dialogs.Length; i++)
            {
                var button = Instantiate(_prefab, _parent);
                button.CreateButton(_dialogs[i].DialogPanelName, SwitchDialog, _dialogs[i]);
            }
        }

        private void Update()
        {
            if (_curDialog == null)
                return;

            _curDialog.Execute();
        }

        private void SwitchDialog(ADialogPanel dialogPanel)
        {
            if (dialogPanel == null) return;
            if (dialogPanel == _curDialog) return;

            if (_curDialog != null)
                _curDialog.EndAnimation();

            _curDialog = dialogPanel;
            _curDialog.StartAnimation();
        }
    }

}

