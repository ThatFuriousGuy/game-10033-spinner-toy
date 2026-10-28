// Include the namespaces (code libraries) you need below.
using sandhu_harsimer_spinner_toy.Objects;
using System;
using System.Diagnostics;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    // TODO:
    // Make central circle middle of the screen (400, 300) --DONE--

    // Make a ring around central circle. Maybe a bigger circle, --DONE--
    // followed by a smaller white circle, still bigger than central circle, --DONE--
    // then draw the main central circle --DONE--

    // Have 1 circle draw on a random spot on the ring (I hate math)

    // Make a thin line that spins around the main circle on the ring, always pointing away (Ugh more math) --DONE--

    // Upon hitting space, check of line is within the small circle on ring,
    // if so, make it spawn somewhere else on the ring, and grant one point to player


    public class Game
    {
        // Reference to the spinner itself
        Spinner spinner = new Spinner();
        // Reference to the orb that spawns on the outer ring
        Orb orb = new Orb();
        // Gonna use this to potentially affect difficulty at higher scores
        int score = 0;
        // Acts as an input buffer holder
        int buffer = 0;
        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("Spinner Toy");
            spinner.Setup();

            Vector2 center = spinner.get_center();
            orb.Setup(center.X, center.Y, spinner.get_ring_middle());
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White);

            spinner.Update();
            orb.Update();
            spinner.draw_knob();

            handle_input();
        }
        void handle_input()
        {
            if (Input.IsKeyboardKeyPressed(KeyboardKey.Space))
            {
                buffer += 10;
            }
            if (buffer > 0)
            {
                bool is_hit = orb.check_hit(spinner.get_angle());
                if (is_hit)
                {
                    score += 1;
                    orb.hit(spinner.get_angle());
                    spinner.on_hit();
                    buffer = 0;
                }
                if (buffer == 1)
                {
                    spinner.change_knob_speed(-0.2f, true);
                    score = 0;
                    spinner.hit_missed();
                }
                buffer -= 1;

            }
        }
    }

}
