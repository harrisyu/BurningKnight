namespace BurningKnight.entity.item.consumable {
	public class Consumable : Item {
		public override void Use() {
			if (!CanBeUsed() || Count == 0) return;

			SetCount(Math.Max(0, Count - 1));

			if (Count == 0) Done = true;

			base.Use();
		}
	}
}