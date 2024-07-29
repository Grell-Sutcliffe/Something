using BHSCamp;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChooser : MonoBehaviour
{
    [Header("Levels Data")]
    [SerializeField] private LevelPreviewData[] _levels;

    [Header("UI fields")]
    [SerializeField] private TextMeshProUGUI _levelName;
    [SerializeField] private Button _playButton;
    [SerializeField] private Image _preview;
    [SerializeField] private Image _lock;
    [SerializeField] private TMP_Text _highscoreText;

    private int _currentLevelIndex;

    private void OnEnable()
    {
        ShowLevel(_currentLevelIndex);
    }

    private void Awake()
    {
        _playButton.onClick.AddListener(LoadChosenLevel);
    }

    private void ShowLevel(int index)
    {
        LevelPreviewData level = _levels[index];
        _preview.sprite = level.Preview;
        _levelName.text = level.Name;
        //_playButton.gameObject.SetActive(level.IsAccessable);
        _lock.enabled = false == level.IsAccessable;

        int collectedCoins = SaveLoadSystem.LoadHighscore(index);
        _highscoreText.text = $"{collectedCoins}/{_levels[index].CoinsAmount}";
    }

    public void ShowNextLevel()
    {
        ShowLevel(_currentLevelIndex = (_currentLevelIndex + 1) % _levels.Length);
    }

    public void ShowPrevLevel()
    {
        ShowLevel(_currentLevelIndex = (_currentLevelIndex - 1 + _levels.Length) % _levels.Length);
    }

    private void LoadChosenLevel()
    {
        SceneManager.LoadScene(_levels[_currentLevelIndex].SceneIndex);
        GameManager.Instance.SetLevelIndex(_currentLevelIndex);
    }
}
