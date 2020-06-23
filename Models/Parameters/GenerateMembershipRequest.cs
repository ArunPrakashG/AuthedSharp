namespace AuthedSharp.Models.Parameters {
	public struct GenerateMembershipRequest {
		public readonly string AppSecret;
		public readonly string Name;
		public readonly int Time;
		public readonly int Level;
		public readonly string ApplicationSession;

		/// <summary>
		/// Request used to generate a membership.
		/// </summary>
		/// <param name="_appSecret">The application secret.</param>
		/// <param name="_name">The name of the membership.</param>
		/// <param name="_level">The level of the membership.</param>
		/// <param name="_time">The time until the membership gets expired.</param>
		/// <param name="_appSession">The application session.</param>
		public GenerateMembershipRequest(string _appSecret, string _name, int _level, int _time, string _appSession) {
			AppSecret = _appSecret;
			Level = _level;
			Time = _time;
			ApplicationSession = _appSession;
			Name = _name;
		}
	}
}
