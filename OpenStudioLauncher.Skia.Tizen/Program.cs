using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace OpenStudioLauncher.Skia.Tizen
{
	public sealed class Program
	{
		static void Main(string[] args)
		{
			var host = new TizenHost(() => new OpenStudioLauncher.App());
			host.Run();
		}
	}
}
