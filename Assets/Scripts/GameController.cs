using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private View _view;
    [SerializeField] private CubeMover _cubePrefab;
    private Model _model;
    private Presenter _presenter;
    
    private void Start()
    {
        _model = new Model();
        _model.SetPrefab(_cubePrefab);
        _presenter = new Presenter(_view, _model);
    }

    private void OnDestroy()
    {
        _presenter.OnDisable();
    }
}