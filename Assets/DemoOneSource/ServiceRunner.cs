using System.Collections.Generic;

namespace Barrel.Demo1
{
	public class ServiceRunner
	{
		private List<Service> _services = new();

		public void Start(Service service)
		{
			_services.Add(service);
			service.Start();
		}

		public void Stop(Service service)
		{
			_services.Remove(service);
			service.Stop();
		}

		public void StopAll()
		{
			foreach (Service service in _services)
				service.Stop();
			
			_services.Clear();
		}

		public void Update()
		{
			foreach (Service service in _services)
				service.Update();
		}
	}
}