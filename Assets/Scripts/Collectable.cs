using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private float _rotateSpeed = 10;
    //public Transform _scoreIcon;
    [SerializeField]
    private GameObject _coinIocn;

    void Start()
    {
        _transform = GetComponent<Transform>();
        
    }
    void Update()
    {
        _transform.Rotate( Vector3.forward * _rotateSpeed * Time.deltaTime);
        _coinIocn = GameObject.FindGameObjectWithTag("Icon");
    }
    void OnTriggerEnter2D(Collider2D coll) 
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            //coll.transform.tag = "Collected";
            var seq = DOTween.Sequence();

            seq.Append(transform.DOScale(0.28f, 0.1f)).Insert(0.1f, transform.DOScale(0, 0.2f)).Insert(0.2f,_coinIocn.transform.DOScale(1.7f, 0.1f)).Insert(0.3f, _coinIocn.transform.DOScale(1, 0.2f));

           
            //seq.Append(transform.DOMove(new Vector3(_scoreIcon.transform.position.x, _scoreIcon.transform.position.y, -1f), 1f));
            
            // transform.SetParent(_scoreIcon);
            // seq.Append(transform.DOLocalJump(new Vector3(_scoreIcon.transform.position.x, _scoreIcon.transform.position.y, transform.position.z),1,1, 2f));
            // Destroy(gameObject, 1f);

            // OnComplete(()=>{
            //     Destroy(gameObject);
            //     Debug.Log("oncomplete");
            //     var seqIcon = DOTween.Sequence();
            //     seqIcon.Append(_coinIocn.transform.DOScale(1.5f, 1)).Insert(1, _coinIocn.transform.DOScale(1f, 1)) ;
            // });
        }
    }
}
