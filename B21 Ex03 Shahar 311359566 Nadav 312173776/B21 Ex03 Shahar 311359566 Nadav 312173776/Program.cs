using System;

namespace B21_Ex03_Shahar_311359566_Nadav_312173776
{
   public class Program
    {
        public static void Main(string[] args)
        {
            bool active = true;

            while (active)
            {
                active = UI.PreformUserAction();
            }
        }
    }
}
