
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Presenter
{
    private View _view;
    private Model _model;
    private Spawner _spawner;

    public Presenter(View view, Model model)
    {
        _view = view;
        _model = model;
        _spawner = new Spawner(_model);
        OnEnable();
    }

    private void OnEnable()
    {
        _view.OnEndEditTime += _model.SetTimeToSpawn;
        _view.OnEndEditDistance += _model.SetDistance;
        _view.OnEndEditSpeed += _model.SetSpeed;
        
        _model.SetDistance("1");
        _model.SetSpeed("1");
        _model.SetTimeToSpawn("1");
        _spawner.Spawning = true;
        _spawner.CubeSpawner();
    }
    
    public void OnDisable()
    {
        _view.OnEndEditTime -= _model.SetTimeToSpawn;
        _view.OnEndEditDistance -= _model.SetDistance;
        _view.OnEndEditSpeed -= _model.SetSpeed;
        
        _spawner.Spawning = false;
    }
}

public class Spawner
{
    public bool Spawning;
    private Model _model;
    [SerializeField] private List<CubeMover> _cubeMovers = new List<CubeMover>();

    public Spawner(Model model)
    {
        _model = model;
    }
    
    public async void CubeSpawner()
    {
        CubeMover prefab;
        while (Spawning)
        {
            prefab = null;
            if (_cubeMovers.Count > 0)
            {
                foreach (var cube in _cubeMovers)
                {
                    if (cube.gameObject.activeSelf == false)
                    {
                        cube.transform.position = Vector3.zero;
                        prefab = cube;
                        break;
                    }
                }
            }

            if (prefab == null)
            {
                var cube = Object.Instantiate(_model.CubePrefab);
                _cubeMovers.Add(cube);
                prefab = cube;
            }
            prefab.gameObject.SetActive(true);
            prefab.SetCubeSettings(_model.Speed, _model.Distance);
            await Task.Delay((int)(_model.TimeSpawn * 1000));
        }
    }
}

public class Pool
{
    
}