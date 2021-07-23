namespace PocketWarriors
{
    public interface IIndicator<T>
    {
        T CurrentValue { get; set;}
        void InitializeIndicator();
        void UpdateIndicator(T updatedState, T maxState);
        void SetCurrentValue();
        void SetCurrentValue(T updatedValue);
    }
}
