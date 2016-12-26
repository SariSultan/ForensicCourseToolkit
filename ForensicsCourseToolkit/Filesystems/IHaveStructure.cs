using System.Collections.Generic;

namespace ForensicsCourseToolkit.Filesystems
{
    public interface IHaveStructure
    {
        List<StructureUnit> Structure { get; set; }
    }
}