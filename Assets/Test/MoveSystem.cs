using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public sealed class MoveSystem : ISystem {
	public World World { get; set; }
	private Filter _filter;
	private Stash<UnityTtransform> _positionStash;

	public void OnAwake() {
		_filter = World.Filter.With<UnityTtransform>().Build();
		_positionStash = World.GetStash<UnityTtransform>();
	}


	public void OnUpdate(float deltaTime) {
		foreach (Entity entity in _filter) {
			ref Transform transform = ref _positionStash.Get(entity).Transform;
			
			transform.position = new Vector3(transform.position.x + (1f * deltaTime),0,0);
		}
	}

	public void Dispose() {
		_positionStash?.Dispose();
	}
}