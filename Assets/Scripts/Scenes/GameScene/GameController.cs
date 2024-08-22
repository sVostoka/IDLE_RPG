using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController s_Instance { get; private set; }

    #region -Buttons-
    [Header("Buttons")]
    [SerializeField] private Button _startFightButton;
    [SerializeField] private Button _endFightButton;

    [SerializeField] private Button _healButton;
    #endregion

    #region -Controllers-
    [Header("Controllers")]
    [SerializeField] private m_CharacterController _characterController;

    public m_CharacterController CharacterController { get => _characterController; private set => _characterController = value; }  

    [SerializeField] private EnemyController _enemyController;
    public EnemyController EnemyController { get => _enemyController; private set => _enemyController = value; }
    #endregion

    #region -IsFighting-
    public delegate void UpdateFight(bool isFighting);
    public event UpdateFight UpdateIsFighting;
    
    private bool _isFighting = false;
    public bool IsFighting 
    {
        get => _isFighting; 
        set
        {
            _isFighting = value;

            if (IsFighting)
            {
                _startFightButton.gameObject.SetActive(false);
                _endFightButton.gameObject.SetActive(true);
                _healButton.gameObject.SetActive(false);
            }
            else
            {
                _startFightButton.gameObject.SetActive(true);
                _endFightButton.gameObject.SetActive(false);
                _healButton.gameObject.SetActive(true);
            }

            UpdateIsFighting?.Invoke(_isFighting);
        } 
    }
    #endregion

    [SerializeField] private Image _background;

    private void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else if (s_Instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Initialize();
    }

    private void OnDestroy()
    {
        CharacterController.DeadHero -= EndFight;
    }

    private void Initialize()
    {
        _startFightButton.onClick.AddListener(StartFight);
        _endFightButton.onClick.AddListener(EndFight);

        _healButton.onClick.AddListener(HealCharacter);

        UpdatePosition(ResourceManager.s_Instance.MapData.Position);
        ResourceManager.s_Instance.MapData.UpdatePosition += UpdatePosition;

        CharacterController.DeadHero += EndFight;
    }

    private void UpdatePosition(Vector2 position)
    {
        _background.sprite = ResourceManager.s_Instance.Map[(int)position.x, (int)position.y].FightBackground;
    }

    private void StartFight()
    {
        if(CharacterController.HP != 0)
        {
            IsFighting = true;
        }
    }

    private void EndFight()
    {
        IsFighting = false;
    }

    private void HealCharacter()
    {
        CharacterController.HP = CharacterController.Characteristics.Health.Value;
    }
}
