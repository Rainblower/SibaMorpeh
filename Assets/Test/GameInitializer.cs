using Scellecs.Morpeh;
using UnityEngine;

public class GameInitializer : MonoBehaviour {
	private World world;

	private void Start() {
		world = World.Default;

		var systemsGroup = world.CreateSystemsGroup();
		systemsGroup.AddSystem(new MoveSystem());
        
		world.AddSystemsGroup(order: 0, systemsGroup);
	}
}