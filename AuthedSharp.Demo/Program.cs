using AuthedSharp.Models.Parameters;
using AuthedSharp.Models.Responses.UserResponses;
using System;
using System.Threading.Tasks;

namespace AuthedSharp.Demo
{
	class Program
	{
		private static readonly Authed Auth = new Authed();
		private static string APP_ACCESS_TOKEN;
		private static string APP_ID;
		private static string ApplicationSession;
		private static string UserSession;

		static async Task Main(string[] args)
		{
			Console.WriteLine("Verifying application...");
			Console.WriteLine("Enter Application access token: ");
			APP_ACCESS_TOKEN = Console.ReadLine();
			Console.WriteLine("Enter Application ID: ");
			APP_ID = Console.ReadLine();

			var verifyResponse = await Auth.GetAppEndpoint().VerifyAsync(new VerifyRequest(APP_ID, APP_ACCESS_TOKEN));

			if(verifyResponse.ResponseCode != 200) {
				Console.WriteLine("ERROR: " + verifyResponse.Message);
				Console.ReadKey();
			}

			ApplicationSession = verifyResponse.Session;

			Console.WriteLine("Grand membership to user:");
			Console.WriteLine("Input user email: ");
			string userEmail = Console.ReadLine();
			Console.WriteLine("Input membership id to grant: ");
			string membershipCode = Console.ReadLine();

			var grantMembershipResponse = await Auth.GetUserEndpoint().GrandMembershipAsync(new GrandMembershipRequest(userEmail, membershipCode, ApplicationSession));

			if (grantMembershipResponse.ResponseCode != 200) {
				Console.WriteLine("ERROR: " + grantMembershipResponse.Message);
				Console.ReadKey();
			}

			Console.ReadKey();
		}
	}
}
