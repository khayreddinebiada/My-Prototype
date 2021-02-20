using control;
using management;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get { return _instance; }
    }

    private UnityEvent _onStart;
    public UnityEvent onStart
    {
        get { return _onStart; }
    }

    private UnityEvent _onWin;
    public UnityEvent onWin
    {
        get { return _onWin; }
    }

    private UnityEvent _onLost;
    public UnityEvent onLost
    {
        get { return _onLost; }
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
    private ControllerInputs3D _ontrollerInputs;
    public ControllerInputs3D controllerInputs
    {
        get { return _ontrollerInputs; }
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

    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;

        _onStart = new UnityEvent();
        _onWin = new UnityEvent();
        _onLost = new UnityEvent();
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
        _onLost.Invoke();
    }

    public bool IsGameFinished()
    {
        return !(_isWin && _isLost);
    }
}
