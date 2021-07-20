public interface IState<T>
{
    T CurrentState {get; }
    T MaxState {get; }
    IIndicator<T> Indicator {get; }
    void InitializeActions();
    void InitializeState();
    void UpdateState(T updatedState);
    void UpdateIndicator(T updatedValue);
}