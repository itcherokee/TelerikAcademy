using BalkanSuperHero.Enumerations;
using BalkanSuperHero.Structs;

namespace BalkanSuperHero.Interfaces
{
    public interface IMovable
    {
        /// <summary>
        /// Gets or sets the velocity of sprite animation.
        /// </summary>
        PointF Velocity { get; set; }

        /// <summary>
        /// Get or sets the number of columns in current sprite.
        /// </summary>
        int SpriteColumns { get; set; }

        /// <summary>
        /// Gets or sets the total number of the frames per sprite.
        /// </summary>
        int TotalFrames { get; set; }

        /// <summary>
        /// Gets or sets the current frame of the sprite movement.
        /// </summary>
        int CurrentFrame { get; set; }

        /// <summary>
        /// Gets or sets the direction of next sprite frame to be drawn.
        /// </summary>
        SpriteDirection Direction { get; set; }

        /// <summary>
        /// Gets or sets the frame rate.
        /// </summary>
        int AnimationRate { get; set; }

        /// <summary>
        /// Handles the animation of the sprite.
        /// </summary>
        void Animate();

        void UpdatePosition(PointF velocity);

        void Update();
    }
}
