using BurningKnight.entity.bomb;
using BurningKnight.entity.component;
using BurningKnight.level.entities;
using Lens.entity;

namespace BurningKnight.entity.item.use {
	public class DetonateBombsUse : ItemUse {
		public override void Use(Entity entity, Item item) {
			base.Use(entity, item);

			if (!entity.TryGetComponent<RoomComponent>(out var r)) {
				return;
			}

			var bombs = r.Room.Tagged[Tags.Bomb].ToArray();

			foreach (var b in bombs) {
				if (b is Bomb bm) {
					bm.Explode();
				} else if (b is ExplodingBarrel br) {
					br.Explode();
				}
			}
		}
	}
}