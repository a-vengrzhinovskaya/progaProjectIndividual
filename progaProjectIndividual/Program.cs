namespace progaProjectIndividual {
	class Program {
		static void Main(string[] args) {
			GameManager.GetInstance.Start();
			for (var RoomNumber = 0; RoomNumber < 5; ++RoomNumber) {
				GameManager.GetInstance.Move();
            }
		}
	}
}
