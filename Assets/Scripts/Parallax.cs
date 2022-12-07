using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // private Transform _cameraTransform;
    // private Vector3 _cameraLatPosition;
    // [SerializeField] private Vector2 _parallaxMultiplier;
    // private float _textureUnitSizeY;

    // void Start()
    // {
    //     _cameraTransform = Camera.main.transform;
    //     _cameraLatPosition = _cameraTransform.position;

    //     Sprite sprite = GetComponent<SpriteRenderer>().sprite;
    //     Texture2D texture = sprite.texture;
    //     //textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    //     _textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    // }

    // void LateUpdate()
    // {
    //     Vector3 deltaMovement = _cameraTransform.position - _cameraLatPosition;
    //     transform.position += new Vector3(deltaMovement.x * _parallaxMultiplier.x, deltaMovement.y * _parallaxMultiplier.y);
    //     _cameraLatPosition = _cameraTransform.position;
    //     Debug.Log($"Textureunit{_textureUnitSizeY}");
    //     Debug.Log(_cameraTransform.position.y - transform.position.y);
    //     if (Mathf.Abs(_cameraTransform.position.y - transform.position.y) >= _textureUnitSizeY) {
    //         float offsetPositionY = (_cameraTransform.position.y - transform.position.y) % _textureUnitSizeY;
    //         transform.position = new Vector3(transform.position.x, _cameraTransform.position.y + offsetPositionY);
    //     }
    // }

    private float _length, _startPos;
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _parallaxEffect;

    void Start()
    {
        _startPos = transform.position.y;
        _length = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    void FixedUpdate()
    {
        float distance = _camera.transform.position.y * _parallaxEffect;
        float temp = _camera.transform.position.y * (1 - _parallaxEffect);
        transform.position = new Vector3(transform.position.x, _startPos + distance, transform.position.z);
        
        if (temp > _startPos + _length)
        {
            _startPos += _length;
        }
        else if (temp < _startPos - _length)
        {
            _startPos -= _length;
        }
    }
}
