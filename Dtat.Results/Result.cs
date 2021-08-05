namespace Dtat.Results
{
	public class Result : object
	{
		public Result() : base()
		{
			_errors =
				new System.Collections.Generic.List<string>();

			_successes =
				new System.Collections.Generic.List<string>();
		}

		public bool IsFailed { get; set; }

		public bool IsSuccess { get; set; }

		[System.Text.Json.Serialization.JsonIgnore]
		private readonly System.Collections.Generic.List<string> _errors;

		public System.Collections.Generic.IReadOnlyList<string> Errors
		{
			get
			{
				return _errors;
			}
		}

		[System.Text.Json.Serialization.JsonIgnore]
		private readonly System.Collections.Generic.List<string> _successes;

		public System.Collections.Generic.IReadOnlyList<string> Successes
		{
			get
			{
				return _successes;
			}
		}

		public void AddErrorMessage(string message)
		{
			message =
				String.Fix(text: message);

			if (message == null)
			{
				return;
			}

			if (_errors.Contains(message))
			{
				return;
			}

			_errors.Add(message);
		}

		public void RemoveErrorMessage(string message)
		{
			message =
				String.Fix(text: message);

			if (message == null)
			{
				return;
			}

			_errors.Remove(message);
		}

		public void ClearErrorMessages()
		{
			_errors.Clear();
		}

		public void AddSuccessMessage(string message)
		{
			message =
				String.Fix(text: message);

			if (message == null)
			{
				return;
			}

			if (_successes.Contains(message))
			{
				return;
			}

			_successes.Add(message);
		}

		public void RemoveSuccessMessage(string message)
		{
			message =
				String.Fix(text: message);

			if (message == null)
			{
				return;
			}

			_successes.Remove(message);
		}

		public void ClearSuccessMessages()
		{
			_successes.Clear();
		}

		public void ClearAllMessages()
		{
			ClearErrorMessages();
			ClearSuccessMessages();
		}
	}
}
