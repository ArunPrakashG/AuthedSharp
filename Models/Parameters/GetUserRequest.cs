namespace AuthedSharp.Models.Parameters {
	public struct GetUserRequest {
		public readonly string ApplicationSession;
		public readonly string UserSession;

		/// <summary>
		/// Request used to get user information.
		/// </summary>
		/// <param name="_appSession">The application session.</param>
		/// <param name="_userSession">The user session.</param>
		public GetUserRequest(string _appSession, string _userSession) {
			ApplicationSession = _appSession;
			UserSession = _userSession;
		}
	}
}
