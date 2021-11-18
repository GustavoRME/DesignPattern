using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StatePattern
{
    [RequireComponent(typeof(Animator))]
    public class DialogPanel : ADialogPanel
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public override void Execute()
        {
            foreach (var d in _dialogs)
            {
                d.Animation();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var d in _dialogs)
                {
                    d.EndAnimation();
                }
            }
        }

        public override void StartAnimation()
        {
            gameObject.SetActive(true);
            _animator.SetTrigger("Show");
        }

        public override void Animation()
        {
            base.Animation();
        }

        public override void EndAnimation()
        {
            _animator.SetTrigger("Out");
        }
    }

}

