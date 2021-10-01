using Exiled.API.Enums;

namespace LightControl
{
    public class RoomSettings
    {
        public RoomType Room { get; set; }
        public Colors Color { get; set; }

        public void Deconstruct(out RoomType type, out Colors color)
        {
            type = Room;
            color = Color;
        }
    }

    public class ZoneSettings
    {
        public ZoneType Zone { get; set; }
        public Colors Color { get; set; }

        public void Deconstruct(out ZoneType type, out Colors color)
        {
            type = Zone;
            color = Color;
        }
    }

    public class Colors
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }
        public float Alpha { get; set; }

        public void Deconstruct(out float red, out float green, out float blue, out float alpha)
        {
            red = Red;
            green = Green;
            blue = Blue;
            alpha = Alpha;
        }
    }
}
