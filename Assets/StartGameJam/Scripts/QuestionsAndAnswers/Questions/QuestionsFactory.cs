using System.Collections.Generic;
using StartGameJam.Scripts.Core;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace StartGameJam.Scripts.QuestionsAndAnswers.Questions
{
    public class QuestionsFactory : MonoBehaviour
    {
        [SerializeField] private QuestionsConfigsSet questionsConfigsSet;
        
        [Inject] private GameConfig _gameConfig;

        private readonly List<int> _blackList = new();

        public InputFieldQuestionConfig Create()
        {
            int randomIndex = 0;
            if (_gameConfig.QuestionsBlackListLenght >= questionsConfigsSet.Data.Count)
            {
                Debug.LogError("Black list have bigger size then count of questions");
                randomIndex = Random.Range(0, questionsConfigsSet.Data.Count);
            }
            else
            {
                var iterationsCounter = 0;
                while (true)
                {
                    iterationsCounter++;
                    
                    randomIndex = Random.Range(0, questionsConfigsSet.Data.Count);
                    if(!_blackList.Contains(randomIndex))
                    {
                        _blackList.Add(randomIndex);
                        break;
                    }
                    
                    if (iterationsCounter > 100)
                    {
                        Debug.LogError("Too much iterations");
                        randomIndex = Random.Range(0, questionsConfigsSet.Data.Count);
                        break;
                    }
                }
            }
            
            if(_blackList.Count > _gameConfig.QuestionsBlackListLenght)
                _blackList.RemoveAt(0);
            
            return questionsConfigsSet.Data[randomIndex];
        }
    }
}