using System;
using UnityEngine;

namespace StartGameJam.Scripts.QuestionsAndAnswers.Questions
{
    public class QuestionsSymbolsReplacer : ScriptableObject
    {
        [SerializeField] private InputFieldQuestionConfig[] configs;
        [SerializeField] private string findForSearch;
        [SerializeField] private string symbolForReplace;

        [ContextMenu("Invoke Replace")]
        [Obsolete("Obsolete")]
        private void Replace()
        {
            foreach (var config in configs)
            {
                //need make Formula public (dont forgot make it private again)
                // config.Formula = config.Formula.Replace(findForSearch, symbolForReplace);
                config.SetDirty();
            }
        }
    }
}