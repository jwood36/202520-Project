namespace coding_lms.data {
	public class Quiz : QuizView {
		public Quiz(int term, string crn, string name) : this() {
			this._term = term;
			this._crn = crn;
			this.Name = name;
		}
		public Quiz() {
			this.Init();
		}

		private void Init() {
			return;
		}

		private long _id;
		public long ID {
			get { return _id; }
			set { _id = value; }
		}

		private int _term;
		public int Term {
			get { return _term; }
			set { this._term = value; }
		}

		private string _crn;
		public string Crn {
			get { return _crn; }
			set { this._crn = value; }
		}

		private int _time;
		public int Time {
			get { return this._time; }
			set { this._time = value; }
		}

	}
}