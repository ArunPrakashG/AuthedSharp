using AuthedSharp.Models.Parameters;
using AuthedSharp.Models.Responses.AppResponses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthedSharp {
	public class AuthedSharp {
		private readonly Requester Requester;
		private readonly ApplicationHandler App;
		private readonly UserHandler User;

		public AuthedSharp(HttpClientHandler _handler) {
			Requester = new Requester(_handler, null);
			App = new ApplicationHandler(Requester);
			User = new UserHandler(Requester);
		}

		public AuthedSharp(IWebProxy _proxy) {
			Requester = new Requester(null, _proxy);
			App = new ApplicationHandler(Requester);
			User = new UserHandler(Requester);
		}

		public AuthedSharp() {
			Requester = new Requester(null, null);
			App = new ApplicationHandler(Requester);
			User = new UserHandler(Requester);
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
