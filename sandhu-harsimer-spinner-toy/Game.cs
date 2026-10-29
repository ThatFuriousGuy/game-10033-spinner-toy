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

    // Have 1 circle draw on a random spot on the ring (I hate math) --DONE--

    // Make a thin line that spins around the main circle on the ring, always pointing away (Ugh more math) --DONE--

    // Upon hitting space, check of line is within the small circle on ring, --DONE--
    // if so, make it spawn somewhere else on the ring, and grant one point to player --DONE--


    public class Game
    {
        // Reference to the spinner itself
        Spinner spinner = new Spinner();
        // Reference to the orb that spawns on the outer ring
        Orb orb = new Orb();
        // Gonna use this to potentially affect difficulty at higher scores
        int max_score = 0;
        int score = 0;
        // Acts as an input buffer holder
        int buffer = 0;
        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.SetTitle("Spinner Toy");
            // Calling setup so the main spinner can setup its own logic, and setup logic for the knob
            spinner.Setup();

            Vector2 center = spinner.get_center();
            // The orb has to know where the main spinner is, so it can position itself around it correctly
            orb.Setup(center.X, center.Y, spinner.get_ring_middle());
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White);

            spinner.Update();
            draw_score();
            orb.Update();
            spinner.draw_knob();

            handle_input();
        }
        // All this does is to display both current score and max score of the session
        // using text width (.Length) in the math so the text stays mostly centered no matter what
        void draw_score()
        {
            string score_text = $"Score: {score}";
            string max_text = $"Max Score: {max_score}";
            int size = 30;
            float text_width = score_text.Length * size * 0.6f;
            float text_width2 = max_text.Length * size * 0.6f;

            float x = 400 - text_width / 2;
            float y = 275 - size / 2;
            float x2 = 405 - text_width2 / 2;
            float y2 = 300 - size / 2;

            Text.Color = Color.Black;
            Text.Size = size;
            Text.Draw(score_text, x, y);
            Text.Draw(max_text, x2, y2);
        }
        void handle_input()
        {
            // When pressing space, it puts the buffer on the timer
            // While its above 0, it acts as if you pressed it during those frames
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
                    if (max_score <= score)
                    {
                        max_score = score;
                    }
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
