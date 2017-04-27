using Xamarin.Forms;

namespace PinCerts
{
	public partial class PinCertsPage : ContentPage
	{
		PinCertsViewModel ViewModel => BindingContext as PinCertsViewModel;
		
		public PinCertsPage()
		{
			InitializeComponent();
		}
		
		protected override void OnAppearing()
		{
			base.OnAppearing();
			FetchData();
		}

		void LoadData(object sender, System.EventArgs e)
		{
			FetchData();
		}
		
		async void FetchData()
		{
			await ViewModel.FetchData().ConfigureAwait(false);
		}
	}
}