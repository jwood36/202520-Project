using System;
using System.Collections.Generic;

namespace coding_lms.data {
	public class Question : QuestionView {
		public Question(Guid id) : this() { }
		public Question(long id) : this() { }
		private Question() {
			this._answ = new List<Answer>();
		}

		private long _id;
		public long ID {
			get {
				return _id;
			}
			set {
				_id = value;
			}
		}

		private QuestionEnum _type;
		public QuestionEnum Type {
			get {
				return _type;
			}
			set {
				_type = value;
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

		private IEnumerable<Answer> _answ;
		public IEnumerable<Answer> Answers {
			get { return this._answ; }
			set { this._answ = value; }
		}

		/// <summary>
		/// Cleanup Deconstructor
		/// </summary>
		~Question() {
			this._answ = null;
		}
	}
}