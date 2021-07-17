public interface IState<T>
{
    float CurrentState {get; }
    float MaxState {get; }
    IIndicator<T> Indicator {get; }
    void InitializeActions();
    void InitializeState();
    void UpdateState(T updatedState);
    void UpdateIndicator(T updatedValue);
}
