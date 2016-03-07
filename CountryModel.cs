using System;
using System.Collections;
using System.Drawing;

namespace MVC_CountryFlags
{
	/// <summary>
	/// Summary description for CountryModel.
	/// </summary>
	public class CountryModel
	{
		private ArrayList countryList;
		private CountryController theController;

		public CountryModel(CountryController aController)
		{
            countryList = new ArrayList();
			theController = aController;
		}
        
        //Returning list of the country array
		public ArrayList CountryList
		{
			get
			{
                return countryList;
			}
		}

		/// <summary>method: AddCountry
		/// add Country flag to the model and update views
		/// </summary>
		/// <param name="aCountry"></param>
		public void AddCountry(AnyCountry aCountry)
		{
            countryList.Add(aCountry);
			UpdateViews();
		}

		/// <summary>method: UpdateCountry
		/// update views
		/// </summary>
		/// <param name="aCountry"></param>
		public void UpdateCountry(AnyCountry aCountry)
		{
			UpdateViews();			
		}

		/// <summary>method: DeleteCountry
		/// delete country and update views
		/// </summary>
		/// <param name="aCountry"></param>
		public void DeleteCountry(AnyCountry aCountry)
		{
            countryList.Remove(aCountry);
			UpdateViews();
		}

		/// <summary>method: SendToBack
		/// method to resequence arrayList so selected country is 
		/// drawn first
		/// </summary>
		/// <param name="aCountry"></param>
		public void SendToBack(AnyCountry aCountry)
		{
			// first country flag drawn is at the back			
			// temp arrayList to resort flag so selected flag is drawn first
			ArrayList sortList = new ArrayList();
			// find index of flag to be drawn first
            int max = countryList.IndexOf(aCountry);
			// first flag i.e. flag to send to back
			sortList.Add(aCountry); 
			// copy to sortList in correct sequence
			for (int i = 0; i < max; i++)
			{
                sortList.Add(countryList[i]);
			}

			// copy sortList back to countryList
			for (int i = 0; i < sortList.Count; i++)
			{
                countryList[i] = sortList[i];
			}
			UpdateViews();
		}

		/// <summary>method: BringToFront
		/// method to resequence arrayList so selected country flag is 
		/// drawn last
		/// </summary>
		/// <param name="aCountry"></param>
		public void BringToFront(AnyCountry aCountry)
		{
			// last country flag drawn is at the front			
			// temp arrayList to resort falg so selected flag is drawn last
            ArrayList sortList = new ArrayList(countryList);
			// find index of flag to be drawn last
            int max = countryList.IndexOf(aCountry);
			// find length of countryList array
            int length = countryList.Count;
			// copy countryList to sortList excluding selected country flag
			for (int i = max + 1; i < length; i++)
			{
                sortList[i - 1] = countryList[i];
			}
			// last country flag i.e. flag to bring to front
            sortList[length - 1] = countryList[max]; 
			// copy sortList back to countryList
			for (int i = 0; i < sortList.Count; i++)
			{
                countryList[i] = sortList[i];
			}
			UpdateViews();			
		}

		/// <summary>method: UpdateViews
		/// refresh all views
		/// </summary>
		public void UpdateViews()
		{
			theController.UpdateViews();
		}
	}
}
