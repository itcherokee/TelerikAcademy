// Task 4: Create a class Path to hold a sequence of points in the 3D space. {...}

namespace Euclidian3DSpace
{
    using System.Collections.Generic;

    public class Path : List<Point3D>
    {
        // Due to the fact that in the task there is no specific requirement to implement all methods required
        // to sustein a specific Collection - just to create class limited to store points in 3D space, the most 
        // convenient way to automatically provide these features (Add, Clear, Remove, etc.), is to inherit already
        // existing collection class (in the case List<>) and limit it to be able to store only points in 3D.
        // Takeing into account that, it is enough just to inherit the List by limiting to accept only Points3D.
        // All other features (memebers) comes (have been implemented) from it.
        // The power of inheritance :)
    }
}
