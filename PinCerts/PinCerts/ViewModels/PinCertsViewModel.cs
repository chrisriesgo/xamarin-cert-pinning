using System.Threading.Tasks;
using MvvmHelpers;
using Xamarin.Forms;

namespace PinCerts
{
	public class PinCertsViewModel : BaseViewModel
	{
		DataService _dataService;

		string _data;
		public string Data
		{
			get { return _data;  }
			set { base.SetProperty<string> (ref _data, value, "Data", null); }
		}
		
		public PinCertsViewModel()
		{
			Title = "Cert Pinning";

			_dataService = new DataService();
		}

		public async Task FetchData(bool forceFailure = false)
		{
			Data = "Loading...";
			
			// Artificial delay
			await Task.Delay(1000);
			Data = forceFailure 
				? await _dataService.GetUnpinnedDataAsync() 
				: await _dataService.GetPinnedDataAsync();
		}
	}
}