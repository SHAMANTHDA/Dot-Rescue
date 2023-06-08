using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mixpanel;

public class Player : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private AudioClip _moveClip, _loseClip;

    [SerializeField] private GamePlayManager _gm;
    [SerializeField] private GameObject _explosionPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rotateSpeed *= -1f;
            SoundManager.Instance.PlaySound(_moveClip);
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _rotateSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(_explosionPrefab, transform.GetChild(0).position, Quaternion.identity);
            SoundManager.Instance.PlaySound(_loseClip);

            var props = new Value();

            props["GAME_NAME"] = "Game Over";
            Mixpanel.Track("Game Over", props);

            Debug.Log("Game Over");

            _gm.GameEnded();
            Destroy(gameObject);
            return;
        }
    }
}
