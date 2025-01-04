namespace Chapter6
{
    public class StateContainer
    {
        public string Property { get; set; }
        public event Action OnChange;

        public void SetProperty(string value)
        {
            Property = value;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }

}



