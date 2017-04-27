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

		public async Task<string> GetDataAsync()
		{			
			var uri = new Uri(SERVICE_RELATIVE_URL, UriKind.Relative);
	        var request = new HttpRequestMessage
	        {
	            Method = HttpMethod.Get,
	            RequestUri = uri
	        };
	        
			var client = GetHttpClient();

			HttpResponseMessage response = null;

			response = await client.GetAsync(request.RequestUri, HttpCompletionOption.ResponseHeadersRead);

			var content = await response.Content.ReadAsStringAsync();
			
			return content;
		}
		
		HttpClient GetHttpClient()
        {
			var handler = new HttpClientHandler
			{
				UseProxy = true,
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
			};

			var client = new HttpClient(handler) {
				BaseAddress = new Uri(SERVICE_BASE_URL)
			};

            client.DefaultRequestHeaders.Connection.Add("keep-alive");
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

            return client;
        }
	}
}