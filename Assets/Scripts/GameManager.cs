using control;
using management;
using UnityEngine;
using UnityEngine.Events;
using data;

public class GameManager : MonoBehaviour
{
    public delegate void GameEvents();
    private event GameEvents _onWin;
    public event GameEvents onWin
    {
        add
        {
            _onWin += value;
        }
        remove
        {
            _onWin -= value;
        }
    }

    private event GameEvents _onLose;
    public event GameEvents onLose
    {
        add
        {
            _onLose += value;
        }
        remove
        {
            _onLose -= value;
        }
    }

    private event GameEvents _onStart;
    public event GameEvents onStart
    {
        add
        {
            _onStart += value;
        }
        remove
        {
            _onStart -= value;
        }
    }

    private bool _isStarted = false;
    public bool isStarted
    {
        get { return _isStarted; }
    }

    private bool _isWin = false;
    public bool isWin
    {
        get { return _isWin; }
    }

    private bool _isLost = false;
    public bool isLost
    {
        get { return _isLost; }
    }

    private bool _isGameFinished = false;
    public bool isGameFinished
    {
        get { return _isGameFinished; }
    }

    [Header("Controls and Managers")]
    [SerializeField]
    private ControllerInputs3D _controllerInputs;
    public ControllerInputs3D controllerInputs
    {
        get { return _controllerInputs; }
    }

    [SerializeField]
    private LevelsManager _levelsManager;
    public LevelsManager levelsManager
    {
        get { return _levelsManager; }
    }

    [SerializeField]
    private MainCanvasManager _mainCanvasManager;
    public MainCanvasManager mainCanvasManager
    {
        get { return _mainCanvasManager; }
    }

    [SerializeField]
    private GameData _gameData;
    public GameData gameData
    {
        get { return _gameData; }
    }

    private void Start()
    {
        MakeStart();
    }

    public void MakeStart()
    {
        _isStarted = true;
        _onStart.Invoke();
    }

    public void MakeWin()
    {
        if (_isWin || _isLost)
            return;

        _isWin = true;
        _isGameFinished = true;
        _onWin.Invoke();
    }

    public void MakeLost()
    {
        if (_isWin || _isLost)
            return;

        _isLost = true;
        _isGameFinished = true;
        _onLose.Invoke();
    }

    public bool IsGameFinished()
    {
        return !(_isWin && _isLost);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_gameData == null)
            _gameData = FindObjectOfType<GameData>();

        if (_mainCanvasManager == null)
            _mainCanvasManager = FindObjectOfType<MainCanvasManager>();

        if (_controllerInputs == null)
            _controllerInputs = FindObjectOfType<ControllerInputs3D>();

        if (_levelsManager == null)
            _levelsManager = FindObjectOfType<LevelsManager>();
    }
#endif
}
