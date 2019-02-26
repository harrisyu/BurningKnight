using BurningKnight.entity.level.builders;
using BurningKnight.entity.level.rooms.entrance;
using BurningKnight.entity.level.rooms.regular.boss;

namespace BurningKnight.entity.level.levels.desert {
	public class DesertBossLevel : DesertLevel {
		protected override List CreateRooms<Room>() {
			List<Room> Rooms = new List<>();
			Rooms.Add(Entrance = new EntranceRoom());
			Rooms.Add(new DesertBossRoom());
			Rooms.Add(Exit = new EntranceRoom());
			((EntranceRoom) Exit).Exit = true;

			return Rooms;
		}

		public override bool Same(Level Level) {
			return base.Same(Level) || Level is DesertLevel;
		}

		protected override Builder GetBuilder() {
			return new LineBuilder();
		}
	}
}