namespace StartGameJam.Scripts.ScenesLoading
{
    public interface ISceneLoader
    {
        public int LoadingSceneIndex { get; }
        
        public void Initialize(bool endLoadingInstantly);
        public void LoadScene(int index);
    }
}