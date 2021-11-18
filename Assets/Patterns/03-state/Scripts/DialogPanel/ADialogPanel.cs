using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public abstract class ADialogPanel : MonoBehaviour, IStateUI
    {
        [SerializeField] protected DialogBalloon[] _dialogs = default;
        [SerializeField] protected string _dialogPanelName = "";

        public string DialogPanelName => _dialogPanelName;
        protected Stack<ADialogBalloon> _dialogsState = new Stack<ADialogBalloon>();

        public virtual void Animation()
        {

        }

        public virtual void EndAnimation()
        {

        }

        public virtual void StartAnimation()
        {

        }

        public virtual void Execute()
        {

        }
    }

}
