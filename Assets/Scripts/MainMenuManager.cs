using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using mixpanel;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _newBestText;
    [SerializeField] private TMP_Text _highscoreText;

    private void Awake()
    {

        _highscoreText.text = GameManager.Instance.highscore.ToString();

        if (!GameManager.Instance.IsInitialized)
        {
            _scoreText.gameObject.SetActive(false);
            _newBestText.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(ShowScore());
        }
    }

    [SerializeField] private float _animationTime;
    [SerializeField] private AnimationCurve _speedCurve;

    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        _scoreText.text = tempScore.ToString();

        int currentScore = GameManager.Instance.CurrentScore;
        int highscore = GameManager.Instance.highscore;

        if (highscore < currentScore)
        {
            _newBestText.gameObject.SetActive(true);
            GameManager.Instance.highscore = currentScore;
        }
        else
        {
            _newBestText.gameObject.SetActive(true);

            var props = new Value();

            props["GAME_SCORE"] = currentScore;
            Mixpanel.Track("GAME_SCORE", props);
            Debug.Log(currentScore);
        }

        _highscoreText.text = GameManager.Instance.highscore.ToString();
        float speed = 1 / _animationTime;
        float timeElapsed = 0f;

        while (timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;
            tempScore = (int)(_speedCurve.Evaluate(timeElapsed) * currentScore);
            _scoreText.text = tempScore.ToString();
            yield return null;
        }

        tempScore = currentScore;
        _scoreText.text = tempScore.ToString();

    }

    [SerializeField] private AudioClip _clickClip;

    public void ClickedPlay()
    {
        SoundManager.Instance.PlaySound(_clickClip);
        GameManager.Instance.GoToGamePlay();
    }
}
