using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public interface IStateUI
    {
        void StartAnimation();
        void Animation();
        void EndAnimation();

    }

}
