using System;

namespace coding_lms.data {
	public class Quiz {
		public Quiz(int term, string crn, string name) : this() {
			this._term = term;
			this._crn = crn;
			this._name = name;
		}
		private Quiz() {
			this.Init();
		}

		private void Init() {
			return;
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

		private string _name;
		public string Name {
			get { return _name; }
			set { this._name = value; }
		}

	}
}