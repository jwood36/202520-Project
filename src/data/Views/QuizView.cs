using System;

namespace coding_lms.data {
	public class QuizView {

		private Guid _uuid;
		public Guid UUID {
			get {
				if ( this._uuid == Guid.Empty ) {
					this._uuid = Guid.NewGuid ();
				}

				return _uuid;
			}
			set {
				_uuid = value;
			}
		}

		private string _name;
		public string Name {
			get {
				return _name;
			}
			set {
				this._name = value;
			}
		}

		private string _short;
		public string Short {
			get {
				return _short;
			}
			set {
				_short = value;
			}
		}

		private bool _random;
		public bool IsRandom {
			get {
				return _random;
			}
			set {
				_random = value;
			}
		}

		private int _ppq;
		public int PPQ {
			get {
				return _ppq;
			}
			set {
				_ppq = value;
			}
		}


	}
}