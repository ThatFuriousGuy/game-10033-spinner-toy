using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Text;

namespace sandhu_harsimer_spinner_toy.Objects
{
    public class Orb
    {
        float positionx = 0f;
        float positiony = 0f;
        float distance_from_spinner = 0f;
        float spinner_x = 0f;
        float spinner_y = 0f;
        float angle = 0f;
        float orb_radius = 20f;

        // once the orb is hit, the next orb spawns randomly around the spinner
        // the orb should be within the outer ring
        public void Setup(float centerx, float centery, float ring_distance)
        {

        }
        public void Update()
        {

        }
        public void draw_self()
        {

        }
        // Gets called once the user times the knob on top of the orb
        public void hit(float knob_angle)
        {

        }

        // Checks how well the knob lines up with the orb
        // 0 = miss, 1 = hit
        public bool check_hit(float knob_angle)
        {
            return false;
        }
        // Gets called to reposition itself somewhere again
        public void reposition(float knob_angle)
        {

        }
    }
}
