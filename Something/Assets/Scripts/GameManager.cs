using BHSCamp;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action OnScoreChanged;
    [SerializeField] private LevelPreviewData[] _levels;
    private int _currentLevelIndex;
    public int Score 
    { 
        get { return _score; } 
    }
    private int _score;

    private void Awake()
    {
        if (Instance == null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SaveLoadSystem.Initialize(_levels);
        SaveLoadSystem.UnlockCompletedLevels();
    }

    public void AddScore(int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(
                $"Amount should be positive: {gameObject.name}"
                );
        _score += amount;
        OnScoreChanged?.Invoke();
        Debug.Log($"Score: {_score}");
    }

    public void FinishCurrentLevel()
    {
        SceneManager.LoadScene(0);
        OpenAccessToNextLevel();
    }

    public void OpenAccessToNextLevel()
    {
        if (_currentLevelIndex + 1 != _levels.Length)
            _levels[_currentLevelIndex + 1].IsAccessable = true;
    }

    public void SetLevelIndex(int newIndex)
    {
        _currentLevelIndex = newIndex;
    }
}
