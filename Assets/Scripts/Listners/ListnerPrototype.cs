public abstract class ListnerPrototype
{
    // Fields
    protected readonly ListnerContainer.ListnerType type;

    // Properties
    public abstract ListnerContainer.ListnerType Type { get; set;}

    // Methods
    public abstract void OnClickListner(ButtonListner buttonListner);
}