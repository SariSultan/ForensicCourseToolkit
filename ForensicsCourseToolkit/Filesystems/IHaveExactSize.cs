namespace ForensicsCourseToolkit.Filesystems
{
    public interface IHaveExactSize
    {
        int GetExpectedSize();
    }

    public interface IHaveBootSectorParent
    {
       BootSector ParentBootSector { get; set; }
    }
}