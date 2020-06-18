using System;
using System.Collections.Generic;
using System.Text;

namespace AuthedSharp.Models.Parameters {
	public struct GenerateMembershipRequest {
		public readonly string AppSecret;
		public readonly string Name;
		public readonly int Time;
		public readonly int Level;
		public readonly string Session;

		public GenerateMembershipRequest(string _appSecret, string _name, int _level, int _time, string _session) {
			AppSecret = _appSecret;			
			Level = _level;
			Time = _time;
			Session = _session;
			Name = _name;
		}
	}
}
