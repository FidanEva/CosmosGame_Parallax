using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    [SerializeField] private float _speed = 1;
    private Transform _transform;
    private bool _isDead = false;
    private float _deadTime;

     public Text _scoreText;
    [SerializeField] private int _score = 0;
    [SerializeField] private GameObject _gameOver;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _transform.position += new Vector3(_horizontal, 0.5f, 0) * _speed * Time.deltaTime;
        //_transform.position += Vector3.up * _speed * Time.deltaTime;
        if(_transform.position.x < -1.4f || _transform.position.x > 1.3f)
        {
            Die();
        }
        if (_isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Invoke("Restart", 3);
        }
    }
    
    public void Die()
    {
        // _deadTime = Time.realtimeSinceStartup;
        // Debug.Log(_deadTime);
        //_isDead = true;
        Time.timeScale = 0;
        _gameOver.SetActive(true);
        //Invoke("Restart", 3);
    }

    public void Restart()
    {
        _gameOver.SetActive(false);
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.transform.CompareTag("Obstacle"))
        {
            Debug.Log("Collided");
            Die();
        }
    }
      void OnTriggerEnter2D(Collider2D coll) 
    {
        if (coll.gameObject.CompareTag("Collectable"))
        {
           _score++;
           _scoreText.text = "x" + _score.ToString();
        }
    }
}
