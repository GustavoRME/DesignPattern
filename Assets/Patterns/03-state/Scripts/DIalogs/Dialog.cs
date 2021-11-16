using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "State/UI/Dialog")]
public class Dialog : ScriptableObject
{
    [SerializeField] private string _dialogMessage = "Write your dialog here...";

    public string DialogMessage => _dialogMessage;
}
