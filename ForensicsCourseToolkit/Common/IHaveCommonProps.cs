using ForensicsCourseToolkit.Helpers;

namespace ForensicsCourseToolkit.Filesystems
{
    public interface IHaveCommonProps
    {
        Logger Logger { get; set; }
        string RawValue { get; set; }
        int Size { get;  }

        string Description { get; set; }
        
    }
}