using System;

namespace coding_lms.data {
	public class AttemptPool {
		public AttemptPool() { }

		internal AttemptPool(Attempt att) {
			this.Attempt = att;
		}

		private Attempt _att;
		public Attempt Attempt {
			get { return _att; }
			set { _att = value; }
		}

		private Guid _quest;
		public Guid Question {
			get { return _quest; }
			set { _quest = value; }
		}

		private Guid _answ;
		public Guid Answer {
			get { return _answ; }
			set { _answ = value; }
		}

		private bool _corr;
		public bool IsCorrect {
			get { return _corr; }
			set { _corr = value; }
		}

		private short _pts;
		public short Points {
			get { return _pts; }
			set { _pts = value; }
		}


	}
}