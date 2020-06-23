namespace AuthedSharp.Models.Parameters {
	public struct LoginRequest {
		public readonly string Email;
		public readonly string Password;
		public readonly string ApplicationSession;

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="_email">The email address.</param>
		/// <param name="_password">The password.</param>
		/// <param name="_appSession">The application session.</param>
		public LoginRequest(string _email, string _password, string _appSession) {
			Email = _email;
			Password = _password;
			ApplicationSession = _appSession;
		}
	}
}
