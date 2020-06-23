namespace AuthedSharp.Models.Parameters {
	public struct RenewUserSessionRequest {
		public readonly string ApplicationSession;
		public readonly string UserSession;

		/// <summary>
		/// Request to renew a user session.
		/// </summary>
		/// <param name="_appSession">The application session.</param>
		/// <param name="_userSession">The current user session.</param>
		public RenewUserSessionRequest(string _appSession, string _userSession) {
			ApplicationSession = _appSession;
			UserSession = _userSession;
		}
	}
}
