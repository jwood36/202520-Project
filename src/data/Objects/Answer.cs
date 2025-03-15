using System;

namespace coding_lms.data {
	public class Answer {
		public Answer(Guid id) {
			this._id = id;
		}

		#region Properties
		private Guid _id;
		public Guid ID {
			get { return _id; }
			set { _id = value; }
		}

		private string _key;
		public string Key {
			get { return _key; }
			set { _key = value; }
		}

		private string _text;
		public string Text {
			get { return _text; }
			set { _text = value; }
		}

		private bool _correct;
		public bool IsCorrect {
			get { return _correct; }
			set { _correct = value; }
		}

		private short _ord;
		public short Ordinal {
			get { return _ord; }
			set { _ord = value; }
		}

		#endregion

	}
}