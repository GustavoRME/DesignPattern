using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionConfigurationUI : MonoBehaviour
{
    [Space]
    [SerializeField] private TextMeshProUGUI _actionName = default;
    [SerializeField] private TextMeshProUGUI _keyName = default;
    [SerializeField] private Image _buttonImage = default;

    [Header("Feedback colors")]
    [SerializeField] private Color _listeningColor = Color.black;
    [SerializeField] private Color _changedColor = Color.black;
    [SerializeField] private float _lerpingColorTime = 2.0f;

    [Header("Default Configs")]
    [SerializeField] private string _defaultAction = "";
    [SerializeField] private string _defaultKey = "";

    private Color _normalColor;
    private bool _isListening;

    private Coroutine _lerpCoroutine;
    private CommandHold _commandHold;

    private void Start()
    {
        //Set default values
        _normalColor = _buttonImage.color;
        _actionName.text = _defaultAction;
        _keyName.text = _defaultKey;

        _commandHold = GetComponent<CommandHold>();
    }

    private void OnDestroy()
    {
        if (_lerpCoroutine != null)
            StopCoroutine(_lerpCoroutine);
    }

    private void OnValidate()
    {
        _actionName.text = _defaultAction;
        _keyName.text = _defaultKey;
    }

    public void SwapOutListening()
    {
        _isListening = !_isListening;
        //_bindActions.ListeningKeys(_isListening, this);

        if (_isListening) _buttonImage.color = _listeningColor;
        else _buttonImage.color = _normalColor;
    }

    public void SetKey(string key)
    {
        _keyName.text = key;
        _lerpCoroutine = StartCoroutine(LerpColor());
    }

    private IEnumerator LerpColor()
    {
        float time = Time.time;
        while (Time.time - time < _lerpingColorTime)
        {
            float normalized = (Time.time - time) / _lerpingColorTime;
            float r = Mathf.Lerp(_changedColor.r, _normalColor.r, normalized);
            float g = Mathf.Lerp(_changedColor.g, _normalColor.g, normalized);
            float b = Mathf.Lerp(_changedColor.b, _normalColor.b, normalized);

            _buttonImage.color = new Color(r, g, b);

            yield return null;
        }
    }
}
