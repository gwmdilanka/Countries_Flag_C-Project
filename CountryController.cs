using System;
using System.Collections;

namespace MVC_CountryFlags
{
	public interface ICountryView
	{
		void RefreshView();
	}
	/// <summary>
	/// Summary description for CountryController.
	/// </summary>
	public class CountryController
	{
		private ArrayList ViewList;

		// constructor
		public CountryController()
		{
			ViewList = new ArrayList();
		}
        
		/// <summary>method: AddView
		/// add view to viewlist
		/// </summary>
		/// <param name="aView"></param>
		public void AddView(ICountryView aView)
		{
			ViewList.Add(aView);
		}

		/// <summary>method: UpdateViews
		/// update each view 
		/// </summary>
		public void UpdateViews()
		{
            ICountryView[] theViews = (ICountryView[])ViewList.ToArray(typeof(ICountryView));
            foreach (ICountryView v in theViews)
			{
				v.RefreshView();
			}
		}
	}
}
