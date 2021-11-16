using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ADialogBalloon : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] protected Dialog _dialog = default;
    [SerializeField] protected TextMeshProUGUI _textMesh = default;


    private void OnValidate()
    {
        if (_dialog == null) return;
        if (_textMesh == null) return;

        _textMesh.text = _dialog.DialogMessage;
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {

    }

    protected virtual void StarAnimationWrite()
    {

    }

    public virtual void EndAnimationWrite()
    {

    }

    public virtual void AnimationWrite()
    {

    }
}
