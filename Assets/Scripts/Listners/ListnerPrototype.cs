public abstract class ListnerPrototype
{
    protected readonly ListnerContainer.ListnerType type;

    public abstract ListnerContainer.ListnerType Type { get; set;}

    public abstract void OnClickListner(ButtonListner buttonListner);
}