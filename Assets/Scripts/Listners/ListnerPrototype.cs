public abstract class ListnerPrototype
{
    // Properties
    public abstract ListnerContainer.ListnerType Type { get; }

    // Methods
    public abstract void OnClickListner(ButtonBehaviour buttonBehaviour);
}