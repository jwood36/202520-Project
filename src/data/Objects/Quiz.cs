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

		private long _id;
		public long ID {
			get { return _id; }
			set { _id = value; }
		}

		private Guid _uuid;
		public Guid UUID {
			get {
				if ( this._uuid == Guid.Empty ) {
					this._uuid = Guid.NewGuid();
				}

				return _uuid;
			}
			set { _uuid = value; }
		}

		private bool _random;
		public bool IsRandom {
			get { return _random; }
			set { _random = value; }
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

		private int _time;
		public int Time {
			get { return this._time; }
			set { this._time = value; }
		}

		private int _ppq;

		public int PPQ {
			get { return _ppq; }
			set { _ppq = value; }
		}

	}
}