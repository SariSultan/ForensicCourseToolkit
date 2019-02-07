namespace ForensicsCourseToolkit.Filesystems
{
    public interface IHaveBootSectorParent
    {
        BootSector ParentBootSector { get; set; }
    }
}