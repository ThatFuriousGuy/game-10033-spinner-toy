// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    // TODO:
    // Make central circle middle of the screen (200, 200)

    // Make a ring around central circle. Maybe a bigger circle,
    // followed by a smaller white circle, still bigger than central circle,
    // then draw the main central circle

    // Have 1 circle draw on a random spot on the ring (I hate math)
    
    // Make a thin line that spins around the main circle on the ring, always pointing away (Ugh more math)

    // Upon hitting space, check of line is within the small circle on ring,
    // if so, make it spawn somewhere else on the ring, and grant one point to player

    // EXTRA:
    // If I can detect how close the line was to middle of circle, then I could have it grant point multipliers

    public class Game
    {
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(400, 400);
            Window.SetTitle("Spinner Toy");
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White);
        }
    }

}
