namespace progaProjectIndividual {
	class Program {
		static void Main(string[] args) {
			GameManager.GetInstance.Start();
			for (var RoomNumber = 0; RoomNumber < 5; ++RoomNumber) {
				try {
					GameManager.GetInstance.Move();
				} catch {
					Console.Clear();
					Console.WriteLine("You died.");
					return;
				}
            }
			GameManager.GetInstance.SaveCoins();
		}
	}
}