using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ColourSorter
{
	class Sorters
	{
		ColorProperties cp = new ColorProperties();

		public int exchangeCount = 0;
		
		public enum SortType
		{
			DarkToLight,
			LightToDark,
			RedFirst,
			BlueFirst,
			GreenFirst,
			HighestHueFirst,
			HighestSaturationFirst
		};

		//bubble sort
		public void colorBubbleSort(Color[] c, SortType s)
		{
			int i, j;
			int length = c.Length;

			for (j = length - 1; j > 0; j--)
			{
				for (i = 0; i < j; i++)
				{
					/*//compare red components, if red of i > red of i + 1, swap them
					if (c[i].R > c[i + 1].R)
					{
						exchangeColor(c, i, i + 1);
					}*/

					//need some way of "selecting" different sort types
					//switch statement? not the best, but will work
					switch (s)
					{
						case SortType.DarkToLight:
							if(isLighter(c[i], c[i + 1]))
							{
								exchangeColor(c, i, i + 1);
							}
							break;
						case SortType.LightToDark:
							if(isDarker(c[i], c[i + 1]))
							{
								exchangeColor(c, i, i + 1);
							}
							break;
						case SortType.RedFirst:
							if(isRedder(c[i], c[i + 1]))
							{
								exchangeColor(c, i, i + 1);
							}
							break;
						case SortType.BlueFirst:
							if(isBluer(c[i], c[i + 1]))
							{
								exchangeColor(c, i, i + 1);
							}
							break;
						case SortType.GreenFirst:
							if(isGreener(c[i], c[i + 1]))
							{
								exchangeColor(c, i, i + 1);
							}
							break;
						case SortType.HighestHueFirst:
							if(hasHigherHue(c[i], c[i + 1]))
							{
								exchangeColor(c, i, i + 1);
							}
							break;
						case SortType.HighestSaturationFirst:
							if (hasHigherSaturation(c[i], c[i + 1]))
							{
								exchangeColor(c, i, i + 1);
							}
							break;
						default:
							break;
					}

					/*if(isBluer(c[i], c[i+1]))
					{
						if (isGreener(c[i], c[i + 1]))
						{
							if (isRedder(c[i], c[i + 1]))
							{
								exchangeColor(c, i, i + 1);
							}
						}
					}*/


				}
			}
		}

		public bool hasHigherHue(Color c1, Color c2)
		{
			if (cp.hue(c1) > cp.hue(c2))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool hasHigherSaturation(Color c1, Color c2)
		{
			if (cp.saturation(c1) > cp.saturation(c2))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool isLighter(Color c1, Color c2)
		{
			//if (calculateLightness(c1) > calculateLightness(c2))
			if(cp.brightness(c1)> cp.brightness(c2))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool isDarker(Color c1, Color c2)
		{
			//if (calculateLightness(c1) < calculateLightness(c2))
			if (cp.brightness(c1) < cp.brightness(c2))
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		public bool isRedder(Color c1, Color c2)
		{
			if(c1.R > c2.R)
			{
				return true;
			}
			else
			{
				return false;
			}		
		}

		public bool isBluer(Color c1, Color c2)
		{
			if (c1.B > c2.B)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool isGreener(Color c1, Color c2)
		{
			if (c1.G > c2.G)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public int calculateLightness(Color c)
		{
			//bigger the number, lighter the colour
			//sum of RGB values, 255+255+255 is white, 0+0+0 is black
			int lightness = c.R + c.G + c.B;

			return lightness;
		}



		public void exchangeColor(Color[] c, int m, int n)
		{
			//swaps elements in array
			Color temp;

			temp = c[m];
			c[m] = c[n];
			c[n] = temp;

			//System.Console.WriteLine("Running... Current color : {0}", temp.ToString());
			exchangeCount++;
		}








	}
}
