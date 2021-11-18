using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace StatePattern
{
    public abstract class ADialogBalloon : MonoBehaviour, IStateUI
    {
        [SerializeField] protected Dialog _dialog = default;

        [Space]
        [SerializeField] protected TextMeshProUGUI _textMesh = default;

        private void OnValidate()
        {
            if (_dialog == null) return;
            if (_textMesh == null) return;

            _textMesh.text = _dialog.DialogMessage;
        }

        public virtual void StartAnimation()
        {

        }

        public virtual void Animation()
        {

        }

        public virtual void EndAnimation()
        {

        }
    }

}
