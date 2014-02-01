using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrailObject> trail = new List<TrailObject>();
            TrailObject trailItem = new TrailObject(base.topLeft, 3);
            trail.Add(trailItem);
            return trail;
        }
    }
}
