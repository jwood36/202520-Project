using System;
using System.Collections.Generic;

namespace coding_lms.data {
	public class Attempt {
		public Attempt() { }
		public Attempt(Guid guid) {
			this._guid = guid;
		}

		#region Properties
		private Int64 _id;  // Database ID value
		internal Int64 ID {
			get { return this._id; }
			set { this._id = value; }
		}

		private Guid _guid; // Database Row-GUID value
		public Guid UID {
			get { return _guid; }
			internal set { _guid = value; }
		}

		private Student _student;   // Students Row-GUID value
		public Student Student {
			get { return _student; }
			internal set { _student = value; }
		}

		private Quiz _quiz; // Quiz Row-GUID value
		public Quiz Quiz {
			get { return _quiz; }
			internal set { _quiz = value; }
		}

		private IEnumerable<AttemptPool> _attpool;
		public IEnumerable<AttemptPool> Results {
			get { return this._attpool; }
			set { this._attpool = value; }
		}
		#endregion

		#region Static Methods
		/// <summary>
		/// Create an Attempt Object from the Int64 value passed
		/// </summary>
		/// <param name="id">Int64 Value</param>
		/// <returns></returns>
		public static Attempt Create(Int64 id) {
			Attempt att = null;

			using ( var ctx = new TestDB() ) {
				var res = ctx.GetAttempt(id) as Attempt;
				if ( res != null ) {
					att = res;
				}
			}

			return att;
		}
		#endregion
	}
}