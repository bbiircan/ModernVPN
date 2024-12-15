namespace ModernVPN.MVVM.ViewModel
{
    class GlobalViewModel
    {
        public static GlobalViewModel Instance { get; } = new GlobalViewModel();

		private bool _isAwesome;

		public bool IsAwesome
		{
			get { return _isAwesome; }
			set { _isAwesome = value; }
		}

	}
}
