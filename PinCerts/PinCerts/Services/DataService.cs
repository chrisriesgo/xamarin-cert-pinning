using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PinCerts
{
	public class DataService
	{
		const string SERVICE_BASE_URL = "https://www.random.org";
		const string SERVICE_RELATIVE_URL = "/integers/?num=16&min=0&max=255&col=16&base=10&format=plain&rnd=new";

		const string FAILING_SERVICE_BASE_URL = "https://demo0998860.mockable.io";
		const string FAILING_SERVICE_RELATIVE_URL = "/fluffs";
		
		public Task<string> GetPinnedDataAsync()
		{
			return GetDataAsync(SERVICE_BASE_URL, SERVICE_RELATIVE_URL);
		}

		public Task<string> GetUnpinnedDataAsync()
		{
			return GetDataAsync(FAILING_SERVICE_BASE_URL, FAILING_SERVICE_RELATIVE_URL);
		}
		
		async Task<string> GetDataAsync(string baseUrl, string relUrl)
		{			
			var uri = new Uri(relUrl, UriKind.Relative);
	        var request = new HttpRequestMessage
	        {
	            Method = HttpMethod.Get,
	            RequestUri = uri
	        };
	        
			var client = GetHttpClient(baseUrl);

			HttpResponseMessage response = null;

			try
			{
				response = await client.GetAsync(request.RequestUri, HttpCompletionOption.ResponseHeadersRead);
			}
			catch (Exception ex)
			{
				return ex.InnerException.Message;
			}

			var content = await response.Content.ReadAsStringAsync();
			
			return content;
		}
		
		HttpClient GetHttpClient(string baseUrl)
        {
			var handler = new HttpClientHandler
			{
				UseProxy = true,
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
			};

			var client = new HttpClient(handler) {
				BaseAddress = new Uri(baseUrl)
			};

            client.DefaultRequestHeaders.Connection.Add("keep-alive");
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

            return client;
        }
	}
}