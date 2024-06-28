using UnityEngine;
using Zenject;

namespace StartGameJam.Scripts.QuestionsAndAnswers
{
    public class QuestionsAndAnswersInstaller : MonoInstaller
    {
        [SerializeField] private QuestionWindow questionWindow;
        
        public override void InstallBindings()
        {
            BindQuestionAnswering();
        }

        private void BindQuestionAnswering()
        {
            Container.BindInterfacesAndSelfTo<QuestionAnswering>().FromNew().AsSingle().WithArguments(questionWindow).NonLazy();
        }
    }
}