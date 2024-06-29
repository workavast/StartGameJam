using System.Collections.Generic;
using System.Linq;
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

        public InputFieldQuestionConfig Create(int currentDifficulty = 10)
        {
            var possibleQuestions = questionsConfigsSet.Data.ToList();
            for (int i = 0; i < possibleQuestions.Count; i++)
            {
                if(currentDifficulty < possibleQuestions[i].MinDifficulty || possibleQuestions[i].MaxDifficulty < currentDifficulty)
                    possibleQuestions.RemoveAt(i--);
            }
            
            int randomIndex = 0;
            if (_gameConfig.QuestionsBlackListLenght >= possibleQuestions.Count)
            {
                Debug.LogError("Black list have bigger size then count of possible questions");
                randomIndex = Random.Range(0, questionsConfigsSet.Data.Count);
                return questionsConfigsSet.Data[randomIndex];
            }
            else
            {
                var iterationsCounter = 0;
                while (true)
                {
                    iterationsCounter++;
                    
                    randomIndex = Random.Range(0, possibleQuestions.Count);
                    if(!_blackList.Contains(randomIndex))
                    {
                        _blackList.Add(randomIndex);
                        break;
                    }
                    
                    if (iterationsCounter > 100)
                    {
                        Debug.LogError("Too much iterations");
                        randomIndex = Random.Range(0, possibleQuestions.Count);
                        break;
                    }
                }
            }
            
            if(_blackList.Count > _gameConfig.QuestionsBlackListLenght)
                _blackList.RemoveAt(0);
            
            return possibleQuestions[randomIndex];
        }
    }
}