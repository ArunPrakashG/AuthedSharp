using System.Net;
using System.Net.Http;

namespace AuthedSharp {
	public class AuthedSharp {
		private readonly Requester Requester;
		private readonly ApplicationHandler App;
		private readonly UserHandler User;

		public AuthedSharp(HttpClientHandler _handler, bool _persistentSession = false) {
			Requester = new Requester(_handler, null);
			App = new ApplicationHandler(Requester, _persistentSession);
			User = new UserHandler(Requester, _persistentSession);
		}

		public AuthedSharp(IWebProxy _proxy, bool _persistentSession = false) {
			Requester = new Requester(null, _proxy);
			App = new ApplicationHandler(Requester, _persistentSession);
			User = new UserHandler(Requester, _persistentSession);
		}

		public AuthedSharp(bool _persistentSession = false) {
			Requester = new Requester();
			App = new ApplicationHandler(Requester, _persistentSession);
			User = new UserHandler(Requester, _persistentSession);
		}

		/// <summary>
		/// Contains methods to all application related functions.
		/// </summary>
		/// <returns></returns>
		public ApplicationHandler GetAppEndpoint() => App;

		/// <summary>
		/// Contains methods related to all user related functions.
		/// </summary>
		/// <returns></returns>
		public UserHandler GetUserEndpoint() => User;
	}
}
