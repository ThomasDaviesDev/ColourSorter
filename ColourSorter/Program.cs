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
		static Sorters sort = new Sorters();
		
		//static Bitmap image = new Bitmap(ColourSorter.Properties.Resources.myTwitterPicture64);
		static Bitmap image = new Bitmap(ColourSorter.Properties.Resources.myTwitterPicture128);

		static int bubbleCount = 0;


		public static int Main()
		{
			Sorters.SortType s = Sorters.SortType.LightToDark;

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			sortPixels(image, s).Save(Directory.GetCurrentDirectory() + "newImage.png", ImageFormat.Png);			

			stopWatch.Stop();

			System.Console.WriteLine("Sort type : {0}", s.ToString());
			System.Console.WriteLine("Number of exchanges : {0}", sort.exchangeCount);
			System.Console.WriteLine("Time taken : {0}", ((float)stopWatch.ElapsedMilliseconds / 1000).ToString());
			System.Console.Read();

			return 0;
		}

		public static Bitmap sortPixels(Bitmap bmp, Sorters.SortType s)
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
			sort.colorBubbleSort(pixels, s);

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
		
		
	}
}
