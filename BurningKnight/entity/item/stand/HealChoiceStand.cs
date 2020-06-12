using BurningKnight.entity.component;
using BurningKnight.util;
using Lens.entity;

namespace BurningKnight.entity.item.stand {
	public class HealChoiceStand : SingleChoiceStand {
		protected override string GetSprite() {
			return "health_stand";
		}

		protected override bool CanInteract(Entity e) {
			return true;
		}

		protected virtual void Heal(Entity entity) {
			var h = entity.GetComponent<HealthComponent>();
			h.ModifyHealth(h.MaxHealth, this);
		}

		protected override bool Interact(Entity entity) {
			Heal(entity);
			RemoveStands();

			Done = true;
			AnimationUtil.Poof(Center);
			
			return true;
		}
	}
}