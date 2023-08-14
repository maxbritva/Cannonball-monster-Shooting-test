using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player.Ball
{
    public class BallPool : MonoBehaviour
    {
        [SerializeField] private GameObject _ballPrefab;
        [SerializeField] private List<GameObject> _poolBall = new List<GameObject>();
        private readonly int _startCount;
       

        private void Start() => InitPool();

        public void GetBallFromPool()
        {
            
        }

        private void InitPool()
        {
            for (int i = 0; i < _startCount; i ++)
                CreateBall();
            
        }

        private GameObject CreateBall()
        {
            GameObject newBall = Instantiate(_ballPrefab, transform);
            newBall.gameObject.SetActive(false);
            _poolBall.Add(newBall);
            return newBall;
        }

    }
}