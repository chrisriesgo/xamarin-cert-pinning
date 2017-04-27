using System;
using System.Net;

namespace Lookup.PublicKeys
{
	class MainClass
	{
		const string SITE_URL = "https://www.random.org";
	
		public static void Main(string[] args)
		{
			Console.WriteLine($"Finding keys for {SITE_URL}...");
			var pk = GetPublicKey(new Uri(SITE_URL));

			if (string.IsNullOrWhiteSpace(pk))
			{
				Console.WriteLine("No public key found.");
			}
			else
			{
				Console.WriteLine("Public key found!");
				Console.WriteLine($"Public Key (string): \"{pk}\"");
			}
		}		       
        
        /// <summary>
        /// Gets the public key using ServicePointManager.
        ///	Not using this: openssl s_client -connect random.org:443 | openssl x509 -pubkey -noout
        /// </summary>
        /// <returns>The public key</returns>
        /// <param name="uri">Uri</param>
		public static string GetPublicKey(Uri uri)
		{
			var sp = ServicePointManager.FindServicePoint(uri);
			var groupName = Guid.NewGuid().ToString();

			var req = HttpWebRequest.Create(uri) as HttpWebRequest;
			req.ConnectionGroupName = groupName;

			using (var resp = req.GetResponse())
			{
			}

			sp.CloseConnectionGroup(groupName);
			var key = sp.Certificate.GetPublicKeyString();
			
			return key;
		}
	}
}
