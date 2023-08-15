using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Player.Ball
{
    public class BallPool : MonoBehaviour
    {
        [SerializeField] private GameObject _ballPrefab;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private List<GameObject> _poolBall = new List<GameObject>();
        [Inject] private DiContainer _diContainer;
        private const int StartCount = 5;

        private void Start() => InitPool();

        public GameObject GetBallFromPool()
        {
            for (int i = 0; i < _poolBall.Count; i++) 
            {
                if (_poolBall[i].gameObject.activeInHierarchy == false)
                {
                    _poolBall[i].gameObject.transform.position = _shootPoint.position;
                    _poolBall[i].gameObject.transform.rotation = _shootPoint.rotation;
                    _poolBall[i].gameObject.SetActive(true);
                    return _poolBall[i]; 
                }
            }
            GameObject ball = CreateBall();
            ball.gameObject.SetActive(true);
            return ball; 
        }
        

        private void InitPool()
        {
            for (int i = 0; i < StartCount; i ++)
                CreateBall();
        }

        private GameObject CreateBall()
        {
            GameObject newBall = _diContainer.InstantiatePrefab(_ballPrefab, _shootPoint.position, _shootPoint.rotation,transform);
            newBall.gameObject.SetActive(false);
            _poolBall.Add(newBall);
            return newBall;
        }

    }
}