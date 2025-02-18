using System;
using System.Collections.Generic;

namespace coding_lms.data {
	public class Question {
		public Question(Guid id) : this() { }
		public Question(long id) : this() { }
		private Question() {
			this._answ = new List<Answer>();
		}

		private QuestionEnum _type;
		public QuestionEnum Type {
			get { return _type; }
			set { _type = value; }
		}

		private string _body;
		public string Body {
			get { return _body; }
			set { _body = value; }
		}

		private bool _random;
		public bool IsRandom {
			get { return _random; }
			set { _random = value; }
		}

		private IEnumerable<Answer> _answ;
		public IEnumerable<Answer> Answers { get; set; }

		/// <summary>
		/// Cleanup Deconstructor
		/// </summary>
		~Question() {
			this._answ = null;
		}
	}
}