using System;
using System.Net;
using System.Net.Http;

namespace AuthedSharp {
	public class Authed : IDisposable {
		private readonly Requester Requester;
		private readonly ApplicationHandler App;
		private readonly UserHandler User;

		/// <summary>
		/// ctor which allows to pass <see cref="HttpClientHandler"/> client handler.
		/// </summary>
		/// <param name="_handler">The <see cref="HttpClientHandler"/> from which the internal <see cref="HttpClient"/> must be derived from.</param>
		/// <param name="_persistentSession">Stores the application session for all followed up requests. <b>Not implemented yet.</b></param>
		public Authed(HttpClientHandler _handler, bool _persistentSession = false) {
			Requester = new Requester(_handler, null);
			App = new ApplicationHandler(Requester, _persistentSession);
			User = new UserHandler(Requester, _persistentSession);
		}

		/// <summary>
		/// ctor which allows to pass <see cref="IWebProxy"/> proxy to be used with all requests.
		/// </summary>
		/// <param name="_proxy">The <see cref="IWebProxy"/> to be used with all requests.</param>
		/// <param name="_persistentSession">Stores the application session for all followed up requests. <b>Not implemented yet.</b></param>
		public Authed(IWebProxy _proxy, bool _persistentSession = false) {
			Requester = new Requester(null, _proxy);
			App = new ApplicationHandler(Requester, _persistentSession);
			User = new UserHandler(Requester, _persistentSession);
		}

		/// <summary>
		/// The default ctor which uses default settings.
		/// </summary>
		/// <param name="_persistentSession">Stores the application session for all followed up requests. <b>Not implemented yet.</b></param>
		public Authed(bool _persistentSession = false) {
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

		/// <summary>
		/// Dispose internal requester.
		/// </summary>
		public void Dispose() => Requester.Dispose();
	}
}
