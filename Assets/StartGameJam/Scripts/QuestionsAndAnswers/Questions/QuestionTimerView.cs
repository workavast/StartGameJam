using Avastrad.UI.Elements.BarView;
using TMPro;
using UnityEngine;

namespace StartGameJam.Scripts.QuestionsAndAnswers.Questions
{
    [RequireComponent(typeof(Bar))]
    public class QuestionTimerView : MonoBehaviour
    {
        [SerializeField] private QuestionViewWithInputField questionViewWithInputField;
        [SerializeField] private TMP_Text timerText;
        
        private Bar _bar;

        private void Awake()
        {
            _bar = GetComponent<Bar>();

            questionViewWithInputField.AnswerTimer.OnChange += UpdateBar;
        }

        private void UpdateBar()
        {
            _bar.SetValue(1 - questionViewWithInputField.AnswerTimer.CurrentTime / questionViewWithInputField.AnswerTimer.MaxTime);
            var curTime = questionViewWithInputField.AnswerTimer.MaxTime -
                           questionViewWithInputField.AnswerTimer.CurrentTime;
            timerText.text = Mathf.Ceil(curTime).ToString();
        }
    }
}