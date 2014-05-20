namespace ConditionCode
{
    using System;

    public class Condition
    {
        private const int MinX = 0;
        private const int MaxX = 100;
        private const int MinY = 0;
        private const int MaxY = 100;
        private const bool ShouldVisitCell = true;

        public void Some(int coordinateX, int coordinateY)
        {
            bool isInRangeByHorizontal = MinX <= coordinateX && coordinateX <= MaxX;
            bool isInRangeByVertical = MinY <= coordinateY && coordinateY <= MaxY;
            if (isInRangeByHorizontal && isInRangeByVertical && ShouldVisitCell)
            {
                this.VisitCell();
            }
        }

        private void VisitCell()
        {
            // ...
        }
    }
}
