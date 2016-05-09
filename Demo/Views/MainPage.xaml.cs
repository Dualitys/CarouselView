﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace Demo
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

			Title = "Page Slider";

			myCarousel.ItemsSource = new List<int> { 1, 2, 3, 4, 5 };
			myCarousel.ItemTemplate = new MyTemplateSelector (); //new DataTemplate (typeof(MyView));
			myCarousel.Position = 1;
			myCarousel.PositionSelected += PositionSelected;

			MessagingCenter.Subscribe<string> ("Carousel", "RemoveView", (sender) => {

				myCarousel.RemovePage(myCarousel.Position);

			});

			prevBtn.IsVisible = myCarousel.Position > 0;
			addPageBtn.IsVisible = myCarousel.Position == myCarousel.ItemsSource.Count - 1;
			nextBtn.IsVisible = myCarousel.Position < myCarousel.ItemsSource.Count - 1;
		}

		public void PositionSelected (object sender, EventArgs e)
		{			
			prevBtn.IsVisible = myCarousel.Position > 0;
			addPageBtn.IsVisible = myCarousel.Position == myCarousel.ItemsSource.Count - 1;
			nextBtn.IsVisible = myCarousel.Position < myCarousel.ItemsSource.Count - 1;
			Debug.WriteLine ("Position selected");
		}

		public void OnPrev (object sender, TappedEventArgs e)
		{
			if (myCarousel.Position > 0)
				myCarousel.SetCurrentPage (myCarousel.Position - 1);
		}

		public void OnAdd (object sender, TappedEventArgs e)
		{
			myCarousel.AddPage (myCarousel.ItemsSource.Count + 1);
		}

		public void OnNext (object sender, TappedEventArgs e)
		{
			if (myCarousel.Position < myCarousel.ItemsSource.Count - 1)
				myCarousel.SetCurrentPage (myCarousel.Position + 1);
		}
	}
}
