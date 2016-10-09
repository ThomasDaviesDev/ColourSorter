using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ColourSorter
{
	class ColorProperties
	{
		public float hue(Color c)
		{
			float h = c.GetHue();
			return h;
		}

		public float saturation(Color c)
		{
			float s = c.GetSaturation();
			return s;
		}

		public float brightness(Color c)
		{
			float b = c.GetBrightness();
			return b;
		}
	}
}
