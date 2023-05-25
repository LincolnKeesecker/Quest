using System;
using System.Collections.Generic;

namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }
        public string ShininessDescription { get; set; }

        public Hat(int shiny)
        {
            string status = "";
            if (ShininessLevel < 2)
            {
                status = "dull";
            }
            else if (ShininessLevel >= 2 && ShininessLevel <= 5)
            {
                status = "noticeable";
            }
            else if (ShininessLevel >= 6 && ShininessLevel <= 59)
            {
                status = "bright";
            }
            else
            {
                status = "blinding";
            }

            this.ShininessDescription = status;
        }
    }
}