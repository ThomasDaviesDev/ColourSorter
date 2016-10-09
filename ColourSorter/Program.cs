using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Resources;
using System.Diagnostics;
using System.Threading;

namespace ColourSorter
{
	class Program
	{
		
		//static Bitmap image = new Bitmap(ColourSorter.Properties.Resources.myTwitterPicture64);
		static Bitmap image = new Bitmap(ColourSorter.Properties.Resources.myTwitterPicture128);

		static int bubbleCount = 0;


		public static int Main()
		{
			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			sortPixels(image).Save(Directory.GetCurrentDirectory() + "newImage.png", ImageFormat.Png);

			stopWatch.Stop();

			System.Console.WriteLine("Number of bubble sorts performed : {0}", bubbleCount);
			System.Console.WriteLine("Time taken : {0}", ((float)stopWatch.ElapsedMilliseconds / 1000).ToString());
			System.Console.Read();

			return 0;
		}

		public static Bitmap sortPixels(Bitmap bmp)
		{
			int bmpWidth;
			int bmpHeight;
			Color[] pixels;
			//set width and height
			bmpWidth = bmp.Width;
			bmpHeight = bmp.Height;

			pixels = new Color[bmpWidth * bmpHeight];

			//get bmp colours and set them in pixels array
			for (int x = 0; x < bmpWidth; x++)
			{
				for (int y = 0; y < bmpHeight; y++)
				{
					pixels[(y * bmpWidth) + x] = image.GetPixel(x, y);

					//System.Console.WriteLine("x : {0}, y : {1}", x, y);
				}

			}

			//TODO: Array manipulation, "sort" pixels
			colorBubbleSort(pixels);

			Bitmap newBmp = new Bitmap(bmpWidth, bmpHeight);

			//get new bmp colours
			for (int x = 0; x < bmpWidth; x++)
			{
				for (int y = 0; y < bmpHeight; y++)
				{
					newBmp.SetPixel(x, y, pixels[(y * bmpWidth) + x]);
				}
			}
			
			return newBmp;
		}
		
		public static void colorBubbleSort(Color[] c)
		{
			int i, j;
			int length = c.Length;

			for(j = length - 1; j > 0; j--)
			{
				for(i = 0; i < j; i++)
				{
					//compare red components, if red of i > red of i + 1, swap them
					if(c[i].R > c[i + 1].R)
					{
						exchangeColor(c, i, i + 1);
					}
				}
			}
		}

		public static void exchangeColor (Color[] c, int m, int n)
		{
			//swaps elements in array
			Color temp;

			temp = c[m];
			c[m] = c[n];
			c[n] = temp;

			//System.Console.WriteLine("Running... Current color : {0}", temp.ToString());
			bubbleCount++;
		}
	}
}
