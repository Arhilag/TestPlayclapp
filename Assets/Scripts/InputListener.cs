using System;
using TMPro;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField] private TMP_InputField _input;
    public Action<string> OnEndEdit;

    private void Awake()
    {
        _input.onEndEdit.AddListener(EndEdit);
    }

    private void OnDestroy()
    {
        _input.onEndEdit.RemoveListener(EndEdit);
    }

    private void EndEdit(string inputString)
    {
        OnEndEdit?.Invoke(inputString);
    }
}
