using System.Threading.Tasks;
using MvvmHelpers;

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

		public async Task FetchData()
		{
			Data = "Loading...";
			
			// Artificial delay
			await Task.Delay(1000);
			Data = await _dataService.GetDataAsync();
		}
	}
}