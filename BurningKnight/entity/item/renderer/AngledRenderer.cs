using System;
using BurningKnight.util;
using Lens.graphics;
using Lens.input;
using Lens.util;
using Lens.util.tween;
using Microsoft.Xna.Framework;

namespace BurningKnight.entity.item.renderer {
	public class AngledRenderer : ItemRenderer {
		public float Angle;
		public Vector2 Origin;
		
		private double lastAngle;
		private float sx = 1;
		private float sy = 1;
		private float oy;
		private float ox;

		public bool CenterX;
		public bool CenterY;
		public bool EndX;
		public bool EndY;

		
		public override void Setup() {
			base.Setup();
			
			var region = Item.Region;

			if (CenterX) {
				Origin.X = region.Source.Width / 2f;
			} else if (EndX) {
				Origin.X = region.Source.Width;
			}

			if (CenterY) {
				Origin.Y = region.Source.Height / 2f;
			} else if (EndY) {
				Origin.Y = region.Source.Height;
			}
		}

		public override void Render(bool atBack, bool paused, float dt) {
			float s = dt * 10f;
			
			sx += (1 - sx) * s;
			sy += (1 - sy) * s;
			ox += (-ox) * s;
			oy += (-oy) * s;
			
			var region = Item.Region;
			var owner = Item.Owner;
			var flipped = owner.GraphicsComponent.Flipped;
			
			if (!atBack && !paused) {
				lastAngle = MathUtils.LerpAngle(lastAngle, owner.AngleTo(Input.Mouse.GamePosition), dt * 6f);
			}
			
			var angle = (flipped ? -Angle : Angle) + (atBack ? Math.PI / 4 : lastAngle);

			if (flipped) {
				angle -= Math.PI;
			}
			
			Graphics.Render(region, new Vector2(owner.CenterX + (flipped ? -3 : 3), owner.CenterY), 
				(float) angle, Origin + new Vector2(ox, oy), new Vector2(flipped ? -sx : sx, sy));
		}

		public override void OnUse() {
			base.OnUse();

			sx = 0.3f;
			sy = 2f;
			ox = 8;
		}
	}
}